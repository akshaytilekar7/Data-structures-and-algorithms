namespace BucketRadixSort
{
    public class BucketRadixSort
    {
        public void Sort(int[] array)
        {
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
                if (max < array[i])
                    max = array[i];

            for (int place = 1; max / place > 0; place *= 10)
                CountingSort(array, place); // for 3 dight number -  place value is 1 10 100 
        }
        public void CountingSort(int[] array, int place)
        {
            int[] bucket = new int[10];
            int[] output = new int[array.Length];

            // save freq of number in freq array
            // array[i] / place - remove last unnecessary digits
            // % 10 :- gives you last number remaining digit
            for (int i = 0; i < array.Length; i++)
                bucket[(array[i] / place) % 10]++;

            // count[i] now contains actual  position of this digit in output[] 
            for (int i = 1; i < 10; i++)
                bucket[i] = bucket[i] + bucket[i - 1];

            //Build the output array 
            for (int i = array.Length - 1; i >= 0; i--)
            {
                output[bucket[(array[i] / place) % 10] - 1] = array[i];
                bucket[(array[i] / place) % 10]--;
            }

            for (int i = 0; i < array.Length; i++)
                array[i] = output[i];
        }
        public void Print(int[] array)
        {
            Console.WriteLine();
            foreach (var item in array)
                Console.Write(" [{0}] ", item);
            Console.WriteLine();
        }

    }
}
