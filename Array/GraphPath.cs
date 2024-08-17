namespace Array;

public class GraphPath
{
    public int[] AmountPainted(int[][] paint)
    {
        int n = paint.Length;
        int[] result = new int[n];
        SortedDictionary<int, int> paintedSegments = new SortedDictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int start = paint[i][0];
            int end = paint[i][1];
            int paintedToday = 0;

            while (start < end)
            {
                if (paintedSegments.TryGetValue(start, out int nextStart))
                    start = nextStart;
                else
                {
                    paintedToday++;
                    paintedSegments[start] = start + 1;
                    start++;
                }
            }

            result[i] = paintedToday;
        }

        return result;
    }

    /// <summary>
    /// The Maze hit untill wall
    /// https://leetcode.ca/all/490.html 
    /// </summary>
    /// <param name="maze"></param>
    /// <param name="start"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public bool HasPath(int[][] maze, int[] start, int[] destination)
    {
        var destinationRow = destination[0];
        var destinationCol = destination[1];

        int row = maze.Length;
        int col = maze[0].Length;
        int[][] directions = new int[][] {
        new int[] { 0, 1 },  // right
        new int[] { 0, -1 }, // left
        new int[] { 1, 0 },  // down
        new int[] { -1, 0 }  // up
    };

        HashSet<(int, int)> visited = new HashSet<(int, int)>();
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((start[0], start[1]));
        visited.Add((start[0], start[1]));

        while (queue.Count > 0)
        {
            var (currentRow, currentCol) = queue.Dequeue();

            if (currentRow == destinationRow && currentCol == destinationCol)
                return true;

            foreach (var direction in directions)
            {
                int newRow = currentRow;
                int newCol = currentCol;

                // Roll the ball until it hits a wall
                while (newRow >= 0 && newRow < row && newCol >= 0 && newCol < col && maze[newRow][newCol] == 0)
                {
                    newRow += direction[0];
                    newCol += direction[1];
                }

                // Step back to the last valid position
                newRow -= direction[0];
                newCol -= direction[1];

                // If this position has not been visited, add it to the queue
                if (!visited.Contains((newRow, newCol)))
                {
                    queue.Enqueue((newRow, newCol));
                    visited.Add((newRow, newCol));
                }
            }
        }

        return false;
    }

    /// <summary>
    /// NearestExit maze https://leetcode.com/problems/nearest-exit-from-entrance-in-maze/description/
    /// </summary>
    /// <param name="maze"></param>
    /// <param name="entrance"></param>
    /// <returns></returns>
    public int NearestExit(char[][] maze, int[] entrance)
    {
        var row = maze.Length;
        var column = maze[0].Length;

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((entrance[0], entrance[1]));
        maze[entrance[0]][entrance[1]] = '+';

        int days = 0;
        int[][] directions = { [0, 1], [1, 0], [0, -1], [-1, 0] };
        while (queue.Count > 0)
        {
            var count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var (x, y) = queue.Dequeue();
                foreach (var direction in directions)
                {
                    var newRow = x + direction[0];
                    var newCol = y + direction[1];
                    if (newRow >= 0 && newRow < row && newCol >= 0 && newCol < column && maze[newRow][newCol] == '.')
                    {
                        if (newRow == 0 || newRow == maze.Length - 1 || newCol == 0 || newCol == maze[0].Length - 1)
                            return days + 1;

                        maze[newRow][newCol] = '+';
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
            days++;
        }

        return -1;

    }

    public int NearestExitInternet(char[][] maze, int[] startCell)
    {
        var directions = new int[][]{
        new int[] { 0, 1 }, // right
        new int[] { 1, 0 }, // down
        new int[] { 0, -1 }, // left
        new int[] { -1, 0 }  // up
        };

        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
        var r = startCell[0];
        var c = startCell[1];
        queue.Enqueue((r, c, 0)); // [row, col, steps]
        maze[r][c] = '+'; // Mark the entrance as visited

        while (queue.Count > 0)
        {
            var (row, column, steps) = queue.Dequeue();

            foreach (var direction in directions)
            {
                var newRow = row + direction[0];
                var newCol = column + direction[1];

                if (newRow >= 0 && newRow < maze.Length && newCol >= 0 && newCol < maze[0].Length && maze[newRow][newCol] == '.')
                {
                    if (newRow == 0 || newRow == maze.Length - 1 || newCol == 0 || newCol == maze[0].Length - 1)
                        return steps + 1;

                    maze[newRow][newCol] = '+'; // Mark as visited
                    queue.Enqueue((newRow, newCol, steps + 1));
                }
            }
        }

        return -1; // No exit found
    }

    /// <summary>
    /// if cycle exist or not 
    /// use visited as it improve perfrmance
    /// </summary>
    /// <param name="n"></param>
    /// <param name="edges"></param>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public bool ValidPath_BFS_IfCycleExist(int n, int[][] edges, int source, int destination)
    {
        var graph = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            int x = edge[0], y = edge[1];
            if (!graph.ContainsKey(x)) graph[x] = new List<int>();
            if (!graph.ContainsKey(y)) graph[y] = new List<int>();
            graph[x].Add(y);
            graph[y].Add(x);
        }

        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        queue.Enqueue(source);
        visited.Add(source);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            if (node == destination) return true;
            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    /// <summary>
    /// easy just take src and goes on for it negibour in dept of found true or 
    /// else backtrack and try with remaining neighbor
    /// </summary>
    /// <param name="n"></param>
    /// <param name="edges"></param>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public bool ValidPath_DFS(int n, int[][] edges, int source, int destination)
    {
        var graph = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            int x = edge[0], y = edge[1];
            if (!graph.ContainsKey(x)) graph[x] = new List<int>();
            if (!graph.ContainsKey(y)) graph[y] = new List<int>();
            graph[x].Add(y);
            graph[y].Add(x);
        }

        var visited = new HashSet<int>();
        return DFS(graph, visited, source, destination);
    }

    private bool DFS(Dictionary<int, List<int>> graph, HashSet<int> visited, int node, int destination)
    {
        if (node == destination) return true;

        if (visited.Contains(node)) return false;

        visited.Add(node);

        foreach (var neighbor in graph[node])
        {
            if (DFS(graph, visited, neighbor, destination))
                return true;
        }
        return false;  // Backtrack if no path leads to the destination
    }

    public bool ValidPath_UnionFind(int n, int[][] edges, int source, int destination)
    {
        var vertexes = new int[n];
        for (int i = 0; i < n; i++)
            vertexes[i] = i;

        foreach (var edge in edges)
        {
            var x = edge[0];
            var y = edge[1];
            Union(vertexes, x, y);
        }

        return Find(vertexes, source) == Find(vertexes, destination);
    }

    private void Union(int[] vertexes, int x, int y)
    {
        int rootU = Find(vertexes, x);
        int rootV = Find(vertexes, y);
        if (rootU != rootV)
            vertexes[rootU] = rootV;
    }

    private int Find(int[] vertexes, int node)
    {
        if (vertexes[node] != node)
            vertexes[node] = Find(vertexes, vertexes[node]);
        return vertexes[node];
    }

}
