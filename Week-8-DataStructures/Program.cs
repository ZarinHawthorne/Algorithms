namespace Week_8_DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Array Example
            int[] array = new int[5];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 10;
            }

            Console.WriteLine("Array Elements:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            // Dictionary Example (Map)
            Dictionary<string, int> dictionary = new Dictionary<string, int>
        {
            { "apple", 1 },
            { "banana", 2 },
            { "cherry", 3 }
        };

            Console.WriteLine("\nDictionary Elements:");
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            // Stack Example
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("\nStack Elements:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            // Queue Example
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Console.WriteLine("\nQueue Elements:");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
