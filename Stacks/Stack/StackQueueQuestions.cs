                                                                                                                                                                                                                           using System.Text;
namespace Stack;

public class StackQueueQuestions
{
    public int MaxAreaHistogram(int[] heights)
    {
        int[] nsl = new int[heights.Length];
        int[] nsr = new int[heights.Length];

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < heights.Length; i++)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                stack.Pop();

            if (stack.Count == 0)
                nsl[i] = -1; //
            else
                nsl[i] = stack.Peek();

            stack.Push(i);
        }

        stack = new Stack<int>();

        for (int i = heights.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                stack.Pop();

            if (stack.Count == 0)
                nsr[i] = heights.Length;
            else
                nsr[i] = stack.Peek();

            stack.Push(i);
        }

        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            // (a,b): Open interval, includes all numbers strictly between a and b. => b−a−1
            int width = nsr[i] - nsl[i] - 1;
            int area = heights[i] * width;
            if (area > maxArea)
                maxArea = area;
        }

        return maxArea;
    }

    public List<int> NextSmallerLeftElement(int[] arr)
    {
        Stack<int> stack = new Stack<int>();
        List<int> result = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            while (stack.Count > 0 && stack.Peek() >= arr[i])
                stack.Pop();

            result.Add(stack.Count == 0 ? -1 : stack.Peek());

            stack.Push(i);
        }

        return result;
    }

    public List<int> StackSpanProblem(int[] arr)
    {
        Stack<int> stack = new Stack<int>();
        List<int> result = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            while (stack.Count() > 0 && arr[stack.Peek()] <= arr[i])
                stack.Pop();

            if (stack.Count == 0)
                result.Add(1);
            else
                result.Add(stack.Peek());

            stack.Push(i);
        }

        return result;
    }

    public List<int> NearestGreaterToLeft(int[] arr)
    {
        Stack<int> stack = new Stack<int>();
        List<int> result = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            while (stack.Count > 0 && stack.Peek() <= arr[i])
                stack.Pop();

            if (stack.Count == 0)
                result.Add(-1);
            else
                result.Add(stack.Peek());

            stack.Push(arr[i]);
        }

        return result;
    }

    // Input: s = "the sky is blue"
    // Output: "blue is sky the"
    public string ReverseWords1(string s)
    {
        if (string.IsNullOrEmpty(s)) return string.Empty;

        Stack<string> stack = new Stack<string>();
        string word = string.Empty;

        foreach (char c in s)
        {
            if (c == ' ')
            {
                if (!string.IsNullOrEmpty(word)) stack.Push(word); // case: Akshay  tilekar, double space
                word = string.Empty;
            }
            else
                word += c;
        }

        if (!string.IsNullOrEmpty(word)) stack.Push(word); // case - only 1 word - Hello

        string result = string.Empty;
        while (stack.Count != 0)
        {
            result += " " + stack.Pop();
        }

        return result.Trim();
    }

    //  Input: s = "Mr Ding"
    //  Output: "rM gniD"
    public string ReverseWords2(string s)
    {
        var result = new StringBuilder(s.Length);
        var stack = new Stack<char>();

        foreach (var current in s)
        {
            if (current == ' ')
            {
                while (stack.Count > 0)
                    result.Append(stack.Pop());

                result.Append(' ');
            }
            else
                stack.Push(current);
        }

        while (stack.Count > 0)
            result.Append(stack.Pop());

        return result.ToString();
    }

    public int EvalReversePolishNotation(string[] tokens)
    {
        List<string> operators = new List<string> { "+", "-", "*", "/" };
        Stack<int> stack = new Stack<int>();
        foreach (string token in tokens)
        {
            if (!operators.Contains(token))
                stack.Push(int.Parse(token));

            int b = stack.Pop();
            int a = stack.Pop();
            switch (token)
            {
                case "+": stack.Push(a + b); break;
                case "-": stack.Push(a - b); break;
                case "*": stack.Push(a * b); break;
                case "/": stack.Push(a / b); break;
            }
        }

        return stack.Pop();
    }

    public int RemoveConsecutiveSame(List<string> strings)
    {
        Stack<string> stack = new Stack<string>();

        foreach (string item in strings)
        {
            if (stack.Count == 0)
                stack.Push(item);
            else
            {
                if (stack.Peek().Equals(item))
                    stack.Pop();
                else
                    stack.Push(item);
            }
        }

        return stack.Count;
    }
                                               
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
        result.Reverse();
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

    public int LongestValidParentheses2(string str)
    {
        var max = 0;
        int cnt = 0;
        var stack = new Stack<int>();
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i] == '(')
                stack.Push(i);
            else
            {
                if (stack.Count == 0)
                    cnt = 0;
                else
                {
                    stack.Pop();
                    max = Math.Max(max, ++cnt);
                }
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

    public List<int> NextGreterElemen1t(int[] arr)
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

    public int[] DailyTemperatures(int[] arr)
    {
        Stack<int> stack = new Stack<int>();
        int[] answer = new int[arr.Length];

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (stack.Count() == 0) answer[i] = -1;
            else if (stack.Count() > 0 && stack.Peek() > arr[i])
                answer[i] = stack.Peek();
            else if (stack.Count() > 0 && stack.Peek() < arr[i])
            {
                while (stack.Count() > 0 && stack.Peek() < arr[i])
                    stack.Pop();
            }

            if (stack.Count == 0)
                answer[i] = -1;
            else
                answer[i] = stack.Peek();

            stack.Push(arr[i]);
        }
        return answer;
    }

    public List<int> NextSmallerElement1(int[] arr)
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

    public int[] DailyTemperatures1(int[] arr)
    {

        Stack<int> stack = new Stack<int>();
        int[] answer = new int[arr.Length];

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && arr[stack.Peek()] <= arr[i])
                stack.Pop();
            answer[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
            stack.Push(i);
        }
        return answer;
    }

    public static int[] NextGreaterElementsCircular(int[] arr)
    {
        int[] ngr = new int[arr.Length];
        Stack<int> stack = new Stack<int>();
        int n = arr.Length;

        for (int i = 2 * n - 1; i >= 0; i--)
        {
            while (stack.Count != 0 && stack.Peek() <= arr[i % n])
                stack.Pop();

            if (stack.Count == 0)
                ngr[i % n] = -1;
            else
                ngr[i % n] = stack.Peek();

            stack.Push(arr[i % n]);
        }

        return ngr;
    }

    public static int[] NextGreaterToLeftCircular(int[] arr)
    {
        int n = arr.Length;
        int[] ngl = new int[n];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < 2 * n; i++)
        {
            while (stack.Count > 0 && stack.Peek() <= arr[i % n])
                stack.Pop();

            if (stack.Count == 0)
                ngl[i % n] = -1;
            else
                ngl[i % n] = stack.Peek();

            stack.Push(arr[i % n]);
        }

        return ngl;
    }

    public static int[] NextSmallerToLeftCircular(int[] arr)
    {
        int n = arr.Length;
        int[] nsl = new int[n];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < 2 * n; i++)
        {
            while (stack.Count > 0 && stack.Peek() >= arr[i % n])
                stack.Pop();

            if (stack.Count == 0)
                nsl[i % n] = -1;
            else
                nsl[i % n] = stack.Peek();

            stack.Push(arr[i % n]);
        }

        return nsl;
    }

    public static int[] NextSmallerToRightCircular(int[] arr)
    {
        int n = arr.Length;
        int[] nsr = new int[n];
        Stack<int> stack = new Stack<int>();

        for (int i = 2 * n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && stack.Peek() >= arr[i % n])
                stack.Pop();

            if (stack.Count == 0)
                nsr[i % n] = -1;
            else
                nsr[i % n] = stack.Peek();

            stack.Push(arr[i % n]);
        }

        return nsr;
    }

    public void CircularArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < 2 * n; i++)
            Console.WriteLine("value is " + i % n);
    }

}
