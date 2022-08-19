using Utility;

namespace Tetris
{
    public static class Tetrominos
    {
        public static readonly bool[] S = new bool[9]
        {
            false, false, false, // 0 1 1
             true,  true, false, // 1 1 0
            false,  true,  true  // 0 0 0
        };
        public static readonly bool[] Z = new bool[9]
        {
            false, false, false, // 1 1 0
            false,  true,  true, // 0 1 1
             true,  true, false  // 0 0 0
        };
        public static readonly bool[] J = new bool[9]
        {
            false, false, false, // 1 0 0
             true,  true,  true, // 1 1 1
             true, false, false  // 0 0 0
        };
        public static readonly bool[] L = new bool[9]
        {
            false, false, false, // 0 0 1
             true,  true,  true, // 1 1 1
            false, false, true   // 0 0 0
        };
        public static readonly bool[] T = new bool[9]
        {
            false, false, false, // 0 1 0
             true,  true,  true, // 1 1 1
            false,  true, false  // 0 0 0
        };
        public static readonly bool[] O = new bool[4]
        {
             true,  true,        // 1 1
             true,  true         // 1 1
        };
        public static readonly bool[] I = new bool[16]
        {
            false, false, false, false, // 0 0 0 0
            false, false, false, false, // 1 1 1 1 
             true,  true,  true,  true, // 0 0 0 0
            false, false, false, false  // 0 0 0 0
        };

        public static bool[] GetByID(int ID)
        {
            switch (ID)
            {
                case 1:
                    return S;
                case 2:
                    return Z;
                case 3:
                    return J;
                case 4:
                    return L;
                case 5:
                    return T;
                case 6:
                    return O;
                case 7:
                    return I;
                default:
                    return null;
            }
        }
    }

    public struct Tetromino
    {
        public Vector2i pos;
        public int type;
        public int rotation;
        public bool[] data;
        public int size;

        public Tetromino(int ID)
        {
            pos = (ID != 6) ? new Vector2i(3, 18) : new Vector2i(4, 18);
            type = ID;
            rotation = 0;
            data = Tetrominos.GetByID(ID);
            size = (data.Length == 9) ? 3 : (data.Length== 4) ? 2 : 4;
        }
    }

    public class Grid
    {
        public List<List<int>> Data { get; private set; } = new List<List<int>>();
        public Grid()
        {
            // Initialize Grid Data
            for (int i = 0; i < 20; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < 10; j++) list.Add(0);
                Data.Add(list);
            }
        }

        public void Place(Tetromino tetromino)
        {
            if (tetromino.data == null) throw new NullReferenceException();

            for (int y = 0; y < tetromino.size; y++)
            {
                for (int x = 0; x < tetromino.size; x++)
                {
                    int index = y * tetromino.size + x;
                    if (!tetromino.data[index]) continue;

                    Data[tetromino.pos.y + y][tetromino.pos.x + x] = tetromino.type;
                }
            }
        }

        public bool CheckCollisionBelow(Tetromino tetromino)
        {
            for (int y = -1; y < tetromino.size - 1; y++)
            {
                for (int x = 0; x < tetromino.size; x++)
                {
                    int index = (y + 1) * tetromino.size + x;
                    if (!tetromino.data[index]) continue;
                    
                    int _x = tetromino.pos.x + x;
                    int _y = tetromino.pos.y + y;

                    if (_y > 19) continue;
                    if (_y < 0) return true;
                    if (Data[_y][_x] != 0) return true;
                }
            }

            return false;
        }
    }

    public class MainLogic
    {
        public Grid Grid { get; private set; }
        public List<int> NextTetrominos { get; private set; }
        public Tetromino CurrTetromino { get; private set; }

        public float dropDefaultTime = 0.5f;
        public float timeTillDrop;
        private float levelDifficulty = 5;


        public MainLogic()
        {
            timeTillDrop = dropDefaultTime;
            Grid = new Grid();
            NextTetrominos = new List<int>();

            GetNextBag();
            GetNextTetromino();
        }

        public void Update()
        {
            timeTillDrop -= Time.deltaTime * levelDifficulty;

            if (timeTillDrop < 0)
            {
                if (Grid.CheckCollisionBelow(CurrTetromino))
                {
                    Grid.Place(CurrTetromino);
                    GetNextTetromino();
                } else CurrTetromino.pos.y--;

                timeTillDrop = dropDefaultTime;
            }

            CheckInput();
        }

        public void GetNextTetromino()
        {
            CurrTetromino = new Tetromino(NextTetrominos[0]);
            NextTetrominos.RemoveAt(0);

            if (NextTetrominos.Count < 5) GetNextBag();
        }

        public void GetNextBag()
        {
            List<int> avaliableTetrominos = new List<int> { 1, 2, 3, 4, 5, 6, 7};

            for (int i = 0; i < 7; i++)
            {
                Random random = new Random();
                int rnd = random.Next(avaliableTetrominos.Count - 1);

                NextTetrominos.Add(avaliableTetrominos[rnd]);
                avaliableTetrominos.RemoveAt(rnd);
            }
        }

        private void CheckInput()
        {
            // Left Button - Shift to the left
            if (Input.Keyboard.Left == KeyState.down)
            {
                if (CurrTetromino.pos.x != 0) CurrTetromino.pos.x--;
            }

            // Right Button - Shift to the right
            if (Input.Keyboard.Right == KeyState.down)
            {
                if (CurrTetromino.pos.x + CurrTetromino.size < 10) CurrTetromino.pos.x++;
            }

            // Up Button - Place
            if (Input.Keyboard.Up == KeyState.down)
            {
                Grid.Place(CurrTetromino);
                GetNextTetromino();
            }

            // Down Button - Increase falling speed
            if (Input.Keyboard.Down == KeyState.down)
            {
                levelDifficulty *= 5;
            }

            // Down Button Up - Increase falling speed
            if (Input.Keyboard.Down == KeyState.up)
            {
                levelDifficulty /= 5;
            }

            // Z Button
            if (Input.Keyboard.Z == KeyState.down)
            {
                //TODO
            }

            // X Button
            if (Input.Keyboard.X == KeyState.down)
            {
                //TODO
            }

            // C Button
            if (Input.Keyboard.C == KeyState.down)
            {
                //TODO
            }
        }
    }
}
