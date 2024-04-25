namespace Stack
{
    public class Stack
    {
        public static void Main()
        {

            StackQueueQuestions questions = new StackQueueQuestions();

            Stack<int> x = new Stack<int>();
            x.Push(100);
            x.Push(21);
            x.Push(34);
            x.Push(-4);
            x.Push(532);

            questions.SortStack(x);

            while (x.Count > 0)
                Console.Write(x.Pop() + " ");

            //Console.WriteLine("Valid Parent :" + questions.ValidParenthesis("({[]})"));
            //Console.WriteLine("Valid Parent :" + questions.ValidParenthesis("()"));
            //Console.WriteLine("Valid Parent :" + questions.ValidParenthesis(""));
            //Console.WriteLine("Valid Parent :" + questions.ValidParenthesis("("));
            //Console.WriteLine("Valid Parent :" + questions.ValidParenthesis("{}]"));
            //Console.WriteLine("Valid Parent :" + questions.ValidParenthesis("{{}"));
            //Console.WriteLine("Valid Parent :" + questions.ValidParenthesis("{}{}{}{}"));


            //StackUsingQueue stackUsingQueue = new StackUsingQueue();
            //stackUsingQueue.Push(1);
            //stackUsingQueue.Push(2);
            //stackUsingQueue.Push(3);
            //stackUsingQueue.Push(4);
            //Console.WriteLine("Stack Peek : {0}", stackUsingQueue.Top());
            //Console.WriteLine("Stack Pop  : {0}", stackUsingQueue.Pop());
            //Console.WriteLine("Stack Pop  : {0}", stackUsingQueue.Pop());
            //Console.WriteLine("Stack Peek : {0}", stackUsingQueue.Top());
            //Console.WriteLine("Stack Pop  : {0}", stackUsingQueue.Pop());
            //Console.WriteLine("Stack Pop  : {0}", stackUsingQueue.Pop());

            //Console.WriteLine();

            //QueueUsingStack queueUsingStack = new QueueUsingStack();
            //queueUsingStack.Enqueue(1);
            //queueUsingStack.Enqueue(2);
            //queueUsingStack.Enqueue(3);
            //queueUsingStack.Enqueue(4);
            //Console.WriteLine("Queue Peek : {0}", queueUsingStack.Top());
            //Console.WriteLine("Queue Pop  : {0}", queueUsingStack.Dequeue());
            //Console.WriteLine("Queue Pop  : {0}", queueUsingStack.Dequeue());
            //Console.WriteLine("Queue Peek : {0}", queueUsingStack.Top());
            //Console.WriteLine("Queue Pop  : {0}", queueUsingStack.Dequeue());
            //Console.WriteLine("Queue Pop  : {0}", queueUsingStack.Dequeue());

            //StackService stack = new StackService();

            //Console.WriteLine("Is Empty : {0}", stack.IsEmpty());
            //Console.WriteLine("Peek : {0}", stack.Peek());
            //Console.WriteLine("GetLength : {0}", stack.GetLength());

            //var arr = new int[] { 10, 20, 30, 40, 50 };

            //foreach (var item in arr)
            //    stack.Push(item);

            //stack.Print();

            //Console.WriteLine("Is Empty : {0}", stack.IsEmpty());
            //Console.WriteLine("Peek : {0}", stack.Peek());
            //Console.WriteLine("GetLength : {0}", stack.GetLength());

            //Console.WriteLine("Pop : {0}", stack.Pop());
            //Console.WriteLine("Pop : {0}", stack.Pop());

            //stack.Print();

            Console.ReadLine();
        }
    }
}
