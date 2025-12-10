using System.Buffers;

int size = 1000;

// Take the shared array pool instance
var pool = ArrayPool<int>.Shared;

// Rent an array of the specified size, could be larger than requested
int[] rentedArray = pool.Rent(size);

try
{
    // Use the rented array
    for (int i = 0; i < size; i++)
    {
        rentedArray[i] = i * 2;
    }

    Console.WriteLine("First five elements");
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(rentedArray[i]);
    }
}
finally
{
    // Give back the rented array to the pool
    pool.Return(rentedArray);
}

