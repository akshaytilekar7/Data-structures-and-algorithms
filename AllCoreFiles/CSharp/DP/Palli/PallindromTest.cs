namespace CSharp.DP.Palli
{
    public class PallindromTest
    {
        public static void Main()
        {
            var str = "akshay";
            Pallindrome pallindrome = new Pallindrome(str.Length);

            var len = pallindrome.GetMinimumPartitionForPallindromeRecursive(str, 0, str.Length - 1);
            Console.WriteLine(len);

            pallindrome = new Pallindrome(str.Length);
            len = pallindrome.GetMinimumPartitionForPallindromeBottomUp1(str, 0, str.Length - 1);
            Console.WriteLine(len);

            pallindrome = new Pallindrome(str.Length);
            len = pallindrome.GetMinimumPartitionForPallindromeBottomUp2NotWorking(str, 0, str.Length - 1);
            Console.WriteLine(len);

            pallindrome = new Pallindrome(str.Length);
            len = pallindrome.Solve(str, 0, str.Length - 1);
            Console.WriteLine(len);


            Console.ReadLine();
        }
    }
}
