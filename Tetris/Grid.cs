using Utility;

namespace Tetris
{
    public class Grid
    {
        // 2D list of colors
        public List<List<int>> Data { get; private set; } = new List<List<int>>();

        public Grid()
        {
            // Initialize Grid Data
            for (int i = 0; i < 22; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < 10; j++) list.Add(0);
                Data.Add(list);
            }
        }

        // Place tetromino - return number of cleared lines
        public void Place(Tetromino tetromino)
        {
            // Get place position
            Vector2i placePos = GetPlacePos(tetromino);

            // Go through each element of the tetromino mesh
            // If mesh not empty (false) place the tetromino type (color) in the grid data
            for (int y = 0; y < tetromino.size; y++)
            {
                for (int x = 0; x < tetromino.size; x++)
                {
                    int index = y * tetromino.size + x;

                    // Continue if tetromino mesh at index is empty (false)
                    if (!tetromino.data[index]) continue;

                    if (placePos.y + y >= 22) return;

                    Data[placePos.y + y][placePos.x + x] = tetromino.type;
                }
            }
        }

        /// <summary>
        /// Return true if tetromino is overlapping grid mesh
        /// </summary>
        /// <param name="tetromino"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        /// <returns></returns>
        public bool CheckCollisionAt(Tetromino tetromino, int dX, int dY)
        {
            // Compare the mesh of the tetromino to the mesh of the grid
            for (int y = 0; y < tetromino.size; y++)
            {
                for (int x = 0; x < tetromino.size; x++)
                {
                    int index = y * tetromino.size + x;

                    // Continue if tetromino mesh at index is empty (false)
                    if (!tetromino.data[index]) continue;

                    int _x = tetromino.pos.x + x + dX;
                    int _y = tetromino.pos.y + y + dY;

                    // If tetromino mesh is outside of the playing area return true
                    if (_x < 0 || _x > 9 || _y < 0) return true;

                    // Ignore any tetromino mesh that is above the playing area
                    if (_y > 19) continue;

                    // Return true if overlap found
                    if (Data[_y][_x] != 0) return true;
                }
            }

            return false;
        }

        public Vector2i GetPlacePos(Tetromino tetromino)
        {
            // For each iteration go one row down and check for collision
            // Return when collision was found
            for (int i = 0; i < 22; i++)
            {
                if (CheckCollisionAt(tetromino, 0, -i))
                    return new Vector2i(tetromino.pos.x, tetromino.pos.y - i + 1);
            }

            throw new Exception("No ghost pos was found");
        }

        public List<int> CheckFullLines()
        {
            List<int> clearedLines = new();

            for (int i = 0; i < 20; i++)
            {
                // Check if line is complete
                bool isComplete = true;
                foreach (var square in Data[i])
                {
                    if (square == 0)
                    {
                        isComplete = false;
                        break;
                    }
                }

                // Add completed lines to a list
                if (isComplete)
                {
                    clearedLines.Add(i);
                }
            }

            return clearedLines;
        }

        public void ClearLines(List<int> linesToClear)
        {
            // Go trough the list and clear every line
            for (int i = 0; i < linesToClear.Count; i++)
            {
                ClearLine(linesToClear[i] - i);

            }
        }

        private void ClearLine(int i)
        {
            // Shift all rows above the i-th line one row down
            for (int j = 0; j < 20; j++)
            {
                if ((i + j) == 19) break;
                Data[i + j] = Data[i + j + 1];
            }

            // Create a new line for the last row
            List<int> list = new List<int>();
            for (int j = 0; j < 10; j++) list.Add(0);

            Data[19] = list;
        }
    }
}
