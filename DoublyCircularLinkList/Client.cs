namespace DoublyCircularLinkList
{
    public class Client
    {
        public static void Main()
        {
            DCLLService linkList = new DCLLService();

            var arr = new int[] { 1, 5, 100, 5321, 5, 6345, -5, 5, 324, 65, 5 };
            Console.WriteLine("Is Empty {0}", linkList.IsEmpty());

            foreach (var item in arr)
                linkList.AddLast(item);

            linkList.AddFirst(5000);
            linkList.AddLast(6000);
            linkList.AddBefore(6000, -9000);
            linkList.AddBefore(6000, 56362);
            linkList.AddAfter(1, 1000);

            //Console.WriteLine(linkList.GetFirst());
            //Console.WriteLine(linkList.GetLast());
            //linkList.Print();
            //Console.WriteLine(linkList.PopLast());
            //Console.WriteLine(linkList.PopFirst());
            //linkList.Print();
            //Console.WriteLine(linkList.IsExist(-90));
            //Console.WriteLine(linkList.IsExist(100));
            //Console.WriteLine(linkList.IsExist(40));
            //Console.WriteLine("Is Empty {0}", linkList.IsEmpty());
            //linkList.Delete(6000);
            //linkList.Delete(1);
            //linkList.Delete(5000);
            //linkList.Delete(5);

            linkList.Print();
            linkList.DeleteFirstOccurance(5);
            linkList.DeleteLastOccurance(5);
            linkList.DeleteAllOccurance(5);

            linkList.DeleteFirstOccurance(50);
            linkList.DeleteLastOccurance(50);
            linkList.DeleteAllOccurance(50);

            linkList.Print();

            Console.WriteLine("Done");
        }
    }
}
