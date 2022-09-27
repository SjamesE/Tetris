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

            try
            {
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
            catch (Exception e)
            {
                string message = "An error has occured: \n\n    " + e.Message + "\n\n" + e.StackTrace;
                string caption = "Unexpected Error";
            
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
