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

        public static Vector2i[,] WallKick = new Vector2i[8, 4]
        {//           0                    1                    2                     3
            { new Vector2i(-1, 0), new Vector2i(-1, 1), new Vector2i( 0,-2), new Vector2i(-1,-2) }, // 0 > 1
            { new Vector2i( 1, 0), new Vector2i( 1, 1), new Vector2i( 0,-2), new Vector2i( 1, 2) }, // 0 > 3
            { new Vector2i( 1, 0), new Vector2i( 1,-1), new Vector2i( 0, 2), new Vector2i( 1, 2) }, // 1 > 2
            { new Vector2i( 1, 0), new Vector2i( 1,-1), new Vector2i( 0, 2), new Vector2i( 1, 2) }, // 1 > 0
            { new Vector2i( 1, 0), new Vector2i( 1, 1), new Vector2i( 0,-2), new Vector2i( 1, 2) }, // 2 > 3
            { new Vector2i(-1, 0), new Vector2i(-1, 1), new Vector2i( 0,-2), new Vector2i(-1,-2) }, // 2 > 1
            { new Vector2i(-1, 0), new Vector2i(-1,-1), new Vector2i( 0, 2), new Vector2i(-1,-2) }, // 3 > 0
            { new Vector2i(-1, 0), new Vector2i(-1,-1), new Vector2i( 0, 2), new Vector2i(-1,-2) }  // 3 > 2
        };

        public static Vector2i[,] WallKickI = new Vector2i[8, 4]
        {//           0                    1                    2                     3
            { new Vector2i(-2, 0), new Vector2i( 1, 0), new Vector2i(-2,-1), new Vector2i( 1, 2) }, // 0 > 1
            { new Vector2i(-1, 0), new Vector2i( 2, 0), new Vector2i(-1, 2), new Vector2i( 2,-1) }, // 0 > 3
            { new Vector2i(-1, 0), new Vector2i( 2, 0), new Vector2i(-1, 2), new Vector2i( 2,-1) }, // 1 > 2
            { new Vector2i( 2, 0), new Vector2i(-1, 0), new Vector2i( 2, 1), new Vector2i(-1,-2) }, // 1 > 0
            { new Vector2i( 2, 0), new Vector2i(-1, 0), new Vector2i( 2, 1), new Vector2i(-1,-2) }, // 2 > 3
            { new Vector2i( 1, 0), new Vector2i(-2, 0), new Vector2i( 1,-2), new Vector2i(-2, 1) }, // 2 > 1
            { new Vector2i( 1, 0), new Vector2i(-2, 0), new Vector2i( 1,-2), new Vector2i(-2, 1) }, // 3 > 0
            { new Vector2i(-2, 0), new Vector2i( 1, 0), new Vector2i(-2,-1), new Vector2i( 1, 2) }  // 3 > 2
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
}
