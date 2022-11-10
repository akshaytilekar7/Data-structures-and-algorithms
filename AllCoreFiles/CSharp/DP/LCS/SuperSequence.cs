namespace CSharp.DP.LCS
{
    public class SuperSequence
    {
        int[,] td;
        LongestCommonSubsequence longestCommonSubsequence;
        public SuperSequence(int size1, int size2)
        {
            td = new int[size1 + 1, size2 + 1];
            longestCommonSubsequence = new LongestCommonSubsequence(size1, size2);
        }
        public int GetLengthShortest(string s1, string s2, int m, int n)
        {
            var len = longestCommonSubsequence.GetLengthTopDown(s1, s2, m, n);
            td = longestCommonSubsequence.td;
            return m + n - len;
        }
        public string Print(string s1, string s2, int i, int j)
        {
            if (i == 0 || j == 0) return string.Empty;

            string result = string.Empty;

            while (i > 0 && j > 0)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    result = result + s1[i - 1].ToString();
                    i--;
                    j--;
                }
                else
                {
                    if (td[i - 1, j] < td[i, j - 1])
                    {
                        result = result + s2[j - 1].ToString();
                        j--;
                    }
                    else
                    {
                        result = result + s1[i - 1].ToString();
                        i--;
                    }
                }
            }
       
            while (i > 0)
            {
                result = result + s1[i - 1].ToString();
                i--;
            }

            while (j > 0)
            {
                result = result + s2[j - 1].ToString();
                j--;
            }

            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }

}
