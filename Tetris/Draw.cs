using SFML.Graphics;
using Utility;

namespace Tetris
{
    public class Draw
    {
        private readonly SFML.Graphics.Color backgroundColor  = new SFML.Graphics.Color(97, 97, 97);
        private readonly Vector2i gridOffset    = new Vector2i(147, 621);
        private readonly Vector2i nextOffset    = new Vector2i(503, 88);
        private readonly Vector2i holdingOffset = new Vector2i(36, 87);
        private readonly int clearLineY = 250;
        private readonly int textPosL = 70;
        private readonly int textPosR = 535;

        private float clearTextOpacity = 0;
        private int clearText = 0;

        private int radius = 58;
        private SFML.Graphics.Image progressCircleImg;
        private float fillPercent = 0;
        private float targetFillPercent = 0;

        public Draw()
        {
            progressCircleImg = new SFML.Graphics.Image(new SFML.Graphics.Color[(int)(radius * 2 + 1), (int)(radius * 2 + 1)]);
        }

        public void Update(MainLogic mainLogic)
        {
            if (mainLogic.paused)
            {
                Window.RenderWindow.Clear(backgroundColor);
                DrawText("Paused", new Vector2i((int)Window.WINDOW_WIDTH / 2, 200), color: SFML.Graphics.Color.Red, outlineClr: new SFML.Graphics.Color(0, 0, 0, 150), outlineThickness: 1);
                Window.RenderWindow.Display();
                return;
            }

            List<List<int>> gridData = mainLogic.Grid.Data;
            Tetromino currTetromino = mainLogic.CurrTetromino;
            Texture texture = new Texture(1, 1);
            Texture texture2 = new Texture(1, 1);
            bool clrAnim = mainLogic.clrAnim;
            float clrAnimTimer = mainLogic.clrAnimTimer;

            Window.RenderWindow.Clear(backgroundColor);
            Sprite sprite;

            // Draw Background
            sprite = new Sprite(Assets.Background);
            Window.RenderWindow.Draw(sprite);

            // Draw Grid
            DrawGrid(sprite, gridData, mainLogic);

            // Draw curr tetromino and ghost
            if (!mainLogic.clrAnim)
            {
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
                        sprite.Color = new SFML.Graphics.Color(255, 255, 255, 100);
                        Window.RenderWindow.Draw(sprite);
                    }
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
            DrawText("Score", new Vector2i(textPosL, 170));
            DrawText(mainLogic.score.Total.ToString(), new Vector2i(textPosL, 200));

            // Draw Next & Hold text
            DrawText("Next", new Vector2i(textPosR, 25));
            DrawText("Hold", new Vector2i(textPosL, 25));

            // Draw Level and Progress Bar
            DrawText("Level", new Vector2i(textPosR, 500));
            if (mainLogic.Level.Lvl < 9) 
                DrawText(mainLogic.Level.Lvl.ToString(), new Vector2i(textPosR - 13, 544), fontSize: 80);
            else
                DrawText(mainLogic.Level.Lvl.ToString(), new Vector2i(textPosR - 20, 550), fontSize: 70);

            // Bar background
            DrawProgressBar(ref texture2, new Vector2i(475, 535), radius + 2, 20, 1, new SFML.Graphics.Color( 59,  59,  59), new SFML.Graphics.Color( 66,  66,  66), 360);
            targetFillPercent = (1f - (float)mainLogic.Level.LinesLeft / (float)mainLogic.Level.LinesForNextLvl) * 360;
            UpdateLvlBar(ref texture);
            
            // Draw Lines
            DrawText("Lines", new Vector2i(textPosL + 10, 250), fontSize: 25);
            DrawText(mainLogic.score.Lines.ToString(), new Vector2i(textPosL, 280));

            // Draw Tetris
            DrawText("Tetris", new Vector2i(textPosL + 10, 330), fontSize: 25);
            DrawText(mainLogic.score.Tetris.ToString(), new Vector2i(textPosL, 360));

            // Draw TSpinD
            DrawText("TSpin D", new Vector2i(textPosL + 10, 410), fontSize: 25);
            DrawText(mainLogic.score.TSpinD.ToString(), new Vector2i(textPosL, 440));

            // Draw TSpinT
            DrawText("TSpin T", new Vector2i(textPosL + 10, 490), fontSize: 25);
            DrawText(mainLogic.score.TSpinT.ToString(), new Vector2i(textPosL, 520));

            // Draw HighScore
            DrawText("HighScore", new Vector2i(textPosL + 14, 570), fontSize: 25);
            DrawText(mainLogic.HiScore.ToString(), new Vector2i(textPosL, 600));

            // Draw text for multiple lines cleared
            if (clearText == 0)
                clearText = mainLogic.clearText;
            DrawClearLineText();

            // Draw text for game over and new highscore
            if (mainLogic.gameOver)
            {
                if (mainLogic.score.Total > mainLogic.HiScore)
                {
                    DrawText("New Highscore!", new Vector2i((int)Window.WINDOW_WIDTH / 2, 120));
                    DrawText(mainLogic.score.Total.ToString(), new Vector2i((int)Window.WINDOW_WIDTH / 2, 150));
                }

                DrawText("Game Over!"          , new Vector2i((int)Window.WINDOW_WIDTH / 2, 200), color: SFML.Graphics.Color.Red, outlineClr: new SFML.Graphics.Color(0, 0, 0, 150), outlineThickness: 1);
                DrawText("Press 'r' to restart", new Vector2i((int)Window.WINDOW_WIDTH / 2, 230), color: SFML.Graphics.Color.Red, outlineClr: new SFML.Graphics.Color(0, 0, 0, 150), outlineThickness: 1);
            }

            Window.RenderWindow.Display();

            texture.Dispose();
            texture2.Dispose();
        }

        private void UpdateLvlBar(ref Texture texture)
        {
            //if (targetFillPercent == fillPercent) return;

            if (targetFillPercent > fillPercent)
            {
                fillPercent += 1f;

                if (fillPercent > targetFillPercent) fillPercent = targetFillPercent;
            }

            else if (targetFillPercent < fillPercent)
            {
                fillPercent -= 5f;

                if (fillPercent < targetFillPercent) fillPercent = targetFillPercent;
            }

            DrawProgressBar(ref texture, new Vector2i(479, 539), radius - 2, 10, 2, new SFML.Graphics.Color(180, 180, 180), new SFML.Graphics.Color(150, 150, 150), fillPercent);

        }

        private void DrawGrid(Sprite sprite, List<List<int>> gridData, MainLogic mainLogic)
        {
            if (!mainLogic.clrAnim)
            {
                for (int y = 0; y < gridData.Count - 2; y++)
                {
                    for (int x = 0; x < gridData[0].Count; x++)
                    {
                        sprite = new Sprite(Assets.Block[gridData[y][x]]);
                        sprite.Position = new SFML.System.Vector2f(gridOffset.x + 32 * x, gridOffset.y - 32 * y);
                        Window.RenderWindow.Draw(sprite);
                    }
                }
            }
            else
            {
                for (int y = 0; y < gridData.Count - 2; y++)
                {
                    if (mainLogic.fullLines.Contains(y))
                    {
                        for (float x = 0; x < 10; x++)
                        {
                            if (mainLogic.clrAnimTimer < .45f - x * 0.03f)
                                sprite = new Sprite(Assets.Block[0]);
                            else
                                sprite = new Sprite(Assets.Block[8]);

                            sprite.Position = new SFML.System.Vector2f(gridOffset.x + 32 * x, gridOffset.y - 32 * y);
                            Window.RenderWindow.Draw(sprite);
                        }
                    }
                    else
                    {
                        for (int x = 0; x < gridData[0].Count; x++)
                        {
                            sprite = new Sprite(Assets.Block[gridData[y][x]]);
                            sprite.Position = new SFML.System.Vector2f(gridOffset.x + 32 * x, gridOffset.y - 32 * y);
                            Window.RenderWindow.Draw(sprite);
                        }
                    }
                }
            }
        }

        private void DrawProgressBar(ref Texture texture, Vector2i pos, float radius, int width, int borderWidth, SFML.Graphics.Color fillColor, SFML.Graphics.Color borderColor, float fillAngle)
        {
            progressCircleImg = new SFML.Graphics.Image(new SFML.Graphics.Color[(int)(radius * 2 + 1), (int)(radius * 2 + 1)]);

            // Center of the circle
            Vector2i center = pos + new Vector2i((int)radius);

            Vector2 point = new Vector2();

            float step = 360f / (radius * (float)Math.PI * 8);

            for (float angle = 0; angle < fillAngle; angle += step)
            {
                float radAngle = angle * (float)Math.PI / 180;

                int barWidth = borderWidth * 2 + width;

                for (int i = 0; i < barWidth; i++)
                {
                    SFML.Graphics.Color clr = (i < borderWidth || i + 1 > barWidth - borderWidth) ? borderColor : fillColor;

                    point.y = (float)((radius - i) * Math.Cos(radAngle)) * -1;
                    point.x = (float)((radius - i) * Math.Sin(radAngle));

                    progressCircleImg.SetPixel((uint)(radius + point.x), (uint)(radius + point.y), clr);
                }
            }

            texture = new Texture(progressCircleImg);
            Sprite sprite = new Sprite(texture);
            sprite.Position = (SFML.System.Vector2f)pos;

            Window.RenderWindow.Draw(sprite);
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
                DrawText("Back to back", new Vector2i((int)Window.WINDOW_WIDTH / 2, clearLineY - 40), color: new SFML.Graphics.Color(255, 255, 255, (byte)clearTextOpacity));

            DrawText(text, new Vector2i((int)Window.WINDOW_WIDTH / 2, clearLineY), color: new SFML.Graphics.Color(255, 255, 255, (byte)clearTextOpacity));

            if (clearTextOpacity > 180) clearTextOpacity -= Time.deltaTime * 75;
            else clearTextOpacity -= Time.deltaTime * 150;

            if (clearTextOpacity < 100)
            {
                clearTextOpacity = 0;
                clearText = 0;
            }
        }

        private void DrawText(string text, Vector2i pos, bool centered = true, uint fontSize = 0, SFML.Graphics.Color color = new SFML.Graphics.Color(), SFML.Graphics.Color outlineClr = new SFML.Graphics.Color(), float outlineThickness = 0)
        {
            Text txt = new Text(text, Assets.Font);
        
            int xOffset = (centered) ? (int)-txt.GetLocalBounds().Width / 2 : 0;
            txt.Position = new SFML.System.Vector2f(pos.x + xOffset, pos.y);

            if (color.R == 0 && color.G == 0 && color.B == 0 && color.A == 0) color = new SFML.Graphics.Color(255, 255, 255, 255);
            txt.FillColor = color;

            if (outlineClr.R == 0 && outlineClr.G == 0 && outlineClr.B == 0 && outlineClr.A == 0) outlineClr = new SFML.Graphics.Color(0, 0, 0, 255);
            txt.OutlineColor = outlineClr;

            txt.OutlineThickness = outlineThickness;

            if (fontSize != 0) txt.CharacterSize = fontSize;

            Window.RenderWindow.Draw(txt);
        }
    }
}
