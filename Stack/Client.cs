using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack
    {
        public static void Main()
        {
            StackService stack = new StackService();

            Console.WriteLine("Is Empty : {0}", stack.IsEmpty());
            Console.WriteLine("Peek : {0}", stack.Peek());
            Console.WriteLine("GetLength : {0}", stack.GetLength());

            var arr = new int[] { 50, 60, 10, 20, 5 };

            foreach (var item in arr)
                stack.Push(item);

            stack.Print();

            Console.WriteLine("Is Empty : {0}", stack.IsEmpty());
            Console.WriteLine("Peek : {0}", stack.Peek());
            Console.WriteLine("GetLength : {0}", stack.GetLength());

            Console.WriteLine("Pop : {0}", stack.Pop());
            Console.WriteLine("Pop : {0}", stack.Pop());

            stack.Print();
        }
    }
}
