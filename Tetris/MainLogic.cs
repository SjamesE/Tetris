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
        public Vector2 pos;
        public int type;
        public int rotation;
    }

    public class Grid
    {
        public List<List<int>> Data { get; private set; } = new List<List<int>>();
        public Tetromino currTetromino;
        public Grid()
        {
            // Initialize Grid Data
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++) list.Add(0);
            for (int i = 0; i < 20; i++) Data.Add(list);
        }
    }

    public class MainLogic
    {
        public Grid Grid { get; private set; }

        public MainLogic()
        {
            Grid = new Grid();
        }

        public void Update()
        {

        }
    }
}
