
namespace Tetris
{
    public class App
    {
        public static readonly int TARGET_FPS = 144;
        public static readonly float FRAME_TIME = 1f / TARGET_FPS;

        private Draw draw = new Draw();

        /// <summary>
        /// App core loop
        /// </summary>
        public void Run()
        {
            Assets.LoadAssets();

            float timeTillUpdate = FRAME_TIME;

            while (Window.RenderWindow.IsOpen)
            {
                Time.Update();

                if (timeTillUpdate < 0)
                {
                    timeTillUpdate = FRAME_TIME;
                    Update();
                }
                else timeTillUpdate -= Time.deltaTime;
            }
        }

        /// <summary>
        /// Gets called once per frame
        /// </summary>
        private void Update()
        {
            Window.RenderWindow.DispatchEvents();
            draw.Update();
        }
    }
}
