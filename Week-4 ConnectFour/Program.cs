namespace Week_4_ConnectFour
{
    internal class Program
    {
        static int rows = 6;
        static int cols = 7;
        static int[,] grid = new int[rows, cols]; // 0 for empty, 1 for player 1, 2 for player 2
        static int currentPlayer = 1; // Player 1 starts
        static bool gameOver = false;

        static void Main(string[] args)
        {
            while (!gameOver)
            {
                PrintGrid();

                Console.WriteLine($"\nPlayer {currentPlayer}'s turn. Enter a column (0-{cols - 1}) to drop your piece: ");
                int col = int.Parse(Console.ReadLine());

                if (col < 0 || col >= cols || !DropPiece(col))
                {
                    Console.WriteLine("Invalid move! Try again.");
                    continue;
                }

                if (CheckWin())
                {
                    PrintGrid();
                    Console.WriteLine($"\nPlayer {currentPlayer} wins!");
                    gameOver = true;
                }
                else if (CheckDraw())
                {
                    PrintGrid();
                    Console.WriteLine("\nIt's a draw!");
                    gameOver = true;
                }
                else
                {
                    currentPlayer = currentPlayer == 1 ? 2 : 1; // Switch players
                }
            }
        }


        static void PrintGrid()
        {
            Console.Clear();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int j = 0; j < cols; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }

        static bool DropPiece(int col)
        {
            // Start from the bottom row and drop the piece in the lowest empty spot
            for (int row = rows - 1; row >= 0; row--)
            {
                if (grid[row, col] == 0)
                {
                    grid[row, col] = currentPlayer;
                    return true;
                }
            }
            return false; // If the column is full
        }

        static bool CheckWin()
        {
            // Check for 4 in a row horizontally, vertically, and diagonally
            return CheckHorizontal() || CheckVertical() || CheckDiagonal();
        }

        static bool CheckHorizontal()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <= cols - 4; col++)
                {
                    if (grid[row, col] == currentPlayer &&
                        grid[row, col + 1] == currentPlayer &&
                        grid[row, col + 2] == currentPlayer &&
                        grid[row, col + 3] == currentPlayer)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool CheckVertical()
        {
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row <= rows - 4; row++)
                {
                    if (grid[row, col] == currentPlayer &&
                        grid[row + 1, col] == currentPlayer &&
                        grid[row + 2, col] == currentPlayer &&
                        grid[row + 3, col] == currentPlayer)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool CheckDiagonal()
        {
            // Check diagonals (both directions)
            // Check for "\" diagonal (top-left to bottom-right)
            for (int row = 0; row <= rows - 4; row++)
            {
                for (int col = 0; col <= cols - 4; col++)
                {
                    if (grid[row, col] == currentPlayer &&
                        grid[row + 1, col + 1] == currentPlayer &&
                        grid[row + 2, col + 2] == currentPlayer &&
                        grid[row + 3, col + 3] == currentPlayer)
                    {
                        return true;
                    }
                }
            }

            // Check for "/" diagonal (bottom-left to top-right)
            for (int row = 3; row < rows; row++)
            {
                for (int col = 0; col <= cols - 4; col++)
                {
                    if (grid[row, col] == currentPlayer &&
                        grid[row - 1, col + 1] == currentPlayer &&
                        grid[row - 2, col + 2] == currentPlayer &&
                        grid[row - 3, col + 3] == currentPlayer)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CheckDraw()
        {
            // Check if all cells are filled
            for (int col = 0; col < cols; col++)
            {
                if (grid[0, col] == 0) return false; // If there's any empty spot, it's not a draw yet
            }
            return true;
        }
    }
}
