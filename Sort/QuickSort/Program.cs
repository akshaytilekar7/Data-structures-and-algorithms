using QuickSort;

public class Client
{
    public static void Main()
    {
        QuickSortAlgo sort = new QuickSortAlgo();
        int[] arr2 = { 980, 34, 64, 8, 2, 43, 94, 28, -98, 43, 2, 32, 100, 50, 165, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };
        sort.Sort(arr2);
        sort.Print(arr2);

        Console.ReadLine();
    }
}
