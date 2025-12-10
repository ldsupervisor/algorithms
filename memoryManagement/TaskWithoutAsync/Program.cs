// Call the factory and wait for the returned Task to complete
Task task = CreateTasksWithoutAsync();
task.Wait(); // block until returned task (here task2) finishes

static Task CreateTasksWithoutAsync()
{
    Task task1 = new Task(() => DoTask("Task 1"));
    Task task2 = new Task(() => DoTask("Task 2"));

    task1.Start();
    task2.Start();

    // we return the second task (only task2)
    return task2;
}

static void DoTask(string name)
{
    Console.WriteLine($"[{name}] Hello from {name}");
    Task.Delay(300).Wait(); // simulate some work (synchronous wait)
}
