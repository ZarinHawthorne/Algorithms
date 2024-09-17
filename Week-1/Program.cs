namespace Week_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // O(1)
        public void PrintFirstItem(int[] items)
        {
            if (items.Length > 0)
            {
                Console.WriteLine(items[0]); // Always prints the first item
            }
        }

        // O(n)
        public void PrintAllItems(int[] items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item); // Prints each item in the array
            }
        }

        // O(n^2)
        public void PrintAllPairs(int[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < items.Length; j++)
                {
                    Console.WriteLine($"Pair: ({items[i]}, {items[j]})");
                }
            }
        }
    }
}
