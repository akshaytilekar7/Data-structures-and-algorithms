namespace DoublyCircularLinkList
{
    public class Stack : DCLLService, IStack
    {
        public void Push(int data)
        {
            AddLast(data);
        }

        public int Pop()
        {
            return PopFirst();
        }

        public int Peek()
        {
            return GetFirst();
        }
        public bool IsEmptyStack()
        {
            return base.IsEmpty();
        }

        public void PrintStack()
        {
            base.Print();
        }

    }
}