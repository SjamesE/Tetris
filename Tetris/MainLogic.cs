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

        public static bool[]? GetByID(int ID)
        {
            switch (ID)
            {
                case 0:
                    return S;
                case 1:
                    return Z;
                case 2:
                    return J;
                case 3:
                    return L;
                case 4:
                    return T;
                case 5:
                    return O;
                case 6:
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

        public Tetromino(int ID)
        {
            pos = new Vector2i(3, 18);
            type = ID;
            rotation = 0;
        }

        public int GetSize()
        {
            int length = Tetrominos.GetByID(type).Length;
            return (length == 9) ? 3 : (length == 4) ? 2 : 4;
        }
    }

    public class Grid
    {
        public List<List<int>> Data { get; private set; } = new List<List<int>>();
        public Grid()
        {
            // Initialize Grid Data
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++) list.Add(0);
            for (int i = 0; i < 20; i++) Data.Add(list);
        }

        public void Place(Tetromino tetromino)
        {
            bool[]? tetrominoData = Tetrominos.GetByID(tetromino.type);
            if (tetrominoData == null) throw new NullReferenceException();

            int size = tetromino.GetSize();

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int index = y * size + x;
                    if (!tetrominoData[index]) continue;

                    Data[y][x] = tetromino.type;
                }
            }
        }
    }

    public class MainLogic
    {
        public Grid Grid { get; private set; }
        public List<int> NextTetrominos { get; private set; }
        public Tetromino CurrTetromino { get; private set; }

        public float dropDefaultTime = 0.5f;
        public float timeTillDrop;


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
            timeTillDrop -= Time.deltaTime;
            //Console.WriteLine(Time.deltaTime);

            if (timeTillDrop < 0)
            {
                CurrTetromino.pos.y--;

                if (CurrTetromino.pos.y < 0)
                {
                    Grid.Place(CurrTetromino);
                    GetNextTetromino();
                }

                timeTillDrop = dropDefaultTime;
            }
        }

        public void GetNextTetromino()
        {
            CurrTetromino = new Tetromino(NextTetrominos[0]);
            NextTetrominos.RemoveAt(0);

            if (NextTetrominos.Count < 5) GetNextBag();
        }

        public void GetNextBag()
        {
            List<int> avaliableTetrominos = new List<int> { 0, 1, 2, 3, 4, 5, 6};

            for (int i = 0; i < 7; i++)
            {
                Random random = new Random();
                int rnd = random.Next(avaliableTetrominos.Count - 1);

                NextTetrominos.Add(avaliableTetrominos[rnd]);
                avaliableTetrominos.RemoveAt(rnd);
            }
        }
    }
}
