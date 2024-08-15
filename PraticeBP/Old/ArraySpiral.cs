public class SpiralMatrix
{
    public int OrangesRotting(int[][] grid)
    {
        int m = grid.GetLength(0);
        int n = grid[0].Length;
        int[,] res = new int[m, n];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                res[i, j] = int.MaxValue;

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (grid[i][j] == 2)
                    Rotten(res, grid, i, j, m, n, 0);

        int max = 0;
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1 && res[i, j] == int.MaxValue)
                    return -1;
                if (res[i, j] != int.MaxValue)
                    max = Math.Max(max, res[i, j]);
            }

        return max;
    }

    private void Rotten(int[,] res, int[][] grid, int i, int j, int m, int n, int day)
    {
        if (i < 0 || i >= m) return;
        if (j < 0 || j >= n) return;

        if (res[i, j] <= day) return; // already visited
        if (grid[i][j] == 0) return; // empty cell, no orange in it

        res[i, j] = day;

        Rotten(res, grid, i - 1, j, m, n, day + 1);
        Rotten(res, grid, i + 1, j, m, n, day + 1);
        Rotten(res, grid, i, j - 1, m, n, day + 1);
        Rotten(res, grid, i, j + 1, m, n, day + 1);
    }

    public int OrangesRotting2(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshCount = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 2)
                    queue.Enqueue((i, j));
                if (grid[i][j] == 1)
                    freshCount++;
            }
        }

        if (freshCount == 0) return 0; // best e

        int minutes = 0;
        int[][] directions = new int[4][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

        while (queue.Count > 0)
        {
            int size = queue.Count;
            bool anyRotten = false;

            for (int i = 0; i < size; i++)
            {
                var (x, y) = queue.Dequeue();
                foreach (var dir in directions)
                {
                    int nx = x + dir[0];
                    int ny = y + dir[1];
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] == 1)
                    {
                        grid[nx][ny] = 2;
                        queue.Enqueue((nx, ny));
                        freshCount--;
                        anyRotten = true;
                    }
                }
            }

            if (anyRotten) minutes++;
        }

        return freshCount == 0 ? minutes : -1;
    }

    public bool CanAllOrangesRot(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshCount = 0;

        // Initialize the queue with all initially rotten oranges and count fresh oranges
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 2)
                    queue.Enqueue((i, j)); // Add rotten orange to the queue
                if (grid[i][j] == 1)
                    freshCount++; // Count fresh orange
            }
        }

        // If there are no fresh oranges, return true (all oranges are already rotted or there are no oranges)
        if (freshCount == 0) return true;

        int[][] directions = new int[4][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

        // BFS to spread the rot
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue(); // Dequeue the next rotten orange
            foreach (var dir in directions)
            {
                int nx = x + dir[0];
                int ny = y + dir[1];
                // Check if the adjacent cell is within bounds and has a fresh orange
                if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] == 1)
                {
                    grid[nx][ny] = 2; // Rot the fresh orange
                    queue.Enqueue((nx, ny)); // Add the newly rotten orange to the queue
                    freshCount--; // Decrease the count of fresh oranges
                }
            }
        }

        // Return true if all fresh oranges have rotted, otherwise return false
        return freshCount == 0;
    }
    public static List<List<int>> DiagonalOrder(int[,] matrix)
    {
        var rowStart = 0;
        var colStart = 0;
        var rowEnd = matrix.GetLength(0) - 1;
        var colEnd = matrix.GetLength(1) - 1;

        List<List<int>> result = new List<List<int>>();
        for (var i = 0; i < matrix.GetLength(1); i++)
        {
            List<int> temp = new List<int>();
            var prevI = i;
            var x = matrix[0, i];
            var height = matrix.GetLength(0) - 1 - i;
            var t = 0;
            while (t <= height)
            {
                temp.Add(matrix[t, i]);
                t++;
            }

            var a = height;
            var b = prevI + 1;
            while (a >= rowStart && a <= rowEnd && b <= colEnd && b >= colStart)
            {
                temp.Add(matrix[a, b]);
                b++;
            }
            result.Add(temp);
        }
        return result;
    }
    public static List<int> SpiralCicularOrder(int[,] matrix)
    {
        List<int> result = new List<int>();

        var rowStart = 0;
        var rowEnd = matrix.GetLength(0) - 1;
        var colStart = 0;
        var colEnd = matrix.GetLength(1) - 1;


        while (rowStart <= rowEnd && colStart <= colEnd)
        {

            for (var i = colStart; i <= colEnd; i++)
                result.Add(matrix[rowStart, i]);
            rowStart++;

            if (rowStart <= rowEnd)
            {
                for (var i = rowStart; i <= rowEnd; i++)
                    result.Add(matrix[i, colEnd]);
                colEnd--;
            }

            if (colStart <= colEnd)
            {
                for (var i = colEnd; i >= colStart; i--)
                    result.Add(matrix[rowEnd, i]);
                rowEnd--;
            }

            if (rowStart <= rowEnd)
            {
                for (var i = rowEnd; i >= rowStart; i--)
                    result.Add(matrix[i, colStart]);
                colStart++;
            }
        }
        return result;
    }
    public static void Main2()
    {
        int[,] matrix = {
            {1, 2, 3, 4,5},
            {6, 7, 8,9,10},
            { 11, 12,13,14,15},
            {16,17, 18, 19, 20},
        };

        var result = DiagonalOrder(matrix);

        foreach (var lst in result)
        {
            foreach (var item in lst)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }
    }
}
