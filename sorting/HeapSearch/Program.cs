// Examplary code demonstrating searching in a min-heap using recursion in C#
// Time complexity: O(nlog n) on average and worst case, best case O(n)
int[] heap = { 2, 3, 5, 7, 8, 10, 12 };

Console.WriteLine("Searching for a 10: " + HeapSearch(heap, 0, 10)); // True
Console.WriteLine("Searching for a 6: " + HeapSearch(heap, 0, 6));   // False
Console.WriteLine("Searching for a 1: " + HeapSearch(heap, 0, 1));   // False

// Recursive function to search in a min-heap
bool HeapSearch(int[] heap, int index, int target)
{
    if (index >= heap.Length)
        return false;

    if (heap[index] == target)
        return true;

    // Optimization: if current node is greater than target, no need to search further
    if (heap[index] > target)
        return false;

    return HeapSearch(heap, 2 * index + 1, target) || HeapSearch(heap, 2 * index + 2, target);
}