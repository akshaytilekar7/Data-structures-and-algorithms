using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.DP
{
    public class Factorial
    {
        int n;
        int[] array;
        public int delta;
        public int rs;

        public Factorial(int _n)
        {
            n = _n;
            array = new int[_n + 1];
            delta = 0;
            rs = 0;
        }

        int DoCompute(int N)
        {
            if (N == 0)
                return 0;
            else if (N == 1)
                return 1;
            else if (array[N] > 0)
                return array[N];
            else
            {
                array[N] = DoCompute(N - 1) + DoCompute(N - 2);
                return array[N];
            }
        }

        public void Compute()
        {
            rs = DoCompute(n);
        }

        void Test()
        {
            Factorial fact = new Factorial(100);
            fact.Compute();
            Console.WriteLine("Delta = {0}, Result = {1}\n", fact.delta, fact.rs);
        }
    };
}
