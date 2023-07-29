namespace PriorityQueue
{
    public abstract class BaseService
    {
        protected Node linklist;
        protected BaseService()
        {
            linklist = new Node() { Data = -1 };
            linklist.Prev = linklist;
            linklist.Next = linklist;
        }

        protected Node GetNewNode(int data)
        {
            return new Node() { Data = data };
        }
        protected void GenericInsert(Node prev, Node newNode, Node next)
        {
            newNode.Prev = prev;
            newNode.Next = next;

            prev.Next = newNode;
            next.Prev = newNode;
        }

        protected void GenericDelete(Node nodeToBeDeleted)
        {
            nodeToBeDeleted.Prev.Next = nodeToBeDeleted.Next;
            nodeToBeDeleted.Next.Prev = nodeToBeDeleted.Prev;
        }

    }
}
