class PriorityQueueExample
{
    static void Main()
    {
        // Creating priority queue: element of string type, priority of type int.
        var pq = new PriorityQueue<string, int>();

        // Adding elements (element, priority)
        pq.Enqueue("task A", 3);
        pq.Enqueue("task B", 1);
        pq.Enqueue("task C", 2);
        pq.Enqueue("task D", 0);

        Console.WriteLine("Queue after adding elememnts");
        var temp = new List<(string, int)>();

        while (pq.Count > 0)
        {
            pq.TryDequeue(out var item, out var priority);
            Console.WriteLine($"Element: {item}, Priorytet: {priority}");
            temp.Add((item!, priority));
        }

        // Reading without removing
        foreach (var (item, priority) in temp)
        {
            pq.Enqueue(item, priority);
        }

        Console.WriteLine("\nRemoving the higher priority");
        Console.WriteLine("Removed " + pq.Dequeue());

        Console.WriteLine("\nPeek");
        Console.WriteLine("Next " + pq.Peek());

        Console.WriteLine("\nOther elements");
        while (pq.Count > 0)
        {
            Console.WriteLine(pq.Dequeue());
        }
    }
}

