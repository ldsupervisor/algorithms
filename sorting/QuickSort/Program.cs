// Time complexity: O(n log n) on average, O(n^2) in the worst case
static void QuickSortFunction(int[] array, int lowIndex, int highIndex)
{
    if (lowIndex < highIndex)
    {
        // pivotIndex is partitioning index, array[pivotIndex] is now at right place
        int pivotIndex;
        Partition(array, lowIndex, highIndex, out pivotIndex);

        QuickSortFunction(array, lowIndex, pivotIndex - 1);
        QuickSortFunction(array, pivotIndex + 1, highIndex);
    }
}

static void Partition(int[] array, int low, int high, out int pivotIndex)
{
    // Pivot is the last element in the divided array
    int pivot = array[high];
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        if (array[j] < pivot)
        {
            i++;
            (array[i], array[j]) = (array[j], array[i]); // Swap
        }
    }

    (array[i + 1], array[high]) = (array[high], array[i + 1]);
    pivotIndex = i + 1;
}

int[] data = { 5, 4, 67, 4, 5, 6, 6 };

Console.WriteLine("Initial table: " + string.Join(", ", data));
QuickSortFunction(data, 0, data.Length - 1);
Console.WriteLine("After sorting: " + string.Join(", ", data));
