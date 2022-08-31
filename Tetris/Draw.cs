using SFML.Graphics;
using Utility;

namespace Tetris
{
    public class Draw
    {
        private readonly Color backgroundColor  = Color.Black;
        private readonly Vector2i gridOffset    = new Vector2i(147, 621);
        private readonly Vector2i nextOffset    = new Vector2i(503, 88);
        private readonly Vector2i holdingOffset = new Vector2i(36, 87);
        private readonly int clearLineY = 250;
        private readonly int textPosL = 70;
        private readonly int textPosR = 535;

        private float clearTextOpacity = 0;
        private int clearText = 0;

        public void Update(MainLogic mainLogic)
        {
            List<List<int>> gridData = mainLogic.Grid.Data;
            Tetromino currTetromino = mainLogic.CurrTetromino;

            Window.RenderWindow.Clear(backgroundColor);
            Sprite sprite;

            // Draw Background
            sprite = new Sprite(Assets.Background);
            Window.RenderWindow.Draw(sprite);

            // Draw Grid
            for (int y = 0; y < gridData.Count; y++)
            {
                for (int x = 0; x < gridData[0].Count; x++)
                {
                    sprite = new Sprite(Assets.Block[gridData[y][x]]);
                    sprite.Position = new SFML.System.Vector2f(gridOffset.x + 32 * x, gridOffset.y - 32 * y);
                    Window.RenderWindow.Draw(sprite);
                }
            }

            // Draw current tetromino
            for (int y = 0; y < currTetromino.size; y++)
            {
                for (int x = 0; x < currTetromino.size; x++)
                {
                    int index = y * currTetromino.size + x;
                    if (!currTetromino.data[index]) continue;

                    sprite = new Sprite(Assets.Block[currTetromino.type]);
                    sprite.Position = new SFML.System.Vector2f(gridOffset.x + 32 * (currTetromino.pos.x + x), gridOffset.y - 32 * (currTetromino.pos.y + y));
                    Window.RenderWindow.Draw(sprite);
                }
            }

            // Draw next tetrominos
            for (int i = 0; i < 5; i++)
            {
                int next = mainLogic.NextTetrominos[i] - 1;
                int offX = (next == 5) ? 12 : (next == 6) ? -12 : 0;
                int offY = (next == 6) ? 12 : 0;

                sprite = new Sprite(Assets.Preview[next]);
                sprite.Position = new SFML.System.Vector2f(nextOffset.x + offX, nextOffset.y + 82 * i + offY);
                sprite.Scale = new SFML.System.Vector2f(0.75f, 0.75f);
                Window.RenderWindow.Draw(sprite);
            }

            // Draw Ghost
            Vector2i ghostPos = mainLogic.Grid.GetPlacePos(currTetromino);
            for (int y = 0; y < currTetromino.size; y++)
            {
                for (int x = 0; x < currTetromino.size; x++)
                {
                    int index = y * currTetromino.size + x;
                    if (!currTetromino.data[index]) continue;

                    sprite = new Sprite(Assets.Block[currTetromino.type]);
                    sprite.Position = new SFML.System.Vector2f(gridOffset.x + 32 * (ghostPos.x + x), gridOffset.y - 32 * (ghostPos.y + y));
                    sprite.Color = new Color(255, 255, 255, 100);
                    Window.RenderWindow.Draw(sprite);
                }
            }

            // Draw Holding
            int? type = mainLogic.HoldingTetromino;
            if (type != null)
            {
                type--;
                int offX = (type == 5) ? 12 : (type == 6) ? -12 : 0;
                int offY = (type == 6) ? 12 : 0;

                sprite = new Sprite(Assets.Preview[(int)mainLogic.HoldingTetromino - 1]);
                sprite.Position = new SFML.System.Vector2f(holdingOffset.x + offX, holdingOffset.y + offY);
                sprite.Scale = new SFML.System.Vector2f(0.75f, 0.75f);
                Window.RenderWindow.Draw(sprite);
            }

            // Draw Score
            DrawText("Score", new Vector2i(textPosL, 200));
            DrawText(mainLogic.score.Total.ToString(), new Vector2i(textPosL, 230));

            // Draw Next & Hold text
            DrawText("Next", new Vector2i(textPosR, 25));
            DrawText("Hold", new Vector2i(textPosL, 25));

            // Draw Level
            DrawText("Level", new Vector2i(textPosR, 500));
            DrawText(mainLogic.Level.Lvl.ToString(), new Vector2i(textPosR - 10, 530), fontSize: 80);

            // Draw LinesTillLvlUp
            DrawText("Lines to", new Vector2i(textPosL, 280));
            DrawText("clear", new Vector2i(textPosL, 310));
            DrawText(mainLogic.Level.LinesLeft.ToString(), new Vector2i(textPosL, 340), fontSize: 35);

            if (clearText == 0)
                clearText = mainLogic.clearText;
            DrawClearLineText();

            Window.RenderWindow.Display();
        }

        private void DrawClearLineText()
        {
            if (clearText == 0) return;
            if (clearTextOpacity == 0)
            {
                clearTextOpacity = 255;
            }
            string text;

            switch (Math.Round((clearText + 0.1d) / 2d))
            {
                case 1:
                    text = "Tetris!";
                    break;
                case 2:
                    text = "T-Spin Single!";
                    break;
                case 3:
                    text = "T-Spin Double!";
                    break;
                case 4:
                    text = "T-Spin Triple!";
                    break;
                default:
                    text = "";
                    break;
            }
            if (clearText % 2 == 0)
                DrawText("Back to back", new Vector2i((int)Window.WINDOW_WIDTH / 2, clearLineY - 40), alpha: (byte)clearTextOpacity);

            DrawText(text, new Vector2i((int)Window.WINDOW_WIDTH / 2, clearLineY), alpha: (byte)clearTextOpacity);

            if (clearTextOpacity > 180) clearTextOpacity -= Time.deltaTime * 75;
            else clearTextOpacity -= Time.deltaTime * 150;

            if (clearTextOpacity < 100)
            {
                clearTextOpacity = 0;
                clearText = 0;
            }
        }

        private void DrawText(string text, Vector2i pos, bool centered = true, byte alpha = 255, uint fontSize = 0)
        {
            Text txt = new Text(text, Assets.Font);
        
            int xOffset = (centered) ? (int)-txt.GetLocalBounds().Width / 2 : 0;
            txt.Position = new SFML.System.Vector2f(pos.x + xOffset, pos.y);
            txt.FillColor = new Color(255, 255, 255, alpha);

            if (fontSize != 0) txt.CharacterSize = fontSize;

            Window.RenderWindow.Draw(txt);
        }
    }
}
