namespace JumpSearch
{
    public class JumpSearch
    {
        // https://www.youtube.com/watch?v=wNOoyZ45SmQ&list=PLEJXowNB4kPwTb4BivkY0dENHmXdOEM3V
        public int JumpSearchAlgo(int[] arr, int value)
        {
            int length = arr.Length;

            // Finding block size to be jumped
            int step = (int)Math.Sqrt(length);

            // Finding the block where element is present (if it is present)
            int prev = 0;
            while (arr[Math.Min(step, length) - 1] < value)
            {
                prev = step;
                if (prev >= length)
                    return -1; // means out of array
                step += (int)Math.Sqrt(length);
            }

            while (arr[prev] < value)
            {
                prev++;
                // If we reached next block or end of array, element is not present.
                if (prev == Math.Min(step, length))
                    return -1;
            }

            // If element is found
            if (arr[prev] == value)
                return prev;

            return -1;
        }
    }
}
