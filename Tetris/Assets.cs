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

        public static void LoadAssets()
        {
            Tetrominos = new List<Texture>();
            Block = new List<Texture>();

            // Load Background Texture
            Background = new Texture("Assests/Background.png");

            // Load Block Textures
            Block.Append(new Texture("Assests/blocks32.png", new IntRect(256, 0, 32, 32)));
            for (int i = 0; i < 8; i++)
            {
                Block.Append(new Texture("Assests/blocks32.png", new IntRect(i * 32, 0, 32, 32)));
            }
        }
    }
}
