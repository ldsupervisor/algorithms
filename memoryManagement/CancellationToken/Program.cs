using var cts = new CancellationTokenSource();
cts.CancelAfter(TimeSpan.FromSeconds(5));

try
{
    // run two tasks concurrently
    Task firstTask = PerformTaskAsync("Task 1", cts.Token);
    Task secondTask = PerformTaskAsync("Task 2", cts.Token);

    // wait for both tasks to complete
    await Task.WhenAll(firstTask, secondTask);

    Console.WriteLine("All tasks completed successfully");
}
catch (OperationCanceledException)
{
    Console.WriteLine("Tasks were cancelled");
}

static async Task PerformTaskAsync(string name, CancellationToken token)
{
    Console.WriteLine($"[{name}] Start");

    for (int i = 0; i < 10; i++)
    {
        token.ThrowIfCancellationRequested();

        await Task.Delay(500, token);
        Console.WriteLine($"[{name}] Step {i}");
    }

    Console.WriteLine($"[{name}] Completed");
}