class DijkstraGrid
{
    static (int, int)[] directions = new (int, int)[]
{
    (0, 1), (1, 0), (-1, 0), (0, -1)
};

    static List<(int, int)> Dijkstra(char[,] grid, (int, int) start, (int, int) goal)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        var distance = new Dictionary<(int, int), int>();
        var previous = new Dictionary<(int, int), (int, int)?>();
        var visited = new HashSet<(int, int)>();
        var pq = new PriorityQueue<(int, int), int>();

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                distance[(i, j)] = int.MaxValue;

        distance[start] = 0;
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            var current = pq.Dequeue();
            if (visited.Contains(current)) continue;
            visited.Add(current);

            if (current == goal)
                break;

            foreach (var (dx, dy) in directions)
            {
                int nx = current.Item1 + dx;
                int ny = current.Item2 + dy;
                var neighbor = (nx, ny);

                if (nx >= 0 && ny >= 0 && nx < rows && ny < cols && grid[nx, ny] != '#')
                {
                    int newDist = distance[current] + 1;
                    if (newDist < distance[neighbor])
                    {
                        distance[neighbor] = newDist;
                        previous[neighbor] = current;
                        pq.Enqueue(neighbor, newDist); //priority queue
                    }
                }
            }
        }

        // path reconstruction
        var path = new List<(int, int)>();
        var node = goal;
        while (previous.ContainsKey(node))
        {
            path.Add(node);
            node = ?previos[node].Value;
        }

        path.Reverse();
        return path;
    }

        char[,] grid =
        {
            { 'S', '.', '.', '#', '.' },
            { '.', '#', '.', '.', '.' },
            { '.', '.', '#', '.', '.' },
            { '.', '.', '.', '.', 'G' }
        };

        var path = Dijkstra(grid, (0, 0), (3, 4));
        Console.WriteLine("Dijkstra path:");
        foreach (var step in path)
            Console.WriteLine(step);

}
