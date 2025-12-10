// Bubble Sort implementation in C#
// Time complexity: O(n^2) in the avarage and worse case., O(n) in the best case.
int[] original = { 5, 3, 8, 4, 2, 4, 6 };

Console.WriteLine("Original Table: " + string.Join(", ", original));

int[] sorted = (int[])original.Clone();

BubbleSort(sorted);

Console.WriteLine("Sorted array: " + string.Join(", ", sorted));

void BubbleSort(int[] input)
{
    for (int i = 0; i < input.Length - 1; i++)
    {
        for (int j = 0; j < input.Length - 1 - i; j++)
        {
            if (input[j] > input[j + 1])
            {
                int temp = input[j];
                input[j] = input[j + 1];
                input[j + 1] = temp;
            }
        }
    }
}