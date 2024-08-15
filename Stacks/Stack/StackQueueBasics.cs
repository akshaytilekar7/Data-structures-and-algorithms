namespace Stack
{
    //  The idea is to keep newly inserted element always at front of queue,
    //  keeping order of previous elements same. 
    public class StackUsingQueue
    {
        Queue<int> q = new Queue<int>();

        public void Push(int x)
        {
            q.Enqueue(x);

            // make newly inserted element always at front of queue
            for (int i = 0; i < q.Count - 1; i++) // as new element should be 1st q.Count - 1 IMP
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

    public class QueueUsingStack1
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

    public class QueueUsingStack2
    {
        public Stack<int> s1 = new Stack<int>();
        public Stack<int> s2 = new Stack<int>();

        // oldest entered element is always at the top of stack 1,
        // so that deQueue operation just pops from stack1.

        // While stack1 is not empty, push everything from stack1 to stack2.
        // Push x to stack1(assuming size of stacks is unlimited).
        // Push everything back to stack1.
        // Push operation: O(N). 
        public void EnQueue(int x)
        {
            while (s1.Count() > 0)
                s2.Push(s1.Pop());

            s1.Push(x);

            while (s2.Count > 0)
                s1.Push(s2.Pop());
        }

        public int Dequeue()
        {
            if (s1.Count == 0)
                return -1;

            return s1.Pop();
        }
    }

}