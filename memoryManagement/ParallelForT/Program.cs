using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        Parallel.ForEach(numbers, ProcessNumber);

        Console.WriteLine("All numbers processed.");
    }

    static void ProcessNumber(int number)
    {
        Console.WriteLine($"Processing number {number} on thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(100); // symulacja pracy
    }
}
