namespace Tetris
{
    public class Level
    {
        public int Lvl { get; private set; }
        public int LinesForNextLvl => Math.Min(Lvl * 10 + 1, Math.Max(100, Lvl * 10 - 50));
        public int LinesLeft { get; private set; }
        public float DropTime()
        {
            switch (Lvl)
            {
                case 1:
                    return 1;
                case 2:
                    return 0.8f;
                case 3:
                    return 0.62f;
                case 4:
                    return 0.5f;
                case 5:
                    return 0.4f;
                case 6:
                    return 0.3f;
                case 7:
                    return 0.2f;
                case 8:
                    return 0.15f;
                case 9:
                    return 0.1f;
                case 10:
                    return 0.65f;
                case 11:
                    return 0.45f;
                case 12:
                    return 0.3f;
                case 13:
                    return 0.2f;
                case 14:
                    return 0.12f;
                case 15:
                    return 0.1f;
                default:
                    return 0.07f;
            }
        }

        public Level()
        {
            Lvl = 1;
            LinesLeft = LinesForNextLvl;
        }

        public void RemoveLines(int lines)
        {
            if (lines >= LinesLeft)
            {
                Lvl++;
                int difference = lines - LinesLeft;
                LinesLeft = LinesForNextLvl - difference;
                return;
            }
            LinesLeft -= lines;
        }
    }
}
