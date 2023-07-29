using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class StackQueueQuestions
    {
        public bool ValidParenthesis(string str)
        {
            Stack<char> stack = new Stack<char>();
            var len = str.Length;
            if (len % 2 != 0) return false;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '[' || str[i] == '{')
                    stack.Push(str[i]);
                else
                {
                    if (stack.Count == 0) return false;
                    switch (str[i])
                    {
                        case ')': if (stack.Pop() != '(') return false; break;
                        case ']': if (stack.Pop() != '[') return false; break;
                        case '}': if (stack.Pop() != '{') return false; break;
                        default:
                            return false;
                    }
                }
            }
            return stack.Count == 0 ? true : false;

        }

        public List<int> NextGreterElement(int[] arr)
        {
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                var item = arr[i];

                while (stack.Count > 0 && stack.Peek() <= item)
                    stack.Pop();

                result.Add(stack.Count == 0 ? -1 : stack.Peek());
                stack.Push(item);
            }
            return result;
        }
        public List<int> NextSmallerElement(int[] arr)
        {
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                var item = arr[i];

                while (stack.Count > 0 && stack.Peek() >= item)
                    stack.Pop();

                result.Add(stack.Count == 0 ? -1 : stack.Peek());
                stack.Push(item);
            }
            return result;
        }

    }
}
