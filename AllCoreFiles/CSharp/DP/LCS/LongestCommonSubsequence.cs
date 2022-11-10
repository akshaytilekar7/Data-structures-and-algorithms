namespace CSharp.DP.LCS
{
    public class LongestCommonSubsequence
    {
        public int[,] bu;
        public int[,] td;
        public LongestCommonSubsequence(int size1, int size2)
        {
            bu = new int[size1 + 1, size2 + 1];
            td = new int[size1 + 1, size2 + 1];
        }

        public int GetLengthRecursive(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0) return 0;

            if (s1[m - 1] == s2[n - 1])
            {
                // Console.Write("   " + s1[m - 1]);
                return 1 + GetLengthRecursive(s1, s2, m - 1, n - 1);
            }
            else
                return Math.Max(GetLengthRecursive(s1, s2, m - 1, n), GetLengthRecursive(s1, s2, m, n - 1));
        }

        public int GetLengthBottomUp(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0) return 0;

            if (bu[m, n] != 0) return bu[m, n];

            if (s1[m - 1] == s2[n - 1])
            {
                // Console.Write("   " + s1[m - 1]);
                return bu[m, n] = 1 + GetLengthBottomUp(s1, s2, m - 1, n - 1);
            }
            else
                return bu[m, n] = Math.Max(GetLengthBottomUp(s1, s2, m - 1, n), GetLengthBottomUp(s1, s2, m, n - 1));
        }

        public int GetLengthTopDown(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0) return 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        td[i, j] = 1 + td[i - 1, j - 1];
                    else
                        td[i, j] = Math.Max(td[i - 1, j], td[i, j - 1]);
                }
            }

            return td[m, n];
        }

        public string PrintLCSNotWorking(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0) return string.Empty;

            string result = string.Empty;
            for (int i = m; i > 0; i--)
            {
                for (int j = n; j > 0; j--)
                {
                    if (i == 0 || j == 0) break;
                    if (td[i - 1, j - 1] == td[i - 1, j - 1])
                    {
                        result = result + (s1[i - 1]).ToString();
                        i--;
                        j--;
                    }
                    else
                    {
                        if (td[i - 1, j] < td[i, j - 1])
                            j--;
                        else
                            i--;
                    }
                }
            }
            if (string.IsNullOrEmpty(result)) return result;

            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string PrintLCS2(string s1, string s2, int i, int j)
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
                        j--;
                    else
                        i--;
                }
            }

            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


    }
}
