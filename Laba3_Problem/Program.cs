using System;
using System.Collections.Generic;

namespace Laba3_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(3);
            stack.Push(5);
            stack.Push(8);
            stack.Push(13);

            while (!stack.IsEmpty)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}