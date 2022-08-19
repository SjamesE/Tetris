namespace Tetris
{
    public class App
    {
        public static readonly int TARGET_FPS = 144;
        public static readonly float FRAME_TIME = 1f / TARGET_FPS;

        private Draw draw = new Draw();
        private MainLogic mainLogic = new MainLogic();

        /// <summary>
        /// App core loop
        /// </summary>
        public void Run()
        {
            Assets.LoadAssets();

            float timeTillUpdate = FRAME_TIME;
            //Window.RenderWindow.KeyPressed  += Input.OnKeyPress;
            //Window.RenderWindow.KeyReleased += Input.OnKeyReleased;

            while (Window.RenderWindow.IsOpen)
            {
                Time.Update();

                if (timeTillUpdate < Time.deltaTime)
                {
                    Input.Update();
                    Update();
                    Time.NextFrame();
                }
            }
        }

        /// <summary>
        /// Gets called once per frame
        /// </summary>
        private void Update()
        {
            Window.RenderWindow.DispatchEvents();

            mainLogic.Update();
            draw.Update(mainLogic);
        }
    }
}
