namespace DoublyCircularLinkList
{
    public class DCLLService : IDCLLService
    {
        protected Node linklist;

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
            GenericInsert(linklist.Prev, GetNewNode(data), linklist);
        }
        public void AddFirst(int data)
        {
            GenericInsert(linklist, GetNewNode(data), linklist.Next);
        }

        public void AddAfter(int data, int newData)
        {
            if (!IsExist(data)) return;
            var node = GetNode(data);
            GenericInsert(node, GetNewNode(newData), node.Next);
        }

        public void AddBefore(int data, int newData)
        {
            if (!IsExist(data)) return;
            var node = GetNode(data);
            GenericInsert(node.Prev, GetNewNode(newData), node);
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

        public Node ConcatImmutable(Node list1, Node List2)
        {
            throw new NotImplementedException();
        }

        public void ConcatMmutable(Node list1, Node List2)
        {
            throw new NotImplementedException();
        }

        public void Delete(int data)
        {
            if (!IsExist(data)) return;

            var node = GetNode(data);
            GenericDelete(node);
        }

        public void DeleteAllOccurance(int data)
        {
            var traverse = linklist.Next;
            while (traverse != linklist)
            {
                var tempTravel = traverse.Next;
                if (data == traverse.Data)
                    GenericDelete(traverse);
                traverse = tempTravel;
            }
        }

        public void DeleteFirstOccurance(int data)
        {
            if (!IsExist(data)) return;
            var node = GetNode(data);
            GenericDelete(node);
        }

        public void DeleteLastOccurance(int data)
        {
            if (!IsExist(data)) return;
            var traverse = linklist.Next;
            Node lastNode = null;
            while (traverse != linklist)
            {
                if (traverse.Data == data)
                    lastNode = traverse;
                traverse = traverse.Next;
            }

            GenericDelete(lastNode);
        }

        public int GetFirst()
        {
            if (IsEmpty()) return -1;
            return linklist.Next.Data;
        }

        public int GetLast()
        {
            if (IsEmpty()) return -1;
            return linklist.Prev.Data;
        }

        public int GetLength()
        {
            var count = 0;
            var traverse = linklist.Next;
            while (traverse != linklist)
            {
                count++;
                traverse = traverse.Next;
            }
            return count;
        }

        public int GetLengthRecursive()
        {
            return GetLengthRecursiveHelper(linklist.Next);
        }
        
        private int GetLengthRecursiveHelper(Node node)
        {
            if (node == linklist)
                return 0;

            return 1 + GetLengthRecursiveHelper(node.Next);
        }

        public int PopFirst()
        {
            if (IsEmpty()) return -1;
            var data = linklist.Next.Data;
            GenericDelete(linklist.Next);
            return data;
        }

        public int PopLast()
        {
            if (IsEmpty()) return -1;
            var data = linklist.Prev.Data;
            GenericDelete(linklist.Prev);
            return data;
        }

        public void Print()
        {
            Console.WriteLine();
            var traverse = linklist.Next;
            while (traverse != null)
            {
                Console.Write($"  {traverse.Data}  ");
                traverse = traverse.Next;
            }
            Console.WriteLine();
        }

        public void Print(Node node)
        {
            Console.WriteLine();
            var traverse = node;
            while (traverse != null)
            {
                Console.Write($"  {traverse.Data}  ");
                traverse = traverse.Next;
            }
            Console.WriteLine();
        }

        public Node ReverseListImmutable()
        {
            throw new NotImplementedException();
        }

        public void ReverseListMutable()
        {
            throw new NotImplementedException();
        }

        public void GenericInsert(Node prev, Node newNode, Node next)
        {
            prev.Next = newNode;
            next.Prev = newNode;

            newNode.Next = next;
            newNode.Prev = prev;
        }

        public void GenericDelete(Node deleteNode)
        {
            deleteNode.Prev.Next = deleteNode.Next;
            deleteNode.Next.Prev = deleteNode.Prev;
        }
    }
}
