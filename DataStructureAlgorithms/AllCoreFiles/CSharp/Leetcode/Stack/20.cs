using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://leetcode.com/problems/valid-parentheses/submissions/
// 20. Valid Parentheses

/*
Runtime: 80 ms, faster than 86.58% of C# online submissions for Valid Parentheses.
Memory Usage: 36.4 MB, less than 86.25% of C# online submissions for Valid Parentheses. 
*/

namespace CSharp.Leetcode.Stack
{
    public class Stack20
    {
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char item in s)
            {
                if (item == '(' || item == '{' || item == '[')
                    stack.Push(item);
                else
                {
                    if(stack.Count() == 0 )
                        return false;
                    char top = stack.Pop();
                    switch (item)
                    {
                        case ')':
                            if (top != '(') return false;
                            break;
                        case '}':
                            if (top != '{') return false;
                            break;
                        case ']':
                            if (top != '[') return false;
                            break;
                        default:
                            return false;
                    }
                }
            }
           
            return stack.Count() == 0 ? true : false ;
        }

        public bool IsValidLeetcode(string s)
        {
            if (s == null || s == string.Empty)
                return true;

            Dictionary<char, char> dict = new Dictionary<char, char>();
            dict.Add(')', '(');
            dict.Add('}', '{');
            dict.Add(']', '[');
            
            Stack<char> stack = new Stack<char>();

            foreach (var item in s)
                if (item == ')' || item == '}' || item == ']')
                {
                    if (stack.Count > 0 && stack.Peek() == dict[item])
                        stack.Pop();
                    else
                        return false;
                }
                else
                    stack.Push(item);

            return stack.Count == 0;
        }
    }

    public class Test20
    {
        static void Main123(string[] args)
        {
            Stack20 stack = new Stack20();
            System.Console.WriteLine(stack.IsValid("]"));
        }
    }
}