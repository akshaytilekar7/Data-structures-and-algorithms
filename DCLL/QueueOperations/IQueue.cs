namespace DoublyCircularLinkList
{
    public interface IQueue
    {
        void QueueAdd(int data);
        int Dequeue();
        bool IsEmptyQueue();
        void Print();

        int Peek();
    }
}