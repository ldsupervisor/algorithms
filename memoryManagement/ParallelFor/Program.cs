Console.WriteLine("Standard for-loop:");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"[for] Index {i} on thread {Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(500); // work simulation
}

Console.WriteLine("\nParallel.For-loop:");
Parallel.For(0, 5, i =>
{
    Console.WriteLine($"[parallel] Index {i} on thread {Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(500); // work simulation
});
