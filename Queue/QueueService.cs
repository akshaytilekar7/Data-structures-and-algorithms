namespace Queue
{
    public class QueueService : BaseService
    {
        // FIFO
        public bool IsEmpty()
        {
            return linklist.Next == linklist && linklist.Prev == linklist;
        }
        public void Enqueue(int data)
        {
            GenericInsert(linklist.Prev, GetNewNode(data), linklist); // add last
        }
        public int Dequeue()
        {
            if (IsEmpty()) return -1;
            var data = linklist.Next.Data;
            GenericDelete(linklist.Next); // remove first
            return data;
        }
        public int Peek()
        {
            if (IsEmpty()) return -1;
            return linklist.Next.Data; // get first
        }
        public int GetLength()
        {
            var length = 0;
            var traverse = linklist.Next;
            while (traverse != linklist)
            {
                length++;
                traverse = traverse.Next;
            }
            return length;
        }
        public void Print()
        {
            Console.Write("QUEUE Start ");
            var traverse = linklist.Next;
            while (traverse != linklist)
            {
                Console.Write(" [{0}] ", traverse.Data);
                traverse = traverse.Next;
            }
            Console.WriteLine("End");
        }
    }
}
