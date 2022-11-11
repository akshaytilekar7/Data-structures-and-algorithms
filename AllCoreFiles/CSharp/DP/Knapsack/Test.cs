using CSharp.DP.Knapsack;
namespace CSharp.DP
{
    public class Test
    {
        public static void Main1()
        {
            int[] arr = { 1, 2, 2, 3, 4, 5 };
            int sum = 13;

            var obj = new CountSubsetSum(arr.Length, sum);

            var value = obj.Recursive(arr, arr.Length, sum);
            Console.WriteLine(value);

            value = obj.RecursiveBottomUP(arr, arr.Length, sum);
            Console.WriteLine(value);

            value = obj.TopDown(arr, arr.Length, sum);
            Console.WriteLine(value);

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
