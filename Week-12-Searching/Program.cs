using System.Diagnostics;

namespace Week_12_Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Generate a sorted dataset for binary and interpolation search
            int size = 1000000;
            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = i + 1;
            }

            // Value to search
            int target = 987654;

            Console.WriteLine("Searching for value: " + target);

            // Linear Search
            Stopwatch stopwatch = Stopwatch.StartNew();
            int linearResult = LinearSearch(data, target);
            stopwatch.Stop();
            Console.WriteLine($"Linear Search: Found at index {linearResult}, Time: {stopwatch.Elapsed.TotalMilliseconds} ms");

            // Binary Search
            stopwatch.Restart();
            int binaryResult = BinarySearch(data, target);
            stopwatch.Stop();
            Console.WriteLine($"Binary Search: Found at index {binaryResult}, Time: {stopwatch.Elapsed.TotalMilliseconds} ms");

            // Interpolation Search
            stopwatch.Restart();
            int interpolationResult = InterpolationSearch(data, target);
            stopwatch.Stop();
            Console.WriteLine($"Interpolation Search: Found at index {interpolationResult}, Time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }

        // Linear Search Algorithm
        static int LinearSearch(int[] data, int target)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == target)
                {
                    return i;
                }
            }
            return -1; // Not found
        }

        // Binary Search Algorithm
        static int BinarySearch(int[] data, int target)
        {
            int left = 0, right = data.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (data[mid] == target)
                {
                    return mid;
                }
                else if (data[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1; // Not found
        }

        // Interpolation Search Algorithm
        static int InterpolationSearch(int[] data, int target)
        {
            int low = 0, high = data.Length - 1;

            while (low <= high && target >= data[low] && target <= data[high])
            {
                if (data[low] == data[high])
                {
                    if (data[low] == target)
                        return low;
                    else
                        return -1;
                }

                // Estimate position, ensuring it doesn't exceed array bounds
                int pos = low + (int)(((long)(target - data[low]) * (high - low)) / (data[high] - data[low]));

                // Ensure the calculated position is within bounds
                if (pos < low || pos > high)
                {
                    return -1; // Position outside bounds
                }

                if (data[pos] == target)
                {
                    return pos;
                }
                else if (data[pos] < target)
                {
                    low = pos + 1;
                }
                else
                {
                    high = pos - 1;
                }
            }
            return -1; // Not found
        }
    }
}

