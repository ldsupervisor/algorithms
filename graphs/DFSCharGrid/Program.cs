using System;

class DFSGrid
{
    // Directions: right, down, up, left
    static (int dx, int dy)[] directions = new (int, int)[]
{
    (0, 1),
    (1, 0),
    (-1, 0),
    (0, -1)
};
    static bool[,] visited;

    static void DFS(char[,] grid, int x, int y)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        // Checker for out of bounds, visited, or wall
        if (x < 0 || y < 0 || x >= rows || y >= cols || visited[x, y] || grid[x, y] == '#')
            return;

        visited[x, y] = true;
        Console.WriteLine($"Visited ({x}, {y})");

        foreach (var dir in directions)
        {
            DFS(grid, x + dir.dx, y + dir.dy);
        }

    }

    static void Main()
    {
        char[,] grid =
        {
            { '.', '.', '.', '#' },
            { '#', '.', '#', '.' },
            { '.', '.', '.', '.' },
            { '.', '#', '.', '.' }
        };

        visited = new bool[grid.GetLength(0), grid.GetLength(1)];

        Console.WriteLine("DFS from (0,0):");
        DFS(grid, 0, 0);
    }
}