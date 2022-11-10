namespace CSharp.DP.LCS
{
    public class LongestCommonSubstring
    {
        int[,] bu;
        int[,] td;
        public LongestCommonSubstring(int size1, int size2)
        {
            bu = new int[size1 + 1, size2 + 1];
            td = new int[size1 + 1, size2 + 1];
        }

        public int GetLengthRecursive(string s1, string s2, int m, int n, int count)
        {
            if (m == 0 || n == 0) return count;
            if (s1[m - 1] == s2[n - 1])
                count = GetLengthRecursive(s1, s2, m - 1, n - 1, count + 1);
            else
                count = Math.Max(count, Math.Max(GetLengthRecursive(s1, s2, m, n - 1, 0), GetLengthRecursive(s1, s2, m - 1, n, 0)));
            return count;
        }

        public int GetLengthBottomUp(string s1, string s2, int m, int n, int count)
        {
            if (m == 0 || n == 0) return count;

            if (bu[m, n] != 0) return bu[m, n];

            if (s1[m - 1] == s2[n - 1])
                bu[m, n] = count = GetLengthRecursive(s1, s2, m - 1, n - 1, count + 1);
            else
                bu[m, n] = count = Math.Max(count, Math.Max(GetLengthRecursive(s1, s2, m, n - 1, 0), GetLengthRecursive(s1, s2, m - 1, n, 0)));
            return count;
        }

        public int GetLengthTopDown0(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0) return 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        bu[i, j] = 1 + bu[i - 1, j - 1];
                    else
                        bu[m, n] = Math.Max(bu[m, n], Math.Max(bu[m, n - 1], bu[m - 1, n]));
                }
            }
            return bu[m, n];
        }

        public int GetLengthTopDown1(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0) return 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        bu[i, j] = 1 + bu[i - 1, j - 1];
                    else
                        bu[i, j] = 0;
                }
            }

            int max = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    var val = bu[i, j];
                    if (val > max)
                        max = val;
                }
            }
            return max;
        }

        public int GetLengthTopDown2(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            int max = 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        bu[i, j] = 1 + bu[i - 1, j - 1];
                        if (bu[i, j] > max)
                            max = bu[i, j];
                    }
                }
            }

            return max;
        }
    }
}
