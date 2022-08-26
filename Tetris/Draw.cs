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
            Text scoreText = new Text("Score", Assets.Font);
            FloatRect fr = scoreText.GetLocalBounds();
            scoreText.Position = new SFML.System.Vector2f(textPosL - fr.Width / 2, 200);
            Window.RenderWindow.Draw(scoreText);

            Text score = new Text(mainLogic.score.Total.ToString(), Assets.Font);
            FloatRect fr1 = score.GetLocalBounds();
            score.Position = new SFML.System.Vector2f(textPosL - fr1.Width / 2, 230);
            Window.RenderWindow.Draw(score);

            // Draw Next & Hold text
            Text nextTxt = new Text("Next", Assets.Font);
            FloatRect fr2 = nextTxt.GetLocalBounds();
            nextTxt.Position = new SFML.System.Vector2f(textPosR - fr2.Width / 2, 25);
            Window.RenderWindow.Draw(nextTxt);

            Text hold = new Text("Hold", Assets.Font);
            FloatRect fr3 = hold.GetLocalBounds();
            hold.Position = new SFML.System.Vector2f(textPosL - fr3.Width / 2, 25);
            Window.RenderWindow.Draw(hold);

            // Draw Level
            Text level = new Text("Level", Assets.Font);
            FloatRect fr4 = level.GetLocalBounds();
            level.Position = new SFML.System.Vector2f(textPosR - fr4.Width / 2, 500);
            Window.RenderWindow.Draw(level);

            Text levelNo = new Text(mainLogic.Level.Lvl.ToString(), Assets.Font);
            FloatRect fr5 = levelNo.GetLocalBounds();
            levelNo.Position = new SFML.System.Vector2f(textPosR - fr5.Width / 2 - 10, 530);
            levelNo.CharacterSize = 80;
            Window.RenderWindow.Draw(levelNo);

            // Draw LinesTillLvlUp
            Text lvlUpText = new Text("Lvl up in", Assets.Font);
            FloatRect fr6 = lvlUpText.GetLocalBounds();
            lvlUpText.Position = new SFML.System.Vector2f(textPosL - fr6.Width / 2, 280);
            Window.RenderWindow.Draw(lvlUpText);

            Text lvlUpNo = new Text(mainLogic.Level.LinesLeft.ToString() + "Lines", Assets.Font);
            FloatRect fr7 = lvlUpNo.GetLocalBounds();
            lvlUpNo.Position = new SFML.System.Vector2f(textPosL - fr7.Width / 2, 310);
            Window.RenderWindow.Draw(lvlUpNo);

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

            switch (Math.Round(clearText / 2d))
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
            {
                Text backToBack = new Text("Back to back", Assets.Font);
                FloatRect fr = backToBack.GetLocalBounds();
                backToBack.Position = new SFML.System.Vector2f(Window.WINDOW_WIDTH / 2 - fr.Width / 2, clearLineY - 40);
                backToBack.FillColor = new Color(255, 255, 255, (byte)clearTextOpacity);
                Window.RenderWindow.Draw(backToBack);
            }

            Text ClearLineText = new Text(text, Assets.Font);
            FloatRect fr1 = ClearLineText.GetLocalBounds();
            ClearLineText.Position = new SFML.System.Vector2f(Window.WINDOW_WIDTH / 2 - fr1.Width / 2, clearLineY);
            ClearLineText.FillColor = new Color(255, 255, 255, (byte)clearTextOpacity);
            Window.RenderWindow.Draw(ClearLineText);

            if (clearTextOpacity > 180) clearTextOpacity -= Time.deltaTime * 75;
            else clearTextOpacity -= Time.deltaTime * 150;

            if (clearTextOpacity < 100)
            {
                clearTextOpacity = 0;
                clearText = 0;
            }
        }
    }
}
