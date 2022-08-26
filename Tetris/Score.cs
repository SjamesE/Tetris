namespace Tetris
{
    public class Score
    {
        public int Total { get; private set; }
        public int Lines { get; private set; }
        public int Triple { get; private set; }
        public int Tetris { get; private set; }
        public int TSpin { get; private set; }
        public int TSpinD { get; private set; }
        public int TSpinT { get; private set; }

        public int level { get; private set; } = 1;

        private bool combo = false;
        private bool B2B = false;

        /// <summary>
        /// Add Score based on the type passed in the parameter
        /// </summary>
        /// <param name="type"></param>
        /// <returns>type of clear text to show (0 nothing)</returns>
        public int AddScore(int type)
        {
            int clearText = 0;
            int moveScore = 0;
            Lines += type;
            switch (type)
            {
                case 1: // Single
                    moveScore = 100;
                    B2B = false;
                    break;
                case 2: // Double
                    moveScore = 300;
                    B2B = false;
                    break;
                case 3: // Triple
                    moveScore = 500;
                    B2B = false;
                    break;
                case 4: // Tetris
                    moveScore = (B2B) ? 1200 : 800;
                    clearText = (B2B) ? 2 : 1;
                    B2B = true;
                    break;
                case 5: // T-Spin Single
                    moveScore = (B2B) ? 1200 : 800;
                    clearText = (B2B) ? 4 : 3;
                    B2B = true;
                    break;
                case 6: // T-Spin Double
                    moveScore = (B2B) ? 1800 : 1200;
                    clearText = (B2B) ? 6 : 5;
                    B2B = true;
                    break;
                case 7: // T-Spin Triple
                    moveScore = (B2B) ? 2400 : 1600;
                    clearText = (B2B) ? 8 : 7;
                    B2B = true;
                    break;
                default:
                    break;
            }

            int bonusScore = combo ? 50 : 0;
            Total += (moveScore + bonusScore) * level;
            combo = true;

            Console.WriteLine(clearText);
            return clearText;
        }

        public void SoftDropIncrement() => Total++;

        public void HardDropIncrement(int height) => Total += height * 2;

        public void ComboReset() => combo = false;
    }
}
