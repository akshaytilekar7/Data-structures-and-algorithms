namespace Stack
{
    public class StackUsingQueue
    {
        Queue<int> q = new Queue<int>();

        public void Push(int x)
        {
            int s = q.Count;

            q.Enqueue(x);

            for (int i = 0; i < s; i++)
                q.Enqueue(q.Dequeue());
        }

        public int Pop()
        {
            if (q.Count == 0)
                return -1;
            return q.Dequeue();
        }

        public int Top()
        {
            if (q.Count == 0)
                return -1;
            return q.Peek();
        }

        public int Size() { return q.Count; }
    }

    public class QueueUsingStack
    {
        Stack<int> stack = new Stack<int>();

        public void Enqueue(int x)
        {
            List<int> list = new List<int>();
            while (stack.Count > 0)
                list.Add(stack.Pop());
            list.Add(x);

            for (int i = list.Count - 1; i >= 0; i--)
                stack.Push(list[i]);
        }

        public int Dequeue()
        {
            if (stack.Count == 0)
                return -1;
            else
                return stack.Pop();
        }

        public int Top()
        {
            if (stack.Count == 0)
                return -1;
            return stack.Peek();
        }

        public int Size() { return stack.Count; }
    }

}