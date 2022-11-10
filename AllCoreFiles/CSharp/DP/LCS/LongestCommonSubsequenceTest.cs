namespace CSharp.DP.LCS
{
    public class LongestCommonSubsequenceTest
    {
        public static void Main123()
        {
            string str1 = "acb1dghr";
            string str2 = "acb1edfhr";

            var obj = new LongestCommonSubsequence(str1.Length, str2.Length);

            var len = obj.GetLengthRecursive(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + len);

            len = obj.GetLengthBottomUp(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + len);

            len = obj.GetLengthTopDown(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + len);

            var str = obj.PrintLCSNotWorking(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + str);

            str = obj.PrintLCS2(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + str);

            Console.ReadLine();
        }
    }
}
