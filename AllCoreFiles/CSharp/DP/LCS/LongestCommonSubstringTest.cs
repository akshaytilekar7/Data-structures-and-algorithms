namespace CSharp.DP.LCS
{
    public class LongestCommonSubstringTest
    {
        public static void Main123()
        {
            string str1 = "acb1dgh";
            string str2 = "acb1edfhr";

            var obj = new LongestCommonSubstring(str1.Length, str2.Length);

            var len = obj.GetLengthRecursive(str1, str2, str1.Length, str2.Length, 0);
            Console.WriteLine("\n" + len);

            len = obj.GetLengthBottomUp(str1, str2, str1.Length, str2.Length, 0);
            Console.WriteLine("\n" + len);

            len = obj.GetLengthTopDown0(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + len);

            len = obj.GetLengthTopDown1(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + len);

            len = obj.GetLengthTopDown2(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + len);
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
