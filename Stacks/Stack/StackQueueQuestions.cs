using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class StackQueueQuestions
    {
        public void Reverse(Stack<int> stack)
        {
            Queue<int> q = new Queue<int>();
            while (stack.Count > 0)
                q.Enqueue(stack.Pop());

            while (q.Count > 0)
                stack.Push(q.Dequeue());
        }

        public void Reverse(Stack<int> stack, int k)
        {
            Queue<int> q = new Queue<int>();
            while (stack.Count > 0 && k > 0)
            {
                q.Enqueue(stack.Pop());
                k--;
            }

            while (q.Count > 0)
                stack.Push(q.Dequeue());
        }

        public void Reverse(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());
        }

        /// <summary>
        /// A Remove k from Q and push into S
        /// B Pop from S and add in Q
        /// C K are in reverse order in Q but thay are at end
        /// D bring them at start
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="k"></param>
        public void Reverse(Queue<int> queue, int k)
        {
            int x = k;
            Stack<int> stack = new Stack<int>();

            // A
            while (queue.Count > 0 && k > 0)
            {
                stack.Push(queue.Dequeue());
                k--;
            }

            // B
            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

            // C and D
            var diff = queue.Count - x;
            while (diff > 0)
            {
                queue.Enqueue(queue.Dequeue());
                diff--;
            }
        }

     

        public bool ValidParenthesis(string str)
        {
            Stack<char> stack = new Stack<char>();
            var len = str.Length;
            if (len % 2 != 0) return false;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '[' || str[i] == '{')
                    stack.Push(str[i]);
                else
                {
                    if (stack.Count == 0) return false;
                    switch (str[i])
                    {
                        case ')': if (stack.Pop() != '(') return false; break;
                        case ']': if (stack.Pop() != '[') return false; break;
                        case '}': if (stack.Pop() != '{') return false; break;
                        default:
                            return false;
                    }
                }
            }
            return stack.Count == 0 ? true : false;

        }
        public List<int> NextGreterElement(int[] arr)
        {
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                var item = arr[i];

                while (stack.Count > 0 && stack.Peek() <= item)
                    stack.Pop();

                result.Add(stack.Count == 0 ? -1 : stack.Peek());
                stack.Push(item);
            }
            return result;
        }
        public List<int> NextSmallerElement(int[] arr)
        {
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                var item = arr[i];

                while (stack.Count > 0 && stack.Peek() >= item)
                    stack.Pop();

                result.Add(stack.Count == 0 ? -1 : stack.Peek());
                stack.Push(item);
            }
            return result;
        }
        public int LongestValidParentheses(string str)
        {
            var max = 0;
            var stack = new Stack<int>();
            stack.Push(-1); // put left edge of potential valid parentheses
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    stack.Push(i);
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                        stack.Push(i);
                    max = Math.Max(max, i - stack.Peek());
                }
            }
            return max;
        }

        public void InsertAtBottom(Stack<int> stack, int ele)
        {
            if (stack.Count() == 0)
                stack.Push(ele);
            else
            {
                var temp = stack.Pop();
                InsertAtBottom(stack, ele);
                stack.Push(temp);
            }
        }

        public void InsertInSortedStack(Stack<int> stack, int ele)
        {
            if (stack.Count == 0 || ele >= stack.Peek())
                stack.Push(ele);
            else
            {
                var temp = stack.Pop();
                InsertInSortedStack(stack, ele);
                stack.Push(temp);
            }
        }

        public void SortStack(Stack<int> stack)
        {
            if (stack.Count > 0)
            {
                var x = stack.Pop();
                SortStack(stack);
                InsertInSortedStack(stack, x);
            }
        }

        static void PrintMaxOfMin(int n, int[] arr)
        {

            for (int k = 1; k <= n; k++)
            {

                int maxOfMin = int.MinValue;
                for (int i = 0; i <= n - k; i++)
                {
                    int min = arr[i];
                    for (int j = 1; j < k; j++)
                    {
                        if (arr[i + j] < min)
                            min = arr[i + j];
                    }

                    if (min > maxOfMin)
                        maxOfMin = min;
                }
                Console.Write(maxOfMin + " ");
            }
        }

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
                    if (grid[i][j] == 2) // IMP
                        Rotten(res, grid, i, j, m, n, 0);

            int days = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1 && res[i, j] == int.MaxValue) // IMP
                        return -1;
                    if (res[i, j] != int.MaxValue) // IMP
                        days = Math.Max(days, res[i, j]);
                }

            return days;
        }

        // Working but TLE
        public int[][] UpdateMatrix(int[][] grid)
        {
            int m = grid.GetLength(0);
            int n = grid[0].Length;
            int[][] res = new int[m][];

            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
                for (int j = 0; j < n; j++)
                    res[i][j] = int.MaxValue;
            }
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (grid[i][j] == 0)    // IMP
                        Distance(res, i, j, m, n, 0);

            return res;
        }

        // Working but TLE
        private void Distance(int[][] res, int i, int j, int m, int n, int day)
        {
            if (i < 0 || i >= m) return;
            if (j < 0 || j >= n) return;

            if (res[i][j] <= day) return; // already visited
            res[i][j] = day;
            Distance(res, i - 1, j, m, n, day + 1);
            Distance(res, i + 1, j, m, n, day + 1);
            Distance(res, i, j - 1, m, n, day + 1);
            Distance(res, i, j + 1, m, n, day + 1);
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

        public int[][] UpdateMatrix2(int[][] grid)
        {
            int m = grid.GetLength(0);
            int n = grid[0].Length;
            int[][] res = new int[m][];

            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
                for (int j = 0; j < n; j++)
                    res[i][j] = int.MaxValue;
            }

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        res[i][j] = 0;
                        queue.Enqueue(new int[] { i, j });
                    }
                }
            }

            int[][] dirs = { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

            // Perform BFS
            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                int row = cell[0];
                int col = cell[1];

                foreach (var dir in dirs)
                {
                    int newRow = row + dir[0];
                    int newCol = col + dir[1];

                    if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n &&
                        res[newRow][newCol] > res[row][col] + 1)
                    {
                        res[newRow][newCol] = res[row][col] + 1;
                        queue.Enqueue(new int[] { newRow, newCol });
                    }
                }
            }

            return res;
        }

    }
}
