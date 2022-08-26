using Utility;

namespace Tetris
{
    public class Tetromino
    {
        public Vector2i pos;
        public int type;
        public int rotation;
        public bool[] data;
        public int size;

        public Tetromino(int ID)
        {
            // Set position while accounting for tetromino size
            pos = (ID == 6) ? new Vector2i(4, 19) : (ID == 7) ? new Vector2i(3, 18) : new Vector2i(3, 18);
            type = ID;
            rotation = 0;

            // Clone initial bool arr. Otherwise this var will share the same pointer as the initial arr which will lead to weird side effect
            data = (bool[])Tetrominos.GetByID(ID).Clone();
            size = (data.Length == 9) ? 3 : (data.Length == 4) ? 2 : 4;
        }
    }

    public class MainLogic
    {
        public Grid Grid { get; private set; }
        public List<int> NextTetrominos { get; private set; }
        public Tetromino CurrTetromino { get; private set; }
        public int? HoldingTetromino { get; private set; }
        public Score score { get; private set; }
        public Level Level { get; private set; }

        public float timeTillDrop;
        public int clearText = 0;

        private float DASInitialDelay = 0.13f;
        private float DASDelay = 0.08f;
        private float DASTimer = -1;
        private bool  skipDrop = false;
        private bool  softDrop = false;
        private bool  tSpin = false;

        private float lockTimer = 0.5f;
        private bool lockTimerStarted = false;

        public MainLogic()
        {
            Grid = new Grid();
            NextTetrominos = new List<int>();
            score = new Score();
            Level = new Level();
            timeTillDrop = Level.DropTime();
            HoldingTetromino = null;

            GetNextBag();
            GetNextTetromino();
        }

        public void Update()
        {
            timeTillDrop -= Time.deltaTime;
            clearText = 0;

            if (lockTimerStarted)
            {
                lockTimer -= Time.deltaTime;
                if (lockTimer <= 0 || skipDrop)
                {
                    // Place tetromino
                    Grid.Place(CurrTetromino);

                    // Clear lines
                    int clearedLines = Grid.ClearLines();

                    // Update score and level
                    // and Handle T-Spins
                    if (clearedLines > 0)
                    {
                        if (tSpin) clearText = score.AddScore(clearedLines + 5);
                        else       clearText = score.AddScore(clearedLines);

                        tSpin = false;
                        Level.RemoveLines(clearedLines);
                    } else score.ComboReset();

                    // Get next tetromino
                    GetNextTetromino();

                    lockTimer = 0.5f;
                    lockTimerStarted = false;

                    skipDrop = false;
                }
            }

            if (timeTillDrop < 0 || skipDrop)
            {

                // Handle collision if there is one
                if (Grid.CheckCollisionAt(CurrTetromino, 0, -1))
                {
                    lockTimerStarted = true;
                } else
                {
                    // Drop tetromino 1 square and update score
                    CurrTetromino.pos.y--;
                    if (softDrop) score.SoftDropIncrement();
                }

                timeTillDrop = (softDrop) ? 0.033f : Level.DropTime();
            }

            HandleInput();
        }

        public void GetNextTetromino()
        {
            // Get next tetromino and remove it from the queue 
            CurrTetromino = new Tetromino(NextTetrominos[0]);
            NextTetrominos.RemoveAt(0);

            // If the queue is shorter than 5 (the amount of tetrominos showed on the screen) get a new bag (7 tetrominos)
            if (NextTetrominos.Count < 5) GetNextBag();
        }

        public void GetNextBag()
        {
            List<int> avaliableTetrominos = new List<int> { 1, 2, 3, 4, 5, 6, 7};

            // Get one element of the above list at random and place it in the queue until the above list is empty
            for (int i = 0; i < 7; i++)
            {
                Random random = new Random();
                int rnd = random.Next(avaliableTetrominos.Count - 1);

                NextTetrominos.Add(avaliableTetrominos[rnd]);
                avaliableTetrominos.RemoveAt(rnd);
            }
        }

        private void HandleInput()
        {
            // Left Button - Shift to the left with DAS
            if (Input.Keyboard.Left == KeyState.down)
            {
                if (!Grid.CheckCollisionAt(CurrTetromino, -1, 0)) CurrTetromino.pos.x--;

                DASTimer = DASInitialDelay;

            } else if (Input.Keyboard.Left == KeyState.pressed)
            {
                DASTimer -= Time.deltaTime;
                if (DASTimer < 0)
                {
                    if (!Grid.CheckCollisionAt(CurrTetromino, -1, 0)) CurrTetromino.pos.x--;

                    DASTimer = DASDelay;
                }
            }

            // Right Button - Shift to the right with DAS
            if (Input.Keyboard.Right == KeyState.down)
            {
                if (!Grid.CheckCollisionAt(CurrTetromino, 1, 0)) CurrTetromino.pos.x++;

                DASTimer = DASInitialDelay;

            } else if (Input.Keyboard.Right == KeyState.pressed)
            {
                DASTimer -= Time.deltaTime;
                if (DASTimer < 0)
                {
                    if (!Grid.CheckCollisionAt(CurrTetromino, 1, 0)) CurrTetromino.pos.x++;

                    DASTimer = DASDelay;
                }
            }

            // Reset DAS timer if movement button is up
            if (Input.Keyboard.Left == KeyState.up || Input.Keyboard.Right == KeyState.up) DASTimer = -1;

            // Up Button - Place
            if (Input.Keyboard.Up == KeyState.down)
            {
                int y  = CurrTetromino.pos.y;
                int y2 = Grid.GetPlacePos(CurrTetromino).y;
                score.HardDropIncrement(y - y2);
                skipDrop = true;

                CurrTetromino.pos.y = y2;
            }

            // Down Button
            if (Input.Keyboard.Down == KeyState.down)
            {
                softDrop = true;
                timeTillDrop = 0.033f;
            }

            // Down Button Up
            if (Input.Keyboard.Down == KeyState.up)
            {
                softDrop = false;
            }

            // Z Button
            if (Input.Keyboard.Z == KeyState.down)
            {
                Rotate(false);
            }

            // X Button
            if (Input.Keyboard.X == KeyState.down)
            {
                Rotate(true);
            }

            // C Button
            if (Input.Keyboard.C == KeyState.down)
            {
                CycleHolding();
            }
        }

        private void CycleHolding()
        {
            if (HoldingTetromino == null)
            {
                HoldingTetromino = CurrTetromino.type;
                GetNextTetromino();
            } else
            {
                var curr = CurrTetromino.type;
                CurrTetromino = new Tetromino((int)HoldingTetromino);
                HoldingTetromino = curr;
            }
        }

        private void Rotate(bool clockwise)
        {
            lockTimer = 0.5f;
            int wallKickIndex = GetKickIndex(CurrTetromino.rotation, clockwise);

            CurrTetromino.rotation += (clockwise) ? 1 : -1;
            if (CurrTetromino.rotation > 3) CurrTetromino.rotation = 0;
            if (CurrTetromino.rotation < 0) CurrTetromino.rotation = 3;

            // New temp arr for storing new rotated tetromino
            bool[] temp = (bool[])CurrTetromino.data.Clone();

            // Rotate tetromino for size 3
            if (CurrTetromino.size == 3)
            {
                for (int y = 0; y < CurrTetromino.size; y++)
                {
                    for (int x = 0; x < CurrTetromino.size; x++)
                    {
                        int index = y * CurrTetromino.size + x;
                        int index2 = (clockwise) ? 2 - y + x * 3 : y + 6 - x * 3;
                        CurrTetromino.data[index] = temp[index2];
                    }
                }
                if (Grid.CheckCollisionAt(CurrTetromino, 0, 0))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Vector2i kickOffset = Tetrominos.WallKick[wallKickIndex, i];
                        if (!Grid.CheckCollisionAt(CurrTetromino, kickOffset.x, kickOffset.y))
                        {
                            CurrTetromino.pos.x += kickOffset.x;
                            CurrTetromino.pos.y += kickOffset.y;
                            break;
                        }
                    }
                }
            }

            // Rotate tetromino for size 4
            else if (CurrTetromino.size == 4)
            {
                for (int y = 0; y < CurrTetromino.size; y++)
                {
                    for (int x = 0; x < CurrTetromino.size; x++)
                    {
                        int index = y * CurrTetromino.size + x;
                        int index2 = (clockwise) ? 3 - y + x * 4 : y + 12 - x * 4;
                        CurrTetromino.data[index] = temp[index2];
                    }
                }
                if (Grid.CheckCollisionAt(CurrTetromino, 0, 0))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Vector2i kickOffset = Tetrominos.WallKickI[wallKickIndex, i];
                        if (!Grid.CheckCollisionAt(CurrTetromino, kickOffset.x, kickOffset.y))
                        {
                            CurrTetromino.pos.x += kickOffset.x;
                            CurrTetromino.pos.y += kickOffset.y;
                            break;
                        }
                    }
                }
            }
            if (Grid.CheckCollisionAt(CurrTetromino, 0, 0)) Rotate(!clockwise);
            else if (CurrTetromino.type == 5)
            {
                var pos = CurrTetromino.pos;
                if (pos.y > 16) return;

                if (Grid.Data[pos.y + 2][pos.x] != 0 || Grid.Data[pos.y + 2][pos.x + 2] != 0)
                    tSpin = true;
            }
        }

        private int GetKickIndex(int rotation, bool clockwise)
        {
            switch (rotation)
            {
                case 0:
                    return (clockwise) ? 0 : 1;
                case 1:
                    return (clockwise) ? 2 : 3;
                case 2:
                    return (clockwise) ? 4 : 5;
                case 3:
                    return (clockwise) ? 6 : 7;
                default:
                    throw new ArgumentException("Rotation was not valid: " + rotation);
            }
        }
    }
}
