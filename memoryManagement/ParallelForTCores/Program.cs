List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

Parallel.ForEach(numbers, ProcessNumber);

Console.WriteLine("All numbers processed.");


static void ProcessNumber(int number)
{
    int threadId = Thread.CurrentThread.ManagedThreadId;
    int cpuId = Thread.GetCurrentProcessorId();

    Console.WriteLine($"Processing number {number} on thread {threadId}, CPU {cpuId}");

    Thread.Sleep(100); //wait simulation
}

