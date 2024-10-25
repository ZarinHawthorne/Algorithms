namespace Week_7_BagDataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bag = new Bag<int>();

            // Add elements to the bag
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
            bag.Add(4);
            bag.Add(5);

            // Print elements in random order using iterator
            var iterator = bag.Iterator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }
    }
}
