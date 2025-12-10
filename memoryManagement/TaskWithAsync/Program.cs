
static async Task CreateTasksWithAsync()
{
    Task firstTask = Task.Run(() => PerformTask("Task 1"));

    Task secondTask = Task.Run(() => PerformTask("Task 2"));

    await firstTask;
    Console.WriteLine($"[Task 1] Finished at {DateTime.Now:HH:mm:ss.fff}");

    await secondTask;
    Console.WriteLine($"[Task 2] Finished at {DateTime.Now:HH:mm:ss.fff}");
}

await CreateTasksWithAsync();

static void PerformTask(string name)
{
    Console.WriteLine($"[{name}] Hello from {name} at {DateTime.Now:HH:mm:ss.fff}");
}

