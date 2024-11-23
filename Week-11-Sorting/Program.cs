using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Week_11_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load data from a file
            var scores = LoadScores("scores.txt");

            // Algorithms
            SortAndDisplay("Bubble Sort", scores, BubbleSort);
            SortAndDisplay("Insertion Sort", scores, InsertionSort);
            SortAndDisplay("Selection Sort", scores, SelectionSort);
            SortAndDisplay("Heap Sort", scores, HeapSort);
            SortAndDisplay("Quick Sort", scores, QuickSort);
            SortAndDisplay("Merge Sort", scores, MergeSort);

            Console.WriteLine("\nSummary:");
            DisplaySummary();
        }

        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                        minIndex = j;
                }
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }

        static void HeapSort(int[] array)
        {
            void Heapify(int n, int i)
            {
                int largest = i, left = 2 * i + 1, right = 2 * i + 2;
                if (left < n && array[left] > array[largest]) largest = left;
                if (right < n && array[right] > array[largest]) largest = right;
                if (largest != i)
                {
                    (array[i], array[largest]) = (array[largest], array[i]);
                    Heapify(n, largest);
                }
            }

            for (int i = array.Length / 2 - 1; i >= 0; i--)
                Heapify(array.Length, i);
            for (int i = array.Length - 1; i > 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);
                Heapify(i, 0);
            }
        }

        static void QuickSort(int[] array)
        {
            void Sort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int pi = Partition(arr, low, high);
                    Sort(arr, low, pi - 1);
                    Sort(arr, pi + 1, high);
                }
            }

            int Partition(int[] arr, int low, int high)
            {
                int pivot = arr[high], i = low - 1;
                for (int j = low; j < high; j++)
                {
                    if (arr[j] < pivot)
                    {
                        i++;
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }
                }
                (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
                return i + 1;
            }

            Sort(array, 0, array.Length - 1);
        }

        static void MergeSort(int[] array)
        {
            void Merge(int[] arr, int l, int m, int r)
            {
                int n1 = m - l + 1, n2 = r - m;
                var L = new int[n1];
                var R = new int[n2];

                Array.Copy(arr, l, L, 0, n1);
                Array.Copy(arr, m + 1, R, 0, n2);

                int i = 0, j = 0, k = l;
                while (i < n1 && j < n2) arr[k++] = L[i] <= R[j] ? L[i++] : R[j++];
                while (i < n1) arr[k++] = L[i++];
                while (j < n2) arr[k++] = R[j++];
            }

            void Sort(int[] arr, int l, int r)
            {
                if (l < r)
                {
                    int m = l + (r - l) / 2;
                    Sort(arr, l, m);
                    Sort(arr, m + 1, r);
                    Merge(arr, l, m, r);
                }
            }

            Sort(array, 0, array.Length - 1);
        }

        static void SortAndDisplay(string algorithmName, int[] original, Action<int[]> sortAlgorithm)
        {
            int[] data = (int[])original.Clone();
            Stopwatch stopwatch = Stopwatch.StartNew();

            sortAlgorithm(data);

            stopwatch.Stop();
            Console.WriteLine($"{algorithmName}: {stopwatch.ElapsedMilliseconds} ms");
        }

        static void DisplaySummary()
        {
            Console.WriteLine("Algorithm Comparison Summary:");
            Console.WriteLine("Algorithm    | Time (ms)");
            Console.WriteLine("-------------------------");
            // Print algorithm timing results stored during execution
        }

        static int[] LoadScores(string filePath)
        {
            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Assuming the file contains one score per line
                int[] scores = lines.Select(int.Parse).ToArray();

                return scores;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading scores: {ex.Message}");
                return new int[0]; // Return an empty array in case of failure
            }
        }

    }

}
