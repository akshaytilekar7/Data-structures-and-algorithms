namespace PriorityQueue
{
    public class Stack
    {
        public static void Main()
        {
            PriorityQueueService pq = new PriorityQueueService();

            Console.WriteLine("Is Empty : {0}", pq.IsEmpty());
            Console.WriteLine("Peek : {0}", pq.Peek());
            Console.WriteLine("GetLength : {0}", pq.GetLength());

            var arr = new int[] { 10, 54, 546, -89, 4505, 20, 30, 40, 50 };

            foreach (var item in arr)
                pq.Enqueue(item);

            pq.Print();

            Console.WriteLine("Is Empty : {0}", pq.IsEmpty());
            Console.WriteLine("Peek : {0}", pq.Peek());
            Console.WriteLine("GetLength : {0}", pq.GetLength());

            Console.WriteLine("Pop : {0}", pq.Dequeue());
            Console.WriteLine("Pop : {0}", pq.Dequeue());

            pq.Print();
            Console.ReadLine();
        }
    }
}
