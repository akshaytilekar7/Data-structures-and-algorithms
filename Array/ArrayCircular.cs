namespace PraticeBP;

public class ArrayCircular
{
    /// <summary>
    /// TC: O(m*n)
    /// SC: O(m*n)
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public List<int> ArrayInSpiralReverse(int[,] arr)
    {
        var lst = new List<int>();

        var m = arr.GetLength(0) - 1;
        var n = arr.GetLength(1) - 1;

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        var rev = false;
        while (queue.Count > 0)
        {
            List<int> temp = new List<int>();
            var cnt = queue.Count;
            for (int i = 0; i < cnt; i++)
            {
                var (row, col) = queue.Dequeue();
                temp.Add(arr[row, col]);

                if (row + 1 <= m && col == 0)
                    queue.Enqueue((row + 1, col));
                if (col + 1 <= n)
                    queue.Enqueue((row, col + 1));
            }

            if (rev) temp.Reverse();
            lst.AddRange(temp);
            rev = !rev;
        }

        return lst;

    }

    /// <summary>
    /// TC: O(m*n)
    /// SC: O(m*n)
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public List<int> ArrayInSpiral(int[,] arr)
    {
        var lst = new List<int>();

        var m = arr.GetLength(0) - 1;
        var n = arr.GetLength(1) - 1;

        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((0, 0));

        while (q.Count > 0)
        {
            var cnt = q.Count;

            for (var z = 0; z < cnt; z++)
            {
                var (row, col) = q.Dequeue();
                lst.Add(arr[row, col]);

                // for boundry check row + 1 as we are adding that index row + 1
                // col == 0 as to avoid duplicates 
                if (row + 1 <= m && col == 0)
                    q.Enqueue((row + 1, col));

                if (n >= col + 1)
                    q.Enqueue((row, col + 1));
            }
        }
        return lst;

    }

    /// <summary>
    /// TC: O(m*n)
    /// SC: O(m*n)
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public List<int> ArrayInCircular(int[,] arr)
    {
        List<int> ints = new List<int>();

        var colStart = 0;
        var colEnd = arr.GetLength(1) - 1;
        var rowStart = 0;
        var rowEnd = arr.GetLength(0) - 1;

        while (colStart <= colEnd && rowStart <= rowEnd)
        {
            // no check for first 2 for loop as they are always executed when entering the while loop
            for (var i = colStart; i <= colEnd; i++)
                ints.Add(arr[rowStart, i]);
            rowStart++;

            for (var i = rowStart; i <= rowEnd; i++)
                ints.Add(arr[i, colEnd]);
            colEnd--;

            // need boundary checks to avoid reprocessing rows or columns that have already been handled
            // especially when the matrix size is not balanced 
            if (colStart <= colEnd)
            {
                for (var i = colEnd; i >= colStart; i--)
                    ints.Add(arr[rowEnd, i]);
                rowEnd--;
            }

            if (rowStart <= rowEnd)
            {
                for (var i = rowEnd; i >= rowStart; i--)
                    ints.Add(arr[i, colStart]);
                colStart++;
            }
        }

        return ints;
    }
}
