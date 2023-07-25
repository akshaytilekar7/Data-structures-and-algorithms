namespace DoublyCircularLinkList.PriorityQueue
{
    public class PriorityQueue : Queue
    {
        public override int Dequeue()
        {
            if (IsEmpty()) return -1;
            var maxNode = GetMax();
            var data = maxNode.Data;
            GenericDelete(maxNode); // remove max
            return data;
        }
        public override int Peek()
        {
            if (IsEmpty()) return -1;
            return GetMax().Data; // get max
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
    }
}