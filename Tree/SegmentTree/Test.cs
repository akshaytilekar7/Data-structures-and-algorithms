namespace SegmentTree;

public static class Client
{
    public static void Main()
    {
        int[] arr = { 3, 8, 6, 7, -2, -8, 4, 9 };
        SegmentTree tree = new SegmentTree(arr);

        tree.Display();

        Console.WriteLine(tree.Query(1, 6));
        Console.ReadLine();
    }
}
