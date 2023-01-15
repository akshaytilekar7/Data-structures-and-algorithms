namespace BinarySearch
{
    public class Client
    {
        public static void Main()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Array.Sort(array);


            BinarySearch binarySearch = new BinarySearch();

            Console.WriteLine("Index {0}", binarySearch.BinarySearchIterative(array, 1));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchIterative(array, 4));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchIterative(array, 7));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchIterative(array, 100));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchIterative(array, 5));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchIterative(array, 100));


            Console.WriteLine("Index {0}", binarySearch.BinarySearchRecursive(array, 1));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchRecursive(array, 4));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchRecursive(array, 7));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchRecursive(array, 100));
            Console.WriteLine("Index {0}", binarySearch.BinarySearchRecursive(array, 5));
        }
    }
}
