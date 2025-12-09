char[,] grid =
{
    { 'S', '.', '.', '.', '.' },
    { '.', '#', '#', '.', '.' },
    { '.', '.', '.', '#', '.' },
    { '.', '#', '.', '.', 'G' }
};

// Start position: S (Row 0, Col 0)
var startPos = (row: 0, col: 0);
// Goal position: G (Row 3, Col 4)
var goalPos = (row: 3, col: 4);

var path = AStarPathfinding.AStar(grid, startPos, goalPos);

Console.WriteLine("A* path:");
if (path.Any())
{
    foreach (var pos in path)
    {
        var (row, col) = pos;
        Console.WriteLine($"({row}, {col})");
    }
}
else
{
    Console.WriteLine("Path not found.");
}
class AStarPathfinding
{
    // Constants for the map symbols and movement cost.
    private const char Wall = '#';
    private const int StepCost = 1;

    private static readonly (int dx, int dy)[] Directions =
    {
        (0, 1), (0, -1), (1, 0), (-1, 0)
    };

    public static List<(int row, int col)> AStar(
        char[,] grid,
        (int row, int col) start,
        (int row, int col) goal)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        var openSet = new PriorityQueue<(int row, int col), int>();

        // Stores the actual cost from start to the current position.
        var gScore = new Dictionary<(int row, int col), int> { [start] = 0 };

        // Stores the predecessor for reconstructing the path.
        var cameFrom = new Dictionary<(int row, int col), (int row, int col)>();

        // Start the algorithm by enqueuing the start node. fScore = gScore (0) + Heuristic.
        openSet.Enqueue(start, Heuristic(start, goal));

        while (openSet.Count > 0)
        {
            // Get the node with the lowest fScore (highest priority).
            var current = openSet.Dequeue();

            // Check if the goal has been reached.
            if (current.row == goal.row && current.col == goal.col)
            {
                return ReconstructPath(cameFrom, goal);
            }

            // Check all neighbors.
            foreach (var (dx, dy) in Directions)
            {
                var neighbor = (current.row + dx, current.col + dy);
                var (nRow, nCol) = neighbor;

                // Boundary and wall check.
                if (nRow < 0 || nRow >= rows || nCol < 0 || nCol >= cols || grid[nRow, nCol] == Wall)
                {
                    continue;
                }

                // tentativeG is the cost of the path from start to neighbor through current.
                int tentativeG = gScore[current] + StepCost;

                // Check if this new path to the neighbor is shorter - relaxation step.
                if (!gScore.ContainsKey(neighbor) || tentativeG < gScore[neighbor])
                {
                    gScore[neighbor] = tentativeG;
                    cameFrom[neighbor] = current;

                    // fScore = gScore + Heuristic. Enqueue the neighbor.
                    openSet.Enqueue(neighbor, tentativeG + Heuristic(neighbor, goal));
                }
            }
        }

        // If the loop finishes without reaching the goal.
        return new List<(int row, int col)>();
    }

    // Manhattan Distance Heuristic (h(n)). Sum of the absolute differences in coordinates under perpendicular movement.
    private static int Heuristic((int row, int col) a, (int row, int col) b)
    {
        return Math.Abs(a.row - b.row) + Math.Abs(a.col - b.col);
    }

    // Reconstructs the path from the dictionary, starting from the goal.
    private static List<(int row, int col)> ReconstructPath(Dictionary<(int row, int col), (int row, int col)> cameFrom, (int row, int col) current)
    {
        var path = new List<(int row, int col)> { current };

        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            path.Add(current);
        }

        path.Reverse();
        return path;
    }
}