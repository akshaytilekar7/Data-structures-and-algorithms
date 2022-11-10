namespace CSharp.DP.LCS
{
    public class SuperSequenceTest
    {
        public static void Main123()
        {
            string str1 = "HELLO";
            string str2 = "GEEK";

            var obj = new SuperSequence(str1.Length, str2.Length);

            var len = obj.GetLengthShortest(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + len);

            var str = obj.Print(str1, str2, str1.Length, str2.Length);
            Console.WriteLine("\n" + str);

            Console.ReadLine();
        }
    }
}
