using System.Threading;

namespace Week_14_MazeGameTwo
{
    internal class Program
    {
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

        static int playerRow = 8;
        static int playerCol = 1;


        static void Main(string[] args)
        {
            // Perform DFS to find the path
            List<(int, int)> path = new List<(int, int)>();
            bool foundExit = DFS(playerRow, playerCol, path, new HashSet<(int, int)>());

            if (foundExit)
            {
                Console.WriteLine("Path to exit found! Animating solution...");
                AnimatePath(path);
            }
            else
            {
                Console.WriteLine("No path to the exit could be found.");
            }
        }

        // DFS function to find the exit
        static bool DFS(int row, int col, List<(int, int)> path, HashSet<(int, int)> visited)
        {
            // If out of bounds or already visited or hit a wall, return false
            if (row < 0 || row >= maze.GetLength(0) || col < 0 || col >= maze.GetLength(1) || maze[row, col] == '#' || visited.Contains((row, col)))
            {
                return false;
            }

            // Add current position to the path and mark as visited
            path.Add((row, col));
            visited.Add((row, col));

            // Check if we reached the exit
            if (maze[row, col] == 'E')
            {
                return true;
            }

            // Explore neighbors: up, down, left, right
            if (DFS(row - 1, col, path, visited) ||  // Up
                DFS(row + 1, col, path, visited) ||  // Down
                DFS(row, col - 1, path, visited) ||  // Left
                DFS(row, col + 1, path, visited))    // Right
            {
                return true;
            }

            // Backtrack if no path found
            path.RemoveAt(path.Count - 1);
            return false;
        }

        // Function to animate the path
        static void AnimatePath(List<(int, int)> path)
        {
            foreach ((int row, int col) in path)
            {
                // Update player position on the maze
                maze[playerRow, playerCol] = ' ';  // Clear previous position
                playerRow = row;
                playerCol = col;
                maze[playerRow, playerCol] = 'C';  // Update current position

                // Display the maze
                PrintMaze();
                Thread.Sleep(300);  // Pause for animation
            }

            Console.WriteLine("Congratulations! The AI has reached the exit.");
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
    }
}
