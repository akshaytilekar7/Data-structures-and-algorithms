namespace JumpSearch
{
    internal class JumpSearchMine
    {
        public int JumpSearchAlgo(int[] array, int value)
        {
            int sqRoot = (int)Math.Sqrt(array.Length);
            int blockSize = sqRoot;
            int length = array.Length - 1;

            int prevIndex = 0;
            while (blockSize < length && array[blockSize] < value)
            {
                prevIndex = blockSize;
                if (prevIndex >= length) return -1;
                blockSize += sqRoot;
            }

            for (int i = prevIndex; i < array.Length; i++)
                if (array[i] == value)
                    return i;

            return -1;
        }
    }
}
