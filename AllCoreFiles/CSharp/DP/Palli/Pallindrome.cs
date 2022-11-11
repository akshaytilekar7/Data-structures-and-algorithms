namespace CSharp.DP.Palli
{
    public class Pallindrome
    {
        int[,] bu;
        int[,] td;

        public Pallindrome(int i)
        {
            bu = new int[i, i];
            td = new int[i, i];
        }
        public int GetMinimumPartitionForPallindromeRecursive(string s1, int i, int j)
        {
            if (i >= j) return 0;

            if (IsPallindrome1(s1, i, j))
                return 0;

            int min = int.MaxValue;
            for (int k = i; k < j; k++)
            {
                var x = GetMinimumPartitionForPallindromeRecursive(s1, i, k);
                var y = GetMinimumPartitionForPallindromeRecursive(s1, k + 1, j);
                var temp = x + y + 1;
                if (temp < min)
                    min = temp;
            }

            return min;
        }
        public int GetMinimumPartitionForPallindromeBottomUp1(string s1, int i, int j)
        {
            if (i >= j) return 0;

            if (bu[i, j] != 0) return bu[i, j];

            if (IsPallindrome1(s1, i, j))
                return 0;

            int min = int.MaxValue;
            for (int k = i; k < j; k++)
            {
                var x = GetMinimumPartitionForPallindromeBottomUp1(s1, i, k);
                var y = GetMinimumPartitionForPallindromeBottomUp1(s1, k + 1, j);
                var temp = bu[i, j] = x + y + 1;
                if (temp < min)
                    min = temp;
            }

            return min;
        }
        public int GetMinimumPartitionForPallindromeBottomUp2NotWorking(string s1, int i, int j)
        {
            if (i >= j) return 0;

            if (IsPallindrome1(s1, i, j))
                return 0;

            if (bu[i, j] != 0)
                return bu[i, j];

            int min = int.MaxValue;
            int left, right;
            for (int k = i; k < j; k++)
            {
                if (bu[i, k] != 0)
                    bu[i, k] = left = GetMinimumPartitionForPallindromeBottomUp2NotWorking(s1, i, k);
                else
                    left = bu[i, k];

                if (bu[k + 1, j] != 0)
                    bu[k + 1, j] = right = GetMinimumPartitionForPallindromeBottomUp2NotWorking(s1, k + 1, j);
                else
                    right = bu[k + 1, j];

                var temp = bu[i, j] = left + right + 1;
                if (temp < min)
                    min = temp;
            }

            return min;
        }
        public int GetMinimumPartitionForPallindromeTopDown(string s1, int i, int j)
        {
            if (i >= j) return 0;

            for (int k = 0; k < j; k++)
            {
                td[i, j] = td[i, k] + td[k + 1, j] + 1;
            }

            //return td[i, j];
            return 0;
        }

        public int Solve(string s, int i, int j)
        {
            if (i >= j)
                return 0;

            if (td[i, j] != 0)
                return td[i, j];

            if (IsPallindrome1(s, i, j))
                return 0;

            int final = int.MaxValue;

            for (int k = i; k < j; k++)
            {
                if (td[i, k] == 0)
                    td[i, k] = Solve(s, i, k);
                if (td[k + 1, j] == 0)
                    td[k + 1, j] = Solve(s, k + 1, j);

                int tempans = 1 + td[i, k] + td[k + 1, j];
                final = Math.Min(final, tempans);
            }

            td[i, j] = final;
            return td[i, j];
        }
        private bool IsPallindrome1(string s1, int i, int j)
        {
            var subStr = s1.Substring(i, j - i + 1);
            char[] charArray = subStr.ToCharArray();
            Array.Reverse(charArray);
            var rev = new string(charArray);
            return subStr == rev;
        }
        private bool IsPalindrome2(string s, int i, int j)
        {
            while (i < j)
            {
                if (s[i] != s[j]) return false;
                i++;
                j--;
            }
            return true;
        }
    }
}
