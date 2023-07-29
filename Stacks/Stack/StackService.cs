namespace Stack
{
    // LIFO 
    public class StackService : BaseService
    {
        public bool IsEmpty()
        {
            return linklist.Next == linklist && linklist.Prev == linklist;
        }
        public void Push(int data)
        {
            GenericInsert(linklist.Prev, GetNewNode(data), linklist); // add last
        }
        public int Pop()
        {
            if (IsEmpty()) return -1;
            var data = linklist.Prev.Data;
            GenericDelete(linklist.Prev); // remove last
            return data;
        }
        public int Peek()
        {
            if (IsEmpty()) return -1;
            return linklist.Prev.Data;  // get last
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
            var traverse = linklist.Prev;
            while (traverse != linklist)
            {
                Console.Write(" [{0}] ", traverse.Data);
                traverse = traverse.Prev; // traverse reverse
            }
            Console.WriteLine("End");
        }
    }
}
