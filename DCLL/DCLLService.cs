namespace DCLL
{
    public class DCLLService
    {
        private readonly Node linklist;
        public DCLLService()
        {
            linklist = new Node();
            linklist.Next = linklist;
            linklist.Prev = linklist;
        }
        private Node GetNewNode(int data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            newNode.Next = newNode;
            newNode.Prev = newNode;
            return newNode;
        }
        public void AddLast(int data)
        {
            var newNode = GetNewNode(data);
            GenericInsert(linklist.Prev, newNode, linklist);
        }
        public void AddFirst(int data)
        {
            var newNode = GetNewNode(data);
            GenericInsert(linklist, newNode, linklist.Next);
        }
        public void AddAfter(int data, int newData)
        {
            var node = GetNode(data);
            if (node == null) return;
            var newNode = GetNewNode(newData);
            GenericInsert(node, newNode, node.Next);
        }
        public void AddBefore(int data, int newData)
        {
            var node = GetNode(data);
            if (node == null) return;
            var newNode = GetNewNode(newData);
            GenericInsert(node.Prev, newNode, node);
        }
        public Node GetNode(int data)
        {
            var traverse = linklist.Next;
            while (traverse != linklist)
            {
                if (traverse.Data == data)
                    return traverse;
                traverse = traverse.Next;
            }
            return null;
        }
        public bool IsEmpty()
        {
            return linklist.Prev == linklist && linklist.Next == linklist;
        }
        public bool IsExist(int data)
        {
            return GetNode(data) != null;
        }
        public int GetLength()
        {
            int length = 0;
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
            Console.Write("  START  ");
            var traverse = linklist.Next;
            while (traverse != linklist)
            {
                Console.Write(" [{0}] ", traverse.Data);
                traverse = traverse.Next;
            }
            Console.Write("  END  \n");
        }
        public void Delete(int data)
        {
            var node = GetNode(data);
            if (node == null) return;
            GenericDelete(node);
        }
        public int PopFirst()
        {
            int data = linklist.Next.Data;
            GenericDelete(linklist.Next);
            return data;
        }
        public int PopLast()
        {
            int data = linklist.Prev.Data;
            GenericDelete(linklist.Prev);
            return data;
        }
        public int GetFirst()
        {
            return linklist.Next.Data;
        }
        public int GetLast()
        {
            return linklist.Prev.Data;
        }
        public void DeleteFirstOccurance(int data)
        {
            var node = GetNode(data);
            if (node == null) return;
            GenericDelete(node);
        }
        public void DeleteLastOccurance(int data)
        {
            var traverse = linklist.Next;
            Node node = null;
            while (traverse != linklist)
            {
                if (traverse.Data == data)
                    node = traverse;
                traverse = traverse.Next;
            }
            if (node == null) return;
            GenericDelete(node);
        }
        public void DeleteAllOccurance(int data)
        {
            var traverse = linklist.Next;
            while (traverse != linklist)
            {
                var tempTraverse = traverse.Next;
                if (traverse.Data == data)
                    GenericDelete(traverse);
                traverse = tempTraverse;
            }
        }
        private void GenericDelete(Node nodeToBeDelete)
        {
            nodeToBeDelete.Prev.Next = nodeToBeDelete.Next;
            nodeToBeDelete.Next.Prev = nodeToBeDelete.Prev;
        }
        private void GenericInsert(Node prev, Node newNode, Node next)
        {
            newNode.Next = next;
            newNode.Prev = prev;

            prev.Next = newNode;
            next.Prev = newNode;
        }
        public int GetLengthRecursive()
        {
            throw new NotImplementedException();
        }
        public Node ConcatImmutable(Node list1, Node List2)
        {
            throw new NotImplementedException();
        }
        public void ConcatMmutable(Node list1, Node List2)
        {
            throw new NotImplementedException();
        }
        public void ReverseListMutable()
        {
            throw new NotImplementedException();
        }
        public Node ReverseListImmutable()
        {
            throw new NotImplementedException();
        }

    }
}
