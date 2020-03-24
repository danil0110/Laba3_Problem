using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba3_Problem
{
    public class MyStack<T>
    {
        private List<T> stack = new List<T>();

        public int Count => stack.Count;
        public bool IsEmpty => stack.Count == 0;

        public void Push(T item)
        {
            stack.Add(item);
        }

        public T Peek()
        {
            if (!IsEmpty)
                return stack.Last();
            else
                throw new NullReferenceException("Stack is empty.");
        }

        public T Pop()
        {
            if (!IsEmpty)
            {
                var item = stack.Last();
                stack.RemoveAt(stack.Count - 1);
                return item;
            }
            else
                throw new NullReferenceException("Stack is empty.");
        }

    }
}