namespace PriorityQueue
{
    public class PriorityQueueService : BaseService
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
            var maxNode = GetMax();
            var data = maxNode.Data;
            GenericDelete(maxNode); // remove max
            return data;
        }

        private Node GetMax()
        {
            int max = 0;
            Node maxNode = null;
            var traverse = linklist.Next;
            while (traverse != linklist)
            {
                if (traverse.Data > max)
                {
                    max = traverse.Data;
                    maxNode = traverse;
                }
                traverse = traverse.Next;
            }
            return maxNode;
        }
        public int Peek()
        {
            if (IsEmpty()) return -1;
            return GetMax().Data; // get max
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
            Console.Write("Priority Queue Start ");
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
