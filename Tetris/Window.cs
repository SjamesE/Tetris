using SFML.Graphics;
using SFML.Window;

namespace Tetris
{
    public static class Window
    {
        public static RenderWindow RenderWindow { get; private set; }

        public static uint WINDOW_WIDTH = 600;
        public static uint WINDOW_HEIGHT = 665;

        static Window()
        {
            ContextSettings cs = new ContextSettings();
            cs.AntialiasingLevel = 4;

            RenderWindow = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), "Tetris", Styles.Titlebar | Styles.Close, cs);
            RenderWindow.Closed += Close;
            RenderWindow.SetIcon(Assets.Icon.Size.X, Assets.Icon.Size.Y, Assets.Icon.CopyToImage().Pixels);
        }

        private static void Close(object sender, EventArgs e)
        {
            RenderWindow.Close();
        }
    }
}
