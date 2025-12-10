// Graph definition, adjecency matrix representation
int[,] graph = {
    { 0, 2, 0, 6, 0 },
    { 2, 0, 3, 8, 5 },
    { 0, 3, 0, 0, 7 },
    { 6, 8, 0, 0, 9 },
    { 0, 5, 7, 9, 0 }
};

// Starting from vertex {0, 0}
DijkstraWithPath.RunDijkstra(graph, 0);


public static class DijkstraWithPath
{
    // Representing infinity value as max int value
    private const int Infinity = int.MaxValue;

    public static void RunDijkstra(int[,] graph, int source)
    {
        int V = graph.GetLength(0);
        Dijkstra(graph, source, V);
    }

    // Finding not visited vertex with minimum distance value
    private static int MinDistance(int[] dist, bool[] visited, int V)
    {
        int min = Infinity;
        int minIndex = -1; // Initial value of minIndex signals that no unvisited vertex was found

        for (int v = 0; v < V; v++)
        {
            if (!visited[v] && dist[v] < min)
            {
                min = dist[v];
                minIndex = v;
            }
        }
        return minIndex;
    }

     private static void PrintPath(int[] prev, int j)
    {
        if (prev[j] == -1)
        {
            Console.Write(j);
            return;
        }

        PrintPath(prev, prev[j]);
        Console.Write(" --> " + j);
    }

    private static void Dijkstra(int[,] graph, int src, int V)
    {
        int[] dist = new int[V];    // Distance from source to vertex
        int[] prev = new int[V];    // Preceding vertex in optimal path
        bool[] visited = new bool[V]; // Checking if vertex was visited

        // Initialize all distances as infinite
        for (int i = 0; i < V; i++)
        {
            dist[i] = Infinity;
            prev[i] = -1;
        }

        dist[src] = 0;

        for (int count = 0; count < V; count++)
        {
            int u = MinDistance(dist, visited, V);

            if (u == -1 || dist[u] == Infinity)
                break;

            visited[u] = true;

            // Relaxation step
            for (int v = 0; v < V; v++)
            {
                // Check for unvisited vertex shortest path
                if (!visited[v] && graph[u, v] != 0 && dist[u] != Infinity && (long)dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                    prev[v] = u;
                }
            }
        }

        PrintSolution(dist, prev, src, V);
    }

    private static void PrintSolution(int[] dist, int[] prev, int src, int V)
    {
        Console.WriteLine($"\nSource: {src}\n\n");
        Console.WriteLine("Vertex\t\t\tLength\t\t\tPath");

        for (int i = 0; i < V; i++)
        {
            string length = (dist[i] == Infinity) ? "∞" : dist[i].ToString();

            Console.Write($"{i}\t\t\t{length}\t\t\t");

            if (dist[i] == Infinity)
            {
                Console.WriteLine("No path");
            }
            else
            {
                PrintPath(prev, i);
                Console.WriteLine();
            }
        }
    }
}