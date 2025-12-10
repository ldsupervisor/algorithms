// Insertion Sort implementation in C#.
// Time complexity: O(n^2) in the worse and avarage case, O(n) in the best case.
using System.Diagnostics;
static void Sort(int[] array)
{
    int n = array.Length;
    for (int i = 1; i < n; i++)
    {
        int key = array[i];
        int j = i - 1;

        // Shift elements greater than key to the right
        while (j >= 0 && array[j] > key)
        {
            array[j + 1] = array[j];
            j = j - 1;
        }
        array[j + 1] = key;
    }
}

static void SortWithSwap(int[] array)
{
    int n = array.Length;
    for (int i = 1; i < n; i++)
    {
        int j = i;
        // Swap element until it is in the correct sorted position
        while (j > 0 && array[j] < array[j - 1])
        {
            // Swap operation
            (array[j], array[j - 1]) = (array[j - 1], array[j]);
            j--;
        }
    }
}

// Generate random numbers for the unsorted array
Random random = new Random();
int[] numbers = new int[10];

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(-10, 10);
}

Console.WriteLine("Array before sorting:");
Console.WriteLine(string.Join(" ", numbers) + "\n");

// Create two independent copies the same array
int[] arrayShift = new int[numbers.Length];
int[] arraySwap = new int[numbers.Length];

Array.Copy(numbers, arrayShift, numbers.Length);
Array.Copy(numbers, arraySwap, numbers.Length);

// The sorting method with shift
Stopwatch timeShift = Stopwatch.StartNew();
Console.WriteLine("Standard approach with shift\n");
Sort(arrayShift);
timeShift.Stop();

Console.WriteLine("\nArray after insertion sort: " + string.Join(" ", arrayShift));

Console.WriteLine("\n\nArray before sorting:");
Console.WriteLine(string.Join(" ", numbers) + "\n");

// Calling the sorting method with swap
Stopwatch timeSwap = Stopwatch.StartNew();
Console.WriteLine("Swap approach\n");
SortWithSwap(arraySwap);
timeSwap.Stop();

Console.WriteLine("\nArray after insertion sort: " + string.Join(" ", arraySwap));

Console.WriteLine("\nExecution time:");
Console.WriteLine($"Insert sort with shift:{timeShift.Elapsed.TotalMilliseconds:F4} ms");
Console.WriteLine($"Insert sort with swap: {timeSwap.Elapsed.TotalMilliseconds:F4} ms");