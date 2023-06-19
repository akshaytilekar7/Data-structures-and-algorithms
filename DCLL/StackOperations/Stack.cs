namespace DoublyCircularLinkList
{
    // either add at last then all operation is at LAST or opposite
    public class Stack : DCLLService, IStack
    {
        public void Push(int data)
        {
            AddLast(data);
        }

        public int Pop()
        {
            return PopLast();
        }

        public int Peek()
        {
            return GetLast();
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