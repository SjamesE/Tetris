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

        public void AddScore(int type)
        {
            int moveScore = 0;
            Lines += type;
            switch (type)
            {
                case 1: // Single
                    moveScore = 100;
                    break;
                case 2: // Double
                    moveScore = 300;
                    break;
                case 3: // Triple
                    moveScore = 500;
                    break;
                case 4: // Tetris
                    moveScore = 800;
                    break;
                default:
                    break;
            }

            int bonusScore = combo ? 50 : 0;
            Total += (moveScore + bonusScore) * level;

            combo = true;
        }

        public void SoftDropIncrement() => Total++;

        public void HardDropIncrement(int height) => Total += height * 2;

        public void ComboReset() => combo = false;
    }
}
