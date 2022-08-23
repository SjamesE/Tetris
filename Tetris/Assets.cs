using System;
using System.IO;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;

namespace Tetris
{
    /// <summary>
    /// Class for handling IO and storing the game assets
    /// </summary>
    public static class Assets
    {
        public static Texture Background { get; private set; }
        public static List<Texture> Tetrominos { get; private set; }
        public static List<Texture> Block { get; private set; }
        public static List<Texture> Preview { get; private set; }
        public static Font Font { get; private set; }

        static Assets()
        {
            Tetrominos = new List<Texture>();
            Block = new List<Texture>();
            Preview = new List<Texture>();
        }

        public static void LoadAssets()
        {
            // Load Background Texture
            Background = new Texture("Assets/Background.png");

            // Load Block Textures
            Block.Add(new Texture("Assets/blocks32.png", new IntRect(256, 0, 32, 32)));
            for (int i = 0; i < 8; i++)
            {
                Block.Add(new Texture("Assets/blocks32.png", new IntRect(i * 32, 0, 32, 32)));
            }

            // Load Preview
            for (int i = 0; i < 5; i++)
            {
                Preview.Add(new Texture("Assets/Prev_Tetromino.png", new IntRect(i * 96, 0, 96, 64)));
            }
            Preview.Add(new Texture("Assets/Prev_Tetromino.png", new IntRect(480, 0, 64, 64)));
            Preview.Add(new Texture("Assets/Prev_Tetromino.png", new IntRect(545, 16, 128, 32)));

            // Fix order
            Texture temp = Preview[2];
            Preview[2] = Preview[3];
            Preview[3] = temp;

            // Load font
            Font = new Font("Assets/Font.ttf");
        }
    }
}
