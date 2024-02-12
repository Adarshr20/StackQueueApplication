using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueueApplication
{
    public class GenStack<T>
    {
        private T[] stack;
        private int top;

        public GenStack(int size)
        {
            stack = new T[size];
            top = -1;
        }
        public void Push(T item = default(T))
        {

            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack overflow! Cannot push element.");
                return;
            }

            stack[++top] = item;
        }
        public T Peek() {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty.");
                return default(T);
            }

            return stack[top];


        }
        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack underflow Cannot pop element.");
                return default(T);
            }
            T x= stack[top];
            top--;
            return x;
            
        }
        public bool IsEmpty() { return top == -1; }

    }
}
