namespace CSharp.DP
{
    public class RodCut2
    {
        static long input = Convert.ToInt32(10);
        static long length = input + 1;
        static long[] arr = { 0, 5, 4, 9, 8, 13, 12, 17, 16, 21 };
        public static void Main123()
        {
            long i;

            Console.WriteLine("Showing p:");
            for (i = 1; i < length; ++i)
                Console.Write("arr[" + i + "]:" + arr[i - 1] + "\n");

            for (i = 0; i < length; ++i)
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

            for (i = 1; i < index / 2; ++i)
            {
                long ri = ComputeRod(i) + ComputeRod(index - i);
                if (ri > arrVal)
                    arrVal = ri;
            }

            return arrVal;
        }

    }
}
