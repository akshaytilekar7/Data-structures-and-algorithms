namespace SinglyLinkList
{
    public class SLLService : ISLLService
    {
        public readonly ListNode linklist;
        public SLLService()
        {
            linklist = GetNewNode(-1);
        }
        public void AddFirst(int data)
        {
            GenericInsert(linklist, GetNewNode(data), linklist.next);
        }
        public void AddLast(int data)
        {
            var traverse = linklist.next;
            var prev = linklist;
            while (traverse != null)
            {
                prev = prev.next;
                traverse = traverse.next;
            }

            GenericInsert(prev, GetNewNode(data), prev.next);
        }
        public void AddAfter(int data, int newData)
        {
            if (!IsExist(data)) return;
            var node = GetNode(data);
            GenericInsert(node, GetNewNode(newData), node.next);
        }
        public void AddBefore(int data, int newData)
        {
            if (!IsExist(data)) return;
            var traverse = linklist.next;
            var prev = linklist;
            ListNode beforeNode = null;
            while (traverse != null)
            {
                if (traverse.val == data)
                    beforeNode = prev;
                prev = prev.next;
                traverse = traverse.next;
            }

            if (beforeNode != null)
                GenericInsert(beforeNode, GetNewNode(newData), beforeNode.next);

        }
        public void Delete(int data)
        {
            if (!IsExist(data)) return;
            var traverse = linklist.next;
            var prev = linklist;
            ListNode beforeNode = null;
            while (traverse != null)
            {
                if (data == traverse.val)
                {
                    beforeNode = prev;
                    break;
                }
                prev = prev.next;
                traverse = traverse.next;
            }

            if (beforeNode != null)
                GenericDelete(beforeNode);
        }
        public void DeleteAllOccurance(int data)
        {
            if (!IsExist(data)) return;

            var traverse = linklist.next;
            var prev = linklist;
            while (traverse != null)
            {
                var tempTravel = traverse.next;
                if (data == traverse.val)
                    GenericDelete(prev);
                else prev = prev.next; // corner case v IMP
                traverse = tempTravel;
            }

        }
        public void DeleteFirstOccurance(int data)
        {
            if (!IsExist(data)) return;
            var traverse = linklist.next;
            var prev = linklist;
            ListNode beforeNode = null;
            while (traverse != null)
            {
                if (traverse.val == data)
                {
                    beforeNode = prev;
                    break;
                }
                prev = prev.next;
                traverse = traverse.next;
            }

            GenericDelete(beforeNode);
        }
        public void DeleteLastOccurance(int data)
        {
            if (!IsExist(data)) return;

            var traverse = linklist.next;
            var prev = linklist;
            ListNode beforeNode = null;

            while (traverse != null)
            {
                if (data == traverse.val)
                {
                    beforeNode = prev;
                }
                prev = prev.next;
                traverse = traverse.next;
            }

            GenericDelete(beforeNode);
        }
        public int GetFirst()
        {
            if (IsEmpty()) return -1;
            return linklist.next.val;
        }
        public int GetLast()
        {
            if (IsEmpty()) return -1;
            var traverse = linklist.next;
            var prev = linklist;
            while (traverse != null)
            {
                prev = prev.next;
                traverse = traverse.next;
            }

            return prev.val;
        }
        public int GetLength()
        {
            int count = 0;
            var traverse = linklist.next;
            while (traverse != null)
            {
                count++;
                traverse = traverse.next;
            }
            return count;
        }
        public int GetLengthRecursive()
        {
            return GetLengthRecursiveHelper(linklist.next);
        }
        private int GetLengthRecursiveHelper(ListNode node)
        {
            if (node == null)
                return 0;
            return GetLengthRecursiveHelper(node.next) + 1;
        }
        public ListNode GetNode(int data)
        {
            var traverse = linklist.next;
            while (traverse != null)
            {
                if (traverse.val == data)
                    return traverse;
                traverse = traverse.next;
            }
            return null;
        }
        public bool IsEmpty()
        {
            return linklist.next == null; ;
        }
        public bool IsExist(int data)
        {
            return GetNode(data) != null;
        }
        public int PopFirst()
        {
            if (IsEmpty()) return -1;
            var data = linklist.next.val;
            GenericDelete(linklist);
            return data;
        }
        public int PopLast()
        {
            if (IsEmpty()) return -1;
            var traverse = linklist.next;
            var prev = linklist;
            //while (traverse != null)
            while (traverse.next != null) // travel to 2nd last node // IMP
            {
                prev = prev.next;
                traverse = traverse.next;
            }

            int data = traverse.val; // IMP
            GenericDelete(prev);
            return data;
        }
        public void Print(string message = "")
        {
            Console.WriteLine(message);
            var traverse = linklist.next;
            while (traverse != null)
            {
                Console.Write($"  {traverse.val}  ");
                traverse = traverse.next;
            }
            Console.WriteLine();
        }

        public void Print(ListNode node, string message = "")
        {
            Console.Write(message +  ": ");
            var traverse = node;
            while (traverse != null)
            {
                Console.Write($"  {traverse.val}  ");
                traverse = traverse.next;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// TC O(n)
        /// SC O(1)
        /// </summary>
        /// <returns></returns>
        public ListNode ReverseListImmutable()
        {
            return ReverseListImmutable(linklist.next);
        }
        public void ReverseListMutable()
        {
            if (IsEmpty()) return;

            var cur = linklist.next;
            ListNode prev = null;
            ListNode next = null;

            while (cur != null)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }

            linklist.next = prev; // EASY BRO
        }

        public ListNode ReverseListImmutable(ListNode node)
        {
            if (IsEmpty()) return null;

            var cur = node;
            ListNode prev = null;
            ListNode next = null;

            while (cur != null)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }
            return prev;
        }
        public ListNode ConcatImmutable(ListNode list1, ListNode List2)
        {
            throw new NotImplementedException();
        }
        public void ConcatMmutable(ListNode list1, ListNode List2)
        {
            throw new NotImplementedException();
        }
        private void GenericInsert(ListNode prev, ListNode newNode, ListNode next)
        {
            prev.next = newNode;
            newNode.next = next;
        }

        //[Obsolete("cant use becz of PopLast method")]
        //private void GenericDelete(Node prev, Node deleteNode, Node next)
        //{
        //    prev.Next = prev.Next == null ? null : next;
        //    deleteNode.Next = null;
        //}
        public void GenericDelete(ListNode prev)
        {
            prev.next = prev.next.next;
        }
        public ListNode GetNewNode(int data)
        {
            return new ListNode() { val = data };
        }

    }
}
