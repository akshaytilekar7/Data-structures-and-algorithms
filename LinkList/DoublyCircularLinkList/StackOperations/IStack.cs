namespace DoublyCircularLinkList
{
    public interface IStack
    {
        int Peek();
        int Pop();
        void Push(int data);
        bool IsEmptyStack();
        void Print();
    }
}