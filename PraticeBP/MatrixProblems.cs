namespace PraticeBP;

public class MatrixProblems
{
    static int row = 4, col = 6;

    private static int Max(int a, int b) => a > b ? a : b;


    public static int FindMaxPath(int[,] mat)
    {
        int[,] dp = new int[row, col];

        for (int j = 0; j < col; j++)
            dp[0, j] = mat[0, j];


        for (int i = 1; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                int down = dp[i - 1, j];

                int left = (j > 0) ? dp[i - 1, j - 1] : int.MinValue;

                int right = (j < col - 1) ? dp[i - 1, j + 1] : int.MinValue;

                dp[i, j] = mat[i, j] + Max(down, Max(left, right));
            }
        }

        int res = int.MinValue;
        for (int j = 0; j < col; j++)
            res = Max(res, dp[row - 1, j]);

        return res;
    }

    static public void Main(String[] args)
    {
        int[,] mat = {{10, 10, 2, 0, 20, 4},
                  {1, 0, 0, 30, 2, 5},
                  {0, 10, 4, 0, 2, 0},
                  {1, 0, 2, 20, 0, 4}};

        Console.WriteLine(FindMaxPath(mat)); // Output: 74
    }

}
