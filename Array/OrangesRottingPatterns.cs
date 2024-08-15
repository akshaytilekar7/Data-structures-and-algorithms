using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array;

public class OrangesRottingPatterns
{
    /// <summary>
    /// TC: O(m*n)
    /// SC: O(m*n)
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int OrangesRotting(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var freshOranges = 0;
        Queue<(int, int)> rottenQueue = new Queue<(int, int)>();
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 2)
                    rottenQueue.Enqueue((i, j));
                else if (grid[i][j] == 1)
                    freshOranges++;
            }

        if (freshOranges == 0) return 0; // No fresh oranges present

        int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];

        int days = 0;
        while (rottenQueue.Count > 0)
        {
            var cnt = rottenQueue.Count;
            bool anyRotten = false;
            for (int i = 0; i < cnt; i++)
            {
                var (x, y) = rottenQueue.Dequeue();
                foreach (var dir in directions)
                {
                    int newX = x + dir[0];
                    int newY = y + dir[1];

                    if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && grid[newX][newY] == 1)
                    {
                        grid[newX][newY] = 2;
                        rottenQueue.Enqueue((newX, newY));
                        freshOranges--;
                        anyRotten = true;
                    }
                }
            }
            if (anyRotten) days++;
        }
        return freshOranges == 0 ? days : -1;
    }
}
