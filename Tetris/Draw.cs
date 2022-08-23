using SFML.Graphics;
using Utility;

namespace Tetris
{
    public class Draw
    {
        private readonly Color backgroundColor = Color.Black;
        private readonly Vector2i gridOffset = new Vector2i(147, 621);
        private readonly Vector2i nextOffset = new Vector2i(503, 88);
        private readonly int textPosL = 70;
        private readonly int textPosR = 535;

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

                sprite = new Sprite(Assets.Preview[next]);
                sprite.Position = new SFML.System.Vector2f(nextOffset.x + offX, nextOffset.y + 82 * i);
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

            Text levelNo = new Text(mainLogic.Level.ToString(), Assets.Font);
            FloatRect fr5 = levelNo.GetLocalBounds();
            levelNo.Position = new SFML.System.Vector2f(textPosR - fr5.Width / 2 - 10, 530);
            levelNo.CharacterSize = 80;
            Window.RenderWindow.Draw(levelNo);

            Window.RenderWindow.Display();
        }
    }
}
