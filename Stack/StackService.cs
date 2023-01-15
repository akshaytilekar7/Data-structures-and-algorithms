namespace Stack
{
    public class StackService : BaseService
    {
        public bool IsEmpty()
        {
            return linklist.Next == linklist && linklist.Prev == linklist;
        }
        public void Push(int data)
        {
            GenericInsert(linklist, GetNewNode(data), linklist.Next);
        }
        public int Pop()
        {
            if (IsEmpty()) return -1;
            var data = linklist.Next.Data;
            GenericDelete(linklist.Next);
            return data;
        }
        public int Peek()
        {
            if (IsEmpty()) return -1;
            return linklist.Prev.Data;
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
            Console.Write("STACK Start ");
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
