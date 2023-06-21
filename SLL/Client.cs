namespace SinglyLinkList
{
    public class Client
    {
        public static void Main()
        {
            SLLService service = new SLLService();
            SLLQuestions questions = new SLLQuestions(service);
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (var item in arr)
                service.AddLast(item);

            service.Print();
            var head = questions.SwapNodesInKPairNew(service.linklist.Next, 9);
            service.Print(head);

            //service.Print();
            //var head = questions.OddEvenLinkList(service.linklist.Next);
            //service.Print(head);

            //service.Print();
            //var head = questions.SortLinkList(service.linklist.Next);
            //service.Print(head);

            //service.Print();
            //var head = questions.SwapKthNodeFromBithEnd(service.linklist.Next, 5);
            //service.Print(head);

            //var head = questions.RemoveDuplicateFromSortedList(service.linklist.Next);
            //Console.WriteLine($"IsPallindrome : {questions.IsPallindrome(service.linklist.Next)}");

            //service.Print();
            //var node = questions.RemoveNthNodeFromEndOfList(service.linklist.Next, 5);
            //service.Print(node);

            //#region mergeSortedList

            //SLLService service1 = new SLLService();
            //SLLService service2 = new SLLService();

            //var arr1 = new int[] { 10, 4, 15, 50, 20, 15 };
            //var arr2 = new int[] { 5, 6, 4 };
            //foreach (var item in arr1)
            //    service1.AddLast(item);

            //foreach (var item in arr2)
            //    service2.AddLast(item);

            //service1.Print("arr1");
            //service2.Print("arr2");


            //SLLQuestions questions = new SLLQuestions(service1);
            //Console.WriteLine($"After Addding");
            //var node = questions.AddTwoList(service1.linklist.Next, service2.linklist.Next);
            //service1.Print(node);

            //Console.WriteLine($"Cycle Exist : { questions.IsCycleExist(service1.linklist) }");

            //#endregion mergeSortedList

            //linkList.Print();
            //var reverseHead = linkList.ReverseListImmutable();
            //linkList.Print(reverseHead);

            //linkList.Print();
            //Console.WriteLine($"Middle is : {questions.GetMiddle()}");

            //var node = linkList.GetNode(1);
            //questions.DeleteNode(ref node);
            //linkList.Print();

            //node = linkList.GetNode(4);
            //questions.DeleteNode(ref node);
            //linkList.Print();


            //Console.WriteLine("Reverse");
            //linkList.ReverseListMutable();
            //linkList.Print();
            //linkList.ReverseListMutable();
            //linkList.Print();


            //linkList.AddFirst(5000);
            //linkList.AddLast(6000);
            //linkList.AddBefore(6000, -9000);
            //linkList.AddBefore(6000, 56362);
            //linkList.AddAfter(1, 1000);

            //linkList.AddFirst(45000);
            //linkList.AddLast(65000);
            //linkList.AddBefore(-8888, -9000);
            //linkList.AddBefore(-8888, 56362);
            //linkList.AddAfter(-8888, 1000);

            //linkList.Print();
            //Console.WriteLine("First {0}", linkList.GetFirst());
            //Console.WriteLine("Last {0}", linkList.GetLast());
            //Console.WriteLine("Pop First {0}", linkList.PopFirst());
            //Console.WriteLine("Pop Last {0}", linkList.PopLast());
            //linkList.Print();

            //Console.WriteLine(linkList.IsExist(2));
            //Console.WriteLine(linkList.IsExist(6000));
            //Console.WriteLine(linkList.IsExist(-40));
            //Console.WriteLine("Is Empty {0}", linkList.IsEmpty());

            //linkList.Print();
            //linkList.Delete(6000);
            //linkList.Delete(1);
            //linkList.Delete(5000);
            //linkList.Delete(5);

            //linkList.DeleteFirstOccurance(32);
            //linkList.DeleteLastOccurance(2134);
            //linkList.Print();

            //linkList.DeleteAllOccurance(1);

            //linkList.DeleteFirstOccurance(50);
            //linkList.DeleteLastOccurance(50);
            //linkList.DeleteAllOccurance(50);

            //linkList.Print();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
