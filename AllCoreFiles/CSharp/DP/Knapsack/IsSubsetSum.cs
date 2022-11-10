// int arr[] = {2,5,9,4}
// int sum = 11
// return true false

// can 11 sum obtained from subset 
namespace CSharp.DP.Knapsack
{
    public class IsSubsetSum
    {
        bool[,] dpBottomUp;
        bool[,] td;
        public IsSubsetSum(int n, int sum)
        {
            dpBottomUp = new bool[n + 1, n + 1];
            td = new bool[n + 1, sum + 1];
        }

        public bool Recursive(int[] arr, int n, int sum)
        {
            if (sum == 0) return true;
            if (n == 0) return false;

            if (arr[n - 1] <= sum)
            {
                return
                    Recursive(arr, n - 1, sum - arr[n - 1])
                      || Recursive(arr, n - 1, sum);
            }
            else
                return Recursive(arr, n - 1, sum);
        }

        public bool RecursiveBottomUP(int[] arr, int n, int sum)
        {
            if (sum == 0) return true;
            if (n == 0) return false;

            if (dpBottomUp[n, n] != false) return true;

            if (arr[n - 1] <= sum)
            {
                dpBottomUp[n, n] = RecursiveBottomUP(arr, n - 1, sum - arr[n - 1])
                       || RecursiveBottomUP(arr, n - 1, sum);
                return dpBottomUp[n, n];
            }
            else
                return dpBottomUp[n, n] = RecursiveBottomUP(arr, n - 1, sum);
        }

        public bool TopDown(int[] arr, int n, int sum)
        {
            for (int i = 0; i <= n; i++)
                td[i, 0] = true; /////////////

            for (int i = 1; i <= n; i++) //////////1
            {
                for (int j = 1; j <= sum; j++) //////////1
                {
                    if (arr[i - 1] <= j)
                        td[i, j] = td[i - 1, j - arr[i - 1]] || td[i - 1, j];
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
