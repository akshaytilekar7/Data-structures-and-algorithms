namespace SLL
{
    public class SLLService : ISLLService
    {
        private readonly Node linklist;

        public SLLService()
        {
            linklist = GetNewNode(-1);
        }

        public void AddFirst(int data)
        {
            GenericInsert(linklist, GetNewNode(data), linklist.Next);
        }

        public void AddLast(int data)
        {
            var traverse = linklist.Next;
            var prev = linklist;
            while (traverse != null)
            {
                prev = prev.Next;
                traverse = traverse.Next;
            }

            GenericInsert(prev, GetNewNode(data), prev.Next);
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
            var traverse = linklist.Next;
            var prev = linklist;
            Node beforeNode = null;
            while (traverse != null)
            {
                if (traverse.Data == data)
                    beforeNode = prev;
                prev = prev.Next;
                traverse = traverse.Next;
            }

            if (beforeNode != null)
                GenericInsert(beforeNode, GetNewNode(newData), beforeNode.Next);

        }

        public void Delete(int data)
        {
            if (!IsExist(data)) return;
            var traverse = linklist.Next;
            var prev = linklist;
            Node beforeNode = null;
            while (traverse != null)
            {
                if (data == traverse.Data)
                {
                    beforeNode = prev;
                    break;
                }
                prev = prev.Next;
                traverse = traverse.Next;
            }

            if (beforeNode != null)
                GenericDelete(beforeNode);
        }

        public void DeleteAllOccurance(int data)
        {
            if (!IsExist(data)) return;

            var traverse = linklist.Next;
            var prev = linklist;
            while (traverse != null)
            {
                var tempTravel = traverse.Next;
                if (data == traverse.Data)
                    GenericDelete(prev);
                else prev = prev.Next; // corner case v IMP
                traverse = tempTravel;
            }

        }

        public void DeleteFirstOccurance(int data)
        {
            if (!IsExist(data)) return;
            var traverse = linklist.Next;
            var prev = linklist;
            Node beforeNode = null;
            while (traverse != null)
            {
                if (traverse.Data == data)
                {
                    beforeNode = prev;
                    break;
                }
                prev = prev.Next;
                traverse = traverse.Next;
            }

            GenericDelete(beforeNode);
        }

        public void DeleteLastOccurance(int data)
        {
            if (!IsExist(data)) return;

            var traverse = linklist.Next;
            var prev = linklist;
            Node beforeNode = null;

            while (traverse != null)
            {
                if (data == traverse.Data)
                {
                    beforeNode = prev;
                }
                prev = prev.Next;
                traverse = traverse.Next;
            }

            GenericDelete(beforeNode);
        }

        public int GetFirst()
        {
            if (IsEmpty()) return -1;
            return linklist.Next.Data;
        }

        public int GetLast()
        {
            if (IsEmpty()) return -1;
            var traverse = linklist.Next;
            var prev = linklist;
            while (traverse != null)
            {
                prev = prev.Next;
                traverse = traverse.Next;
            }

            return prev.Data;
        }

        public int GetLength()
        {
            int count = 0;
            var traverse = linklist.Next;
            while (traverse != null)
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
            if (node == null)
                return 0;
            return GetLengthRecursiveHelper(node.Next) + 1;
        }

        public Node GetNode(int data)
        {
            var traverse = linklist.Next;
            while (traverse != null)
            {
                if (traverse.Data == data)
                    return traverse;
                traverse = traverse.Next;
            }
            return null;
        }

        public bool IsEmpty()
        {
            return linklist.Next == null; ;
        }

        public bool IsExist(int data)
        {
            return GetNode(data) != null;
        }

        public int PopFirst()
        {
            if (IsEmpty()) return -1;
            var data = linklist.Next.Data;
            GenericDelete(linklist);
            return data;
        }

        public int PopLast()
        {
            if (IsEmpty()) return -1;
            var traverse = linklist.Next;
            var prev = linklist;
            //while (traverse != null)
            while (traverse.Next != null) // travel to 2nd last node // IMP
            {
                prev = prev.Next;
                traverse = traverse.Next;
            }

            int data = traverse.Data; // IMP
            GenericDelete(prev);
            return data;
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public Node ReverseListImmutable()
        {
            throw new NotImplementedException();
        }

        public void ReverseListMutable()
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
        private void GenericInsert(Node prev, Node newNode, Node next)
        {
            prev.Next = newNode;
            newNode.Next = next;
        }

        //[Obsolete("cant use becz of PopLast method")]
        //private void GenericDelete(Node prev, Node deleteNode, Node next)
        //{
        //    prev.Next = prev.Next == null ? null : next;
        //    deleteNode.Next = null;
        //}

        private void GenericDelete(Node prev)
        {
            prev.Next = prev.Next.Next;
        }

        private Node GetNewNode(int data)
        {
            return new Node() { Data = data };
        }

    }
}
