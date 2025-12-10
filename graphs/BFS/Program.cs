BreadthFirstSearch bfsFinder = new BreadthFirstSearch();
bfsFinder.BFS(0, 700);
class BreadthFirstSearch
{
    // List of neighbors for each node in the graph.
    // Graph is unsequenced.
    // Complexity in case of list: O(V + E) where V is vertices and E is edges.
    private static readonly Dictionary<int, List<int>> graph = new()
    {
        [0] = new List<int> { 1, 2 },
        [1] = new List<int> { 0, 3 },
        [2] = new List<int> { 0, 3 },
        [3] = new List<int> { 1, 2, 100 },
        [100] = new List<int> { 3, 700 },
        [300] = new List<int> { 1, 0, 2, 700 },
        [700] = new List<int> { 3 }
    };

    // Queue for BFS traversal. - FIFO (First In First Out)
    private readonly Queue<int> queue = new();

    // Set of visited nodes.
    private readonly HashSet<int> visited = new();

    // Dictionary to keep track of the shortest path.
    private readonly Dictionary<int, int> previousVisited = new();

    // Perform BFS from startNode to goalNode using queue (BFS is using leyer by layer approach).
    public void BFS(int startNode, int goalNode)
    {
        // Start node queue
        queue.Enqueue(startNode);
        // Adding start node to visited set.
        visited.Add(startNode);

        Console.WriteLine($"BFS starting from node: {startNode} to node: {goalNode}\n");

        while (queue.Count > 0)
        {
            // Take the front node from the queue and remove it.
            int currentNode = queue.Dequeue();

            Console.WriteLine("Visisted Node: " + currentNode);

            foreach (int neighbor in graph[currentNode])
            {
                if (!visited.Contains(neighbor))
                {
                    previousVisited[neighbor] = currentNode;

                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Print the shortest path from startNode to goalNode
        PrintShortestPath(startNode, goalNode);
    }

    private void PrintShortestPath(int startNode, int goalNode)
    {
        // Reconstruct the shortest path via backtracking using previousVisited dictionary
        var path = new Stack<int>();
        int current = goalNode;

        while (current != startNode)
        {
            path.Push(current);
            current = previousVisited[current];
        }

        path.Push(startNode);

        Console.Write("\nShortest Path: ");
        Console.WriteLine(string.Join(" - ", path));
        Console.WriteLine($"Length: {path.Count - 1} steps.");
    }
}
