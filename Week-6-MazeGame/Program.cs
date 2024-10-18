namespace Week_6_MazeGame
{
    internal class Program
    {
        // Maze dimensions and setup (10x10)
        static char[,] maze = {
        { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
        { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' },
        { '#', ' ', '#', ' ', '#', ' ', '#', '#', ' ', '#' },
        { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
        { '#', ' ', '#', '#', '#', '#', ' ', '#', ' ', '#' },
        { '#', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', '#' },
        { '#', '#', '#', ' ', '#', '#', '#', '#', ' ', '#' },
        { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' },
        { '#', 'C', '#', ' ', '#', '#', '#', '#', 'E', '#' },
        { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
    };

        // Player's current position (starting point at 'C')
        static int playerRow = 8;
        static int playerCol = 1;

        static void Main(string[] args)
        {
            bool gameRunning = true;

            // Game loop
            while (gameRunning)
            {
                // Display the maze
                PrintMaze();

                // Get the player's input and move
                gameRunning = MovePlayer();
            }

            Console.WriteLine("Congratulations! You've reached the exit.");
        }

        // Function to print the maze
        static void PrintMaze()
        {
            Console.Clear();
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write(maze[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        // Function to handle player movement
        static bool MovePlayer()
        {
            Console.WriteLine("Choose your move (up/down/left/right):");
            string move = Console.ReadLine().ToLower();

            // Store the current position
            int newRow = playerRow;
            int newCol = playerCol;

            switch (move)
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "left":
                    newCol--;
                    break;
                case "right":
                    newCol++;
                    break;
                default:
                    Console.WriteLine("Invalid move. Please enter 'up', 'down', 'left', or 'right'.");
                    return true;  // Continue the game
            }

            // Check if the new position is within bounds and not a wall
            if (IsValidMove(newRow, newCol))
            {
                // Move the player to the new position
                maze[playerRow, playerCol] = ' ';  // Clear the old position
                playerRow = newRow;
                playerCol = newCol;

                // Check if the player reached the exit
                if (maze[playerRow, playerCol] == 'E')
                {
                    return false;  // End the game
                }

                maze[playerRow, playerCol] = 'C';  // Mark the new position
            }
            else
            {
                Console.WriteLine("You can't move there!");
            }

            return true;  // Continue the game
        }

        // Function to validate the move (checks if it's a wall or out of bounds)
        static bool IsValidMove(int row, int col)
        {
            if (row >= 0 && row < maze.GetLength(0) && col >= 0 && col < maze.GetLength(1))
            {
                return maze[row, col] != '#';  // Valid if it's not a wall
            }
            return false;
        }
    }
}
