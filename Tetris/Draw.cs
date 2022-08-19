using SFML.Graphics;
using Utility;

namespace Tetris
{
    public class Draw
    {
        private readonly Color backgroundColor = Color.Black;
        private readonly Vector2i offset = new Vector2i(147, 621);

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
                    sprite.Position = new SFML.System.Vector2f(offset.x + 32 * x, offset.y - 32 * y);
                    Window.RenderWindow.Draw(sprite);
                }
            }

            for (int y = 0; y < currTetromino.size; y++)
            {
                for (int x = 0; x < currTetromino.size; x++)
                {
                    int index = y * currTetromino.size + x;
                    if (!currTetromino.data[index]) continue;

                    sprite = new Sprite(Assets.Block[currTetromino.type]);
                    sprite.Position = new SFML.System.Vector2f(offset.x + 32 * (currTetromino.pos.x + x), offset.y - 32 * (currTetromino.pos.y + y));
                    Window.RenderWindow.Draw(sprite);
                }
            }

            Window.RenderWindow.Display();
        }
    }
}
