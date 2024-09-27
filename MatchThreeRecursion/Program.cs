namespace Week_3_MatchThreeRecursion
{
    internal class Program
    {
        static int rows = 4;
        static int cols = 5;
        static int[,] grid = new int[rows, cols];
        static Random random = new Random();

        static void Main(string[] args)
        {
            InitializeGrid();
            PrintGrid();

            while (true)
            {
                Console.WriteLine("\nEnter a row and column to remove (e.g., 2 1): ");
                string[] input = Console.ReadLine().Split();
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);

                RemoveAndDrop(row, col);
                Console.WriteLine("\nAfter Removal and Drop:");
                PrintGrid();

                while (CheckMatches())
                {
                    Console.WriteLine("\nAfter Clearing Matches and Drop:");
                    PrintGrid();
                }
            }
        }

        static void InitializeGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = random.Next(1, 4); // Randomly fill grid with numbers 1, 2, or 3
                }
            }
        }

        static void PrintGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void RemoveAndDrop(int row, int col)
        {
            if (grid[row, col] == 0) return;

            // Remove the number at the selected position
            grid[row, col] = 0;

            // Recursive drop for each column
            DropColumn(col);
        }

        static void DropColumn(int col)
        {
            for (int row = rows - 1; row > 0; row--)
            {
                if (grid[row, col] == 0)
                {
                    // Find the next non-zero value above and move it down
                    for (int r = row - 1; r >= 0; r--)
                    {
                        if (grid[r, col] != 0)
                        {
                            grid[row, col] = grid[r, col];
                            grid[r, col] = 0;
                            break;
                        }
                    }
                }
            }

            // Refill the top row with new random number if it's 0
            if (grid[0, col] == 0)
            {
                grid[0, col] = random.Next(1, 4);
            }
        }

        static bool CheckMatches()
        {
            bool matchFound = false;
            bool[,] toRemove = new bool[rows, cols];

            // Check horizontal matches
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    if (grid[i, j] != 0 && grid[i, j] == grid[i, j + 1] && grid[i, j] == grid[i, j + 2])
                    {
                        toRemove[i, j] = toRemove[i, j + 1] = toRemove[i, j + 2] = true;
                        matchFound = true;
                    }
                }
            }

            // Check vertical matches
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows - 2; i++)
                {
                    if (grid[i, j] != 0 && grid[i, j] == grid[i + 1, j] && grid[i, j] == grid[i + 2, j])
                    {
                        toRemove[i, j] = toRemove[i + 1, j] = toRemove[i + 2, j] = true;
                        matchFound = true;
                    }
                }
            }

            // Remove matched cells
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (toRemove[i, j])
                    {
                        grid[i, j] = 0;
                    }
                }
            }

            // Drop columns again after clearing matches
            if (matchFound)
            {
                for (int j = 0; j < cols; j++)
                {
                    DropColumn(j);
                }
            }

            return matchFound;
        }
    }
}
