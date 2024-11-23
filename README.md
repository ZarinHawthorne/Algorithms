# Algorithms  Readme

This is my  Algorithms Repo.
Enjoy I guess.

# Week 1

## Big O notation methods

## O(1)
The execution time of this function does not depend on the size of the input array items.
Regardless of whether the array has 1 element, 1000 elements, or no elements, the function performs a fixed number of operations: checking the condition and possibly printing the first item.
Hence, the time complexity is O(1).

## O(n)
The function iterates through the array items once, performing one print operation per element.
The number of operations is directly proportional to the size of the input array items.
For an array of size n, the function will perform n print operations.
Hence, the time complexity is O(n).

## O(n²)
This function uses a nested loop where the outer loop iterates over all elements of items, and for each iteration of the outer loop, the inner loop also iterates over all elements of items.
The total number of iterations is the product of the sizes of the two loops: n * n = n².
For an array of size n, the function prints all possible pairs of elements in the array, resulting in n² print operations.
Hence, the time complexity is O(n²).


# Week 5

## Fisher-Yates Shuffle

The code correctly implements the Fisher-Yates Shuffle to randomize the order of cards in the deck before the game begins. 
By leveraging this shuffle, the program ensures that the deck starts in a fair and unbiased state, demonstrating an understanding of the algorithm and its importance in randomization.


# Week 8

## Data Structures

The code demonstrates an understanding of various fundamental data structures and their unique behaviors through practical examples. 
It uses an array to store and iterate over a fixed-size collection of integers, showcasing its ability to provide direct indexed access. 
A dictionary (map) is used to associate unique keys with values, highlighting its suitability for key-value pair storage and fast lookups. 
The stack is employed to demonstrate Last-In-First-Out (LIFO) behavior by pushing and popping elements in reverse order of insertion. Similarly, a queue is utilized to showcase First-In-First-Out (FIFO) behavior, where elements are dequeued in the order they were enqueued. 
These implementations illustrate a solid grasp of how each data structure is designed to solve specific problems efficiently and with appropriate access patterns.

# Week 11

## Sorting (The display doesn't work properly, never did a program that reads from a txt file.)

Bubble Sort Description: Repeatedly steps through the list, compares adjacent elements, and swaps them if out of order. 
Best Case: 𝑂(𝑛) (already sorted) 
Worst Case: 𝑂(𝑛2) (reversed order)

Insertion Sort Description: Builds the sorted list one element at a time by comparing and inserting in the correct position. 
Best Case: 𝑂(𝑛) (already sorted) 
Worst Case: 𝑂 (𝑛2) (reversed order)

Selection Sort Description: Divides the array into sorted and unsorted sections. Finds the smallest element in the unsorted section and swaps it with the first unsorted element. 
Best/Worst Case: 𝑂(𝑛2)

Heap Sort Description: Builds a max heap and repeatedly extracts the maximum element to sort. 
Best/Worst Case: 𝑂(𝑛log𝑛)

Quick Sort Description: Divides the array into smaller partitions using a pivot element, then recursively sorts the partitions. 
Best Case: 𝑂(𝑛log ⁡𝑛)
Worst Case: 𝑂(𝑛2) (poor pivot choices)

Merge Sort Description: Recursively splits the array into halves, sorts, and merges them. 
Best/Worst Case: 𝑂 (𝑛log𝑛)
