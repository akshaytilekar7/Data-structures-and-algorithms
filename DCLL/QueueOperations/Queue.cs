namespace DoublyCircularLinkList
{
    public class Queue : DCLLService, IQueue
    {
        public int Dequeue()
        {
            return PopFirst();
        }

        public bool IsEmptyQueue()
        {
            return base.IsEmpty();
        }

        public void QueueAdd(int data)
        {
            AddFirst(data);
        }
    }
}