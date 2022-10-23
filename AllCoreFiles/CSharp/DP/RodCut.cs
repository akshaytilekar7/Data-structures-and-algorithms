namespace CSharp.DP
{
    public class RodCut
    {
        public static void Main()
        {
            long i;
            long input = Convert.ToInt32(10);
            long length = input + 1;
            long[] arr = new long[length];

            for (i = 1; i < length; ++i)
            {
                if (i % 2 == 0)
                    arr[i] = 2 * i + 1;
                else
                    arr[i] = 2 * i - 2;
            }

            Console.WriteLine("Showing p:");
            for (i = 1; i < length; ++i)
                Console.Write("arr[" + i + "]:" + arr[i] + "\n");

            for (i = 1; i < length; ++i)
            {
                long rs = ComputeRod(i, arr);
                Console.WriteLine("r[" + i + "]:" + rs + "\n");
            }

            Console.WriteLine("END $$$$$$$$$$$$$$$$$$");
        }

        public static long ComputeRod(long index, long[] arr)
        {
            long i;
            long arrVal = arr[index];
            if (index == 1)
                return arr[1];

            for (i = 1; i < index / 2; ++i)
            {
                long ri = ComputeRod(i, arr) + ComputeRod(index - i, arr);
                if (ri > arrVal)
                    arrVal = ri;
            }

            return arrVal;
        }

    }
}
