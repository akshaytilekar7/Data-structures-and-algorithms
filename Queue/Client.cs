namespace Queue
{
    public class Stack
    {
        public static void Main()
        {
            QueueService queue = new QueueService();

            Console.WriteLine("Is Empty : {0}", queue.IsEmpty());
            Console.WriteLine("Peek : {0}", queue.Peek());
            Console.WriteLine("GetLength : {0}", queue.GetLength());
            
            var arr = new int[] { 10, 20, 30, 40, 50 };

            foreach (var item in arr)
                queue.Enqueue(item);

            queue.Print();

            Console.WriteLine("Is Empty : {0}", queue.IsEmpty());
            Console.WriteLine("Peek : {0}", queue.Peek());
            Console.WriteLine("GetLength : {0}", queue.GetLength());

            Console.WriteLine("Pop : {0}", queue.Dequeue());
            Console.WriteLine("Pop : {0}", queue.Dequeue());

            queue.Print();
            Console.ReadLine();
        }
    }
}
