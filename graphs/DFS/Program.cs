DFSExampleIterative.DFS(0);
class DFSExampleIterative
{
    // List of neighbors for each node in the graph.
    // Graph is unsequenced.
    // Complexity in case of list: O(V + E) where V is vertices and E is edges.
    static Dictionary<int, List<int>> graph = new()
    {
        [0] = new List<int> { 1, 2 },
        [1] = new List<int> { 0, 3 },
        [2] = new List<int> { 0, 3 },
        [3] = new List<int> { 1, 2, 100 },
        [100] = new List<int> { 3, 700 },
        [300] = new List<int> { 1, 0, 2, 700 },
        [700] = new List<int> { 3 }
    };

    // Stack for maintaining recursion.
    static Stack<int> stack = new();

    // Set of visited nodes.
    static HashSet<int> visited = new();

    // DFS using stack (iterative approach).
    public static void DFS(int startNode)
    {
        // Start node pushed onto the stack.
        stack.Push(startNode);
        // Adding start node to visited set.
        visited.Add(startNode);

        Console.WriteLine($"DFS starting from node: {startNode}");

        while (stack.Count > 0)
        {
            // Take the top node from the stack without removing it.
            int currentNode = stack.Pop();

            Console.WriteLine("Visited: " + currentNode);

            foreach (int neighbor in graph[currentNode])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    stack.Push(neighbor);
                }
            }
        }
    }
}