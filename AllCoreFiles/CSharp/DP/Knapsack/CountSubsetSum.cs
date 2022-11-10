// int arr[] = {2,5,9,4}
// int sum = 11
// return true false

// can 11 sum obtained from subset 
namespace CSharp.DP.Knapsack
{
    public class CountSubsetSum
    {
        int[,] dpBottomUp;
        int[,] td;
        public CountSubsetSum(int n, int sum)
        {
            dpBottomUp = new int[n + 1, n + 1];
            td = new int[n + 1, sum + 1];
        }

        public int Recursive(int[] arr, int n, int sum)
        {
            if (sum == 0) return 1;
            if (n == 0) return 0;

            int count;
            if (arr[n - 1] <= sum)
            {
                count = Recursive(arr, n - 1, sum - arr[n - 1])
                        +
                        Recursive(arr, n - 1, sum);
            }
            else
                count = Recursive(arr, n - 1, sum);

            return count;
        }

        public int RecursiveBottomUP(int[] arr, int n, int sum)
        {
            if (sum == 0) return 1;
            if (n == 0) return 0;

            if (dpBottomUp[n, n] != 0) return dpBottomUp[n, n];

            int count;
            if (arr[n - 1] <= sum)
            {
                count = dpBottomUp[n, n] = Recursive(arr, n - 1, sum - arr[n - 1])
                         +
                         Recursive(arr, n - 1, sum);
            }
            else
                count = dpBottomUp[n, n] = Recursive(arr, n - 1, sum);

            return count;
        }

        public int TopDown(int[] arr, int n, int sum)
        {
            for (int i = 0; i <= n; i++)
                td[i, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (arr[i - 1] <= j)
                        td[i, j] = td[i - 1, j - arr[i - 1]] + td[i - 1, j];
                    else
                        td[i, j] = td[i - 1, j];
                }
            }

            return td[n, sum];
        }

        public void Print()
        {
            for (int i = 0; i < td.GetLength(0); i++)
            {
                for (int j = 0; j < td.GetLength(1); j++)
                {
                    Console.Write("  " + td[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

//           0       1        2       3       4       sum
//    0    true    false    false  false   false
//    5    true    false    false  false   false
//    2    true    false    true   false   false
//    9    true    false    true   false   false
//    7    true    false    true   false   false
//    1    true    true     true   true    false
//  number

//          0        1      2      3   sum
//    0    true    false   false   false
//    5    true    false   false   false
//    2    true    false   true    false
//    9    true    false   true    false
//    7    true    false   true    false
//    1    true    true    true    true
//  number
