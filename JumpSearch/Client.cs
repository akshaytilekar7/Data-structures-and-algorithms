namespace JumpSearch
{
    public class Client
    {
        public static void Main()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Array.Sort(array);
            
            JumpSearchMine mine = new JumpSearchMine();
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, -1));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, -10));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 0));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 1));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 2));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 3));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 9));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 6));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 6));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 7));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 10));
            Console.WriteLine("Index {0}", mine.JumpSearchAlgo(array, 12));
        }
    }
}
