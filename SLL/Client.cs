namespace SLL
{
    public class Client
    {
        public static void Main()
        {
            SLLService linkList = new SLLService();

            var arr = new int[] { 1, 2134, 2, 3, 4, 5, 1, 1, 32, 1, 2134, 1 };
            Console.WriteLine("Is Empty {0}", linkList.IsEmpty());

            foreach (var item in arr)
                linkList.AddLast(item);

            linkList.AddFirst(5000);
            linkList.AddLast(6000);
            linkList.AddBefore(6000, -9000);
            linkList.AddBefore(6000, 56362);
            linkList.AddAfter(1, 1000);

            linkList.AddFirst(45000);
            linkList.AddLast(65000);
            linkList.AddBefore(-8888, -9000);
            linkList.AddBefore(-8888, 56362);
            linkList.AddAfter(-8888, 1000);

            linkList.Print();
            Console.WriteLine("First {0}", linkList.GetFirst());
            Console.WriteLine("Last {0}", linkList.GetLast());
            Console.WriteLine("Pop First {0}", linkList.PopFirst());
            Console.WriteLine("Pop Last {0}", linkList.PopLast());
            linkList.Print();

            Console.WriteLine(linkList.IsExist(2));
            Console.WriteLine(linkList.IsExist(6000));
            Console.WriteLine(linkList.IsExist(-40));
            Console.WriteLine("Is Empty {0}", linkList.IsEmpty());

            linkList.Print();
            linkList.Delete(6000);
            linkList.Delete(1);
            linkList.Delete(5000);
            linkList.Delete(5);

            linkList.DeleteFirstOccurance(32);
            linkList.DeleteLastOccurance(2134);
            linkList.Print();

            linkList.DeleteAllOccurance(1);

            linkList.DeleteFirstOccurance(50);
            linkList.DeleteLastOccurance(50);
            linkList.DeleteAllOccurance(50);

            linkList.Print();

            Console.WriteLine("Done");
        }
    }
}
