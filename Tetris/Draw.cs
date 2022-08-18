using SFML.Graphics;
using Utility;

namespace Tetris
{
    public class Draw
    {
        private readonly Color backgroundColor = Color.Black;
        private readonly Vector2i offset = new Vector2i(147, 621);

        public void Update(List<List<int>> gridData)
        {
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

            Window.RenderWindow.Display();
        }
    }
}
