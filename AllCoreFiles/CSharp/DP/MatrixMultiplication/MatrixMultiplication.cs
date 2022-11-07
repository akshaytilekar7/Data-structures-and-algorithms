namespace AllCoreFiles.CSharp.DP.MatrixMultiplication
{
    public class MatrixMultiplication
    {
        // public int[,] ArrParenthisis;
        private int[,] memo;
        public MatrixMultiplication(int len)
        {
            // ArrParenthisis = new int[len, len];
            memo = new int[len, len];
        }
        public int GetMinimumNumberOfMultplication(int[] arr, int i, int j)
        {

            if (i >= j) return 0;

            if(memo[i, j] != 0)
                return memo[i, j];

            int min = int.MaxValue;
            for (int k = i; k < j; k++)
            {
                var firstPart = GetMinimumNumberOfMultplication(arr, i, k);
                var secondPart = GetMinimumNumberOfMultplication(arr, k + 1, j);
                var result = firstPart + secondPart + (arr[i - 1] * arr[k] * arr[j]);
                if (result < min)
                {
                    memo[i,j] = result;
                    min = result;
                    // ArrParenthisis[i, j] = k;
                }
            }

            return min;
        }
        public int GetMaximumNumberOfMultplication(int[] arr, int i, int j)
        {
            if (i >= j) return 0;

            int max = int.MinValue;
            for (int k = i; k < j; k++)
            {
                var firstPart = GetMaximumNumberOfMultplication(arr, i, k);
                var secondPart = GetMaximumNumberOfMultplication(arr, k + 1, j);
                var result = firstPart + secondPart + (arr[i - 1] * arr[k] * arr[j]);
                if (result > max)
                {
                    max = result;
                    // ArrParenthisis[i, j] = k;
                }
            }

            return max;
        }

        public void PrintOptimalParens(int[,] arr, int i, int j)
        {
            if (i == j)
            {
                Console.Write("A%d", i);
            }
            else
            {
                Console.Write("(");
                PrintOptimalParens(arr, i, arr[i, j]);
                PrintOptimalParens(arr, arr[i, j] + 1, j);
                Console.Write(")");
            }
        }

        public static void Main123()
        {
            int[] arr = { 2, 3, 5, 10 };
            MatrixMultiplication matrixMultiplication = new MatrixMultiplication(arr.Length);

            var count = matrixMultiplication.GetMinimumNumberOfMultplication(arr, 1, arr.Length - 1);
            Console.WriteLine("MIN COUNT IS : " + count);

            count = matrixMultiplication.GetMaximumNumberOfMultplication(arr, 1, arr.Length - 1);
            Console.WriteLine("MAX COUNT IS : " + count);

            //matrixMultiplication.PrintOptimalParens(matrixMultiplication.ArrParenthisis, 1, matrixMultiplication.ArrParenthisis.Length -1 );
        }
    }
}
