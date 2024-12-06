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

# Week 12

## Searching

Linear Search Description: Linear search sequentially checks each element of the array until the target element is found or the end of the array is reached. It does not require the data to be sorted. 
Best Case: 𝑂 ( 1 ) (Target found at the first position) 
Worst Case: 𝑂 ( 𝑛 ) (Target is at the last position or not found)

Binary Search Description: Binary search works on sorted arrays by repeatedly dividing the search interval in half. It compares the middle element with the target and narrows the search to the appropriate half until the element is found or the interval is empty. 
Best Case: 𝑂 ( 1 ) (Target found at the middle) 
Worst Case: 𝑂 ( log ⁡ 𝑛 ) (Requires repeatedly halving the search space)

Interpolation Search Description: Interpolation search works on sorted arrays. It improves upon binary search by estimating the likely position of the target element based on its value relative to the range of the current search interval. It is efficient for uniformly distributed data. 
Best Case: 𝑂 ( 1 ) (Target found at the predicted position) 
Worst Case: 𝑂 ( 𝑛 ) (If the data is not uniformly distributed)

Why is Linear Search the Slowest? 
Linear search examines every element until the target is found, resulting in a runtime directly proportional to the array size. Unlike binary or interpolation, it doesn’t exploit any properties of sorted data to reduce the search range.

What is the Difference Between Binary and Interpolation Search? 
Binary Search divides the search range in half regardless of the data distribution. It is robust and predictable, performing well even when the data is not uniformly distributed. Interpolation Search predicts the position of the target using a formula based on the distribution of the data. This makes it faster than binary search for uniformly distributed data but less reliable for uneven distributions.
