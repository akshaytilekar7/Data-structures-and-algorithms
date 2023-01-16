﻿namespace SLL
{
    public class SLLService
    {
        private readonly Node linklist;
        public SLLService()
        {
            linklist = new Node() { Data = -1 };
        }
        private Node GetNewNode(int data)
        {
            var node = new Node();
            node.Data = data;
            return node;
        }
        public void AddLast(int data)
        {
            var traverse = linklist.Next;
            Node prev = linklist;
            while (traverse != null)
            {
                prev = prev.Next; // IMP 
                traverse = traverse.Next;
            }

            GenericInsert(prev, GetNewNode(data), prev.Next);
        }
        public void AddFirst(int data)
        {
            GenericInsert(linklist, GetNewNode(data), linklist.Next);
        }
        public void AddAfter(int data, int newData)
        {
            var node = GetNode(data);
            if (node == null) return;
            GenericInsert(node, GetNewNode(newData), node.Next);
        }
        public void AddBefore(int data, int newData)
        {
            var traverse = linklist.Next;
            Node dataNode = null;
            while (traverse.Next != null)
            {
                if (traverse.Next.Data == data)
                    dataNode = traverse; // one step before
                traverse = traverse.Next;
            }
            if (dataNode == null) return;
            GenericInsert(dataNode, GetNewNode(newData), dataNode.Next);
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
            return linklist.Next == null;
        }
        public bool IsExist(int data)
        {
            return GetNode(data) != null;
        }
        public int GetLength()
        {
            int length = 0;
            var traverse = linklist.Next;
            while (traverse != null)
            {
                length++;
                traverse = traverse.Next;
            }
            return length;
        }
        public void Print()
        {
            Console.Write("\nSTART");
            var traverse = linklist.Next;
            while (traverse != null)
            {
                Console.Write(" [{0}] ", traverse.Data);
                traverse = traverse.Next;
            }
            Console.WriteLine("END");
        }
        public void Delete(int data)
        {
            var traverse = linklist.Next;
            Node prev = linklist;
            while (traverse != null)
            {
                if (traverse.Data == data)
                {
                    GenericDelete(prev);
                    return;
                }
                prev = prev.Next;
                traverse = traverse.Next;
            }
        }
        public int PopFirst()
        {
            if (IsEmpty()) return -1;
            var first = linklist.Next.Data;
            GenericDelete(linklist);
            return first;
        }
        public int PopLast()
        {
            if (IsEmpty()) return -1;
            var traverse = linklist.Next;
            Node prev = null;
            while (traverse.Next != null)
            {
                prev = traverse;
                traverse = traverse.Next;
            }
            int data = traverse.Data;
            GenericDelete(prev);
            return data;
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
            while (traverse.Next != null)
                traverse = traverse.Next;
            return traverse.Data;
        }
        public void DeleteFirstOccurance(int data)
        {
            Node prevNode = null;
            var traverse = linklist.Next;
            while (traverse.Next != null)
            {
                if (traverse.Next.Data == data)
                    prevNode = traverse;
                traverse = traverse.Next;
            }
            if (prevNode != null)
                GenericDelete(prevNode);
        }
        public void DeleteLastOccurance(int data)
        {
            Node prevNode = null;
            var traverse = linklist.Next;
            while (traverse.Next != null)
            {
                if (traverse.Next.Data == data)
                    prevNode = traverse;
                traverse = traverse.Next;
            }
            if (prevNode != null)
                GenericDelete(prevNode);
        }
        public void DeleteAllOccurance(int data)
        {
            var traverse = linklist.Next;
            Node prevNode = linklist;
            while (traverse != null)
            {
                var nextTravel = traverse.Next;
                if (traverse.Data == data)
                    GenericDelete(prevNode);
                else
                    prevNode = prevNode.Next; // EXTREMLTY IMP IN CAE 4 5 1 1 1 and we want to delete 1
                traverse = nextTravel;
            }
        }
        private void GenericDelete(Node nodeBeforeToBeDeletedNode)
        {
            nodeBeforeToBeDeletedNode.Next = nodeBeforeToBeDeletedNode.Next.Next;
        }
        private void GenericInsert(Node prev, Node newNode, Node next)
        {
            prev.Next = newNode;
            newNode.Next = next;
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