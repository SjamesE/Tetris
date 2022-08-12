using SFML.Graphics;

namespace Tetris
{
    public class Draw
    {
        private Color backgroundColor;

        public void Update()
        {
            Window.RenderWindow.Clear(backgroundColor);
            Window.RenderWindow.Display();
        }
    }
}
