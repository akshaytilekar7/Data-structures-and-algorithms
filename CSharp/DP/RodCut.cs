namespace CSharp.DP
{
    public class RodCut
    {
        static long length = 11;
        static long[] arr = new long[length];
        public static void Main()
        {
            for (int i = 1; i < length; ++i)
            {
                if (i % 2 == 0)
                    arr[i] = 2 * i + 1;
                else
                    arr[i] = 2 * i - 2;
            }

            Console.WriteLine("Showing p:");
            for (int i = 1; i < length; ++i)
                Console.Write("arr[" + i + "]:" + arr[i] + "\n");

            for (int i = 1; i < length; ++i)
            {
                long rs = ComputeRod(i);
                Console.WriteLine("r[" + i + "]:" + rs + "\n");
            }

            Console.WriteLine("END $$$$$$$$$$$$$$$$$$");
        }

        public static long ComputeRod(long index)
        {
            long i;
            long arrVal = arr[index];
            if (index == 1)
                return arr[1];

            for (i = 1; i <= index / 2; ++i)
            {
                long ri = ComputeRod(i) + ComputeRod(index - i);
                if (ri > arrVal)
                    arrVal = ri;
            }

            return arrVal;
        }

    }
}
