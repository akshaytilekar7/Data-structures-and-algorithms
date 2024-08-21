namespace Array;

public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var graph = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            if (!graph.ContainsKey(u))
                graph[u] = new List<int>();
            if (!graph.ContainsKey(v))
                graph[v] = new List<int>();
            graph[u].Add(v);
            graph[v].Add(u);
        }

        var queue = new Queue<int>();
        var visited = new HashSet<int>();

        queue.Enqueue(source);
        visited.Add(source);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            if (node == destination)
                return true;

            var neighbors = graph.GetValueOrDefault(node, new List<int>());
            foreach (int neighbor in neighbors)
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

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // Step 1: Create the graph and in-degree array
        List<int>[] graph = new List<int>[numCourses];
        int[] inDegree = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();

        foreach (var prerequisite in prerequisites)
        {
            int course = prerequisite[0];
            int pre = prerequisite[1];
            graph[pre].Add(course);
            inDegree[course]++;
        }

        // Step 2: Add inDegree = 0 in Queue
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
            if (inDegree[i] == 0)
                queue.Enqueue(i);

        int count = 0;
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            count++;

            foreach (var neighbor in graph[current])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        return count == numCourses;
    }

    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord)) return 0;

        Queue<string> queue = new Queue<string>();
        queue.Enqueue(beginWord);

        int level = 1;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                string currentWord = queue.Dequeue();
                List<string> neighbors = GetNeighbors(currentWord, wordSet);

                foreach (var neighbor in neighbors)
                {
                    if (neighbor.Equals(endWord))
                        return level + 1;
                    queue.Enqueue(neighbor);
                    wordSet.Remove(neighbor);
                }
            }

            level++;
        }

        return 0;
    }

    private List<string> GetNeighbors(string srcWord, HashSet<string> wordSet)
    {
        List<string> neighbors = new List<string>();
        char[] charArray = srcWord.ToCharArray();

        for (int i = 0; i < charArray.Length; i++)
        {
            char srcOriginalChar = charArray[i];

            for (char c = 'a'; c <= 'z'; c++)
            {
                charArray[i] = c;
                string newWord = new string(charArray);

                if (!newWord.Equals(srcWord) && wordSet.Contains(newWord))
                    neighbors.Add(newWord);
            }

            charArray[i] = srcOriginalChar;
        }

        return neighbors;
    }


}
public class OrangesRottingPatterns
{
    class Graph
    {
        public int V { get; }

        public Graph(int v)
        {
            V = v;
        }

        private Dictionary<int, List<int>> AdjList = new Dictionary<int, List<int>>();

        public void AddVertex(int v)
        {
            if (!AdjList.ContainsKey(v))
                AdjList[v] = new List<int>();
        }

        public void AddEdge(int x, int y)
        {
            if (!AdjList.ContainsKey(x)) AddVertex(x);
            if (!AdjList.ContainsKey(y)) AddVertex(y);
            AdjList[x].Add(y);
        }

        private void TopologicalSortUtil(int v, HashSet<int> visited, Stack<int> stack)
        {
            visited.Add(v);

            if (AdjList.ContainsKey(v))
                foreach (var neighbor in AdjList[v])
                    if (!visited.Contains(neighbor))
                        TopologicalSortUtil(neighbor, visited, stack);

            stack.Push(v);
        }

        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();

            foreach (var vertex in AdjList.Keys)
                if (!visited.Contains(vertex))
                    TopologicalSortUtil(vertex, visited, stack);

            Console.WriteLine("Topological Sort of the given graph:");
            while (stack.Count > 0)
                Console.Write(stack.Pop() + " ");
        }

        public void TopologicalSortBFS()
        {
            int[] inDegree = new int[V];
            for (int i = 0; i < V; i++)
                foreach (var neighbor in AdjList[i])
                    inDegree[neighbor]++;

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < V; i++)
                if (inDegree[i] == 0)
                    queue.Enqueue(i);

            List<int> topOrder = new List<int>();

            while (queue.Count > 0)
            {
                int pop = queue.Dequeue();
                topOrder.Add(pop);

                foreach (var neighbor in AdjList[pop])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }

            if (topOrder.Count != V)
            {
                Console.WriteLine("The graph contains a cycle. Topological sort is not possible.");
                return;
            }

            Console.WriteLine("Topological Sort of the given graph:");
            foreach (var vertex in topOrder)
                Console.Write(vertex + " ");
        }
    }

    class Program
    {
        static void Main()
        {
            var g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            g.TopologicalSort();
        }
    }

    public int MinDepth(TreeNode root)
    {
        if (root is null) { return 0; }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int depth = 1;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++) // iterate leval by leval when we get 1st leaf node ibviouslly min dept
            {
                TreeNode node = queue.Dequeue();
                if (node.left is null && node.right is null) { return depth; }  // V IMP
                if (node.left != null) { queue.Enqueue(node.left); }
                if (node.right != null) { queue.Enqueue(node.right); }
            }
            depth++;
        }
        return depth;
    }

    public int maxDepth_0(TreeNode root)
    {
        if (root == null)
            return 0;
        return 1 + Math.Max(maxDepth_0(root.left), maxDepth_0(root.right));
    }

    public int MaxDepth_2(TreeNode root)
    {
        if (root == null) { return 0; }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int depth = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null) { queue.Enqueue(node.left); }
                if (node.right != null) { queue.Enqueue(node.right); }
            }
            depth++;
        }

        return depth;
    }

    public int MaxDepth_1(TreeNode root)
    {
        if (root == null)
            return 0;

        Queue<(TreeNode node, int max)> q = new Queue<(TreeNode, int)>();
        q.Enqueue((root, 1));
        int maxDepth = 1;
        while (q.Count > 0)
        {
            var (node, max) = q.Dequeue();
            if (node.left != null) q.Enqueue((node.left, max + 1));
            if (node.right != null) q.Enqueue((node.right, max + 1));
            if (max > maxDepth)
                maxDepth = max;
        }
        return maxDepth;
    }

    public int MaximumMinimumPath(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int[][] directions = new int[][] {
            new int[] { 0, 1 }, // Right
            new int[] { 1, 0 }, // Down
            new int[] { 0, -1 }, // Left
            new int[] { -1, 0 } // Up
        };

        // PriorityQueue to prioritize paths with larger minimum values
        PriorityQueue<(int row, int col, int minVal), int> pq = new PriorityQueue<(int, int, int), int>(Comparer<int>.Create((a, b) => b - a));
        bool[][] visited = new bool[rows][];

        for (int i = 0; i < rows; i++)
            visited[i] = new bool[cols];

        pq.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        visited[0][0] = true;

        while (pq.Count > 0)
        {
            var (row, col, minVal) = pq.Dequeue();

            // If we reached the bottom-right corner, return the minVal (which is maximized by the PQ)
            if (row == rows - 1 && col == cols - 1)
                return minVal;

            foreach (var dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && !visited[newRow][newCol])
                {
                    visited[newRow][newCol] = true;
                    int newMinVal = Math.Min(minVal, grid[newRow][newCol]);
                    pq.Enqueue((newRow, newCol, newMinVal), newMinVal);
                }
            }
        }

        return -1;
    }

    /// <summary>
    /// https://leetcode.com/problems/shortest-path-in-binary-matrix/description/
    /// TC and SC are n Sqaure if m*n but here m and n are same 
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int n = grid.Length;
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
            return -1; // No path if start or end is blocked

        int[][] directions = new int[][]   {
        new int[] { -1, 0 }, // up
        new int[] { 1, 0 },  // down
        new int[] { 0, -1 }, // left
        new int[] { 0, 1 },  // right
        new int[] { -1, -1 }, // top-left diagonal
        new int[] { -1, 1 },  // top-right diagonal
        new int[] { 1, -1 },  // bottom-left diagonal
        new int[] { 1, 1 }    // bottom-right diagonal
        };

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        grid[0][0] = 1;

        int distance = 1;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var (x, y) = queue.Dequeue();

                if (x == n - 1 && y == n - 1) // last cell bottom right corner
                    return distance;

                foreach (var dir in directions)
                {
                    int newX = x + dir[0];
                    int newY = y + dir[1];

                    if (newX >= 0 && newX < n && newY >= 0 && newY < n && grid[newX][newY] == 0)
                    {
                        grid[newX][newY] = 1; // mark as visited
                        queue.Enqueue((newX, newY));
                    }
                }
            }

            distance++;
        }
        return -1;
    }

    /// <summary>
    /// TC: O(m*n)
    /// SC: O(m*n)
    /// </summary>
    /// <param name="rooms"></param>
    /// <returns></returns>
    public void WallsAndGates(int[][] rooms)
    {
        int rows = rooms.Length;
        if (rows == 0) return;
        int cols = rooms[0].Length;

        Queue<(int, int)> queue = new Queue<(int, int)>();

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (rooms[i][j] == 0)
                    queue.Enqueue((i, j));

        int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            foreach (var dir in directions)
            {
                int newX = x + dir[0];
                int newY = y + dir[1];

                if (newX >= 0 && newY >= 0 && newX < rows && newY < cols && rooms[newX][newY] == int.MaxValue)
                {
                    rooms[newX][newY] = rooms[x][y] + 1;
                    queue.Enqueue((newX, newY));
                }
            }
        }
    }

    /// <summary>
    /// TC: O(m*n)
    /// SC: O(m*n)
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int OrangesRotting(int[][] grid)
    {
        var row = grid.Length;
        var column = grid[0].Length;
        var freshCount = 0;
        Queue<(int, int)> queue = new Queue<(int, int)>();

        for (int i = 0; i < row; i++)
            for (int j = 0; j < column; j++)
            {
                if (grid[i][j] == 2)
                    queue.Enqueue((i, j));
                else if (grid[i][j] == 1)
                    freshCount++;
            }

        if (freshCount == 0) return 0;
        int days = 0;
        int[][] directions = { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        while (queue.Count > 0)
        {
            var count = queue.Count;
            var isRotten = false;
            for (int i = 0; i < count; i++)
            {
                var (x, y) = queue.Dequeue();
                foreach (var direction in directions)
                {
                    var newx = x + direction[0];
                    var newY = y + direction[1];
                    if (newx >= 0 && newx < row && newY >= 0 && newY < column && grid[newx][newY] == 1)
                    {
                        queue.Enqueue((newx, newY));
                        freshCount--;
                        grid[newx][newY] = 2;
                        isRotten = true;
                    }
                }
            }
            if (isRotten) days++;
        }

        return freshCount == 0 ? days : -1;

    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}