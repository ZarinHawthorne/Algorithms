# Big O notation methods

### Week 1

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
