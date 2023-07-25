namespace DoublyCircularLinkList
{
    // add last and get first
    public class Queue : DCLLService, IQueue
    {
        public void QueueAdd(int data)
        {
            AddLast(data);
        }
        public virtual int Dequeue()
        {
            return PopFirst();
        }
        public bool IsEmptyQueue()
        {
            return base.IsEmpty();
        }
        public virtual int Peek()
        {
            return GetFirst();
        }
    }
}