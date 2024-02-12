using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueueApplication
{
    public class GenQueue<T>
    {
        private T[] queue;
        private int front;
        private int rear;
        private int size;

        public GenQueue(int size)
        {
            this.size = size;
            queue = new T[size];
            front = rear = -1;
        }

        public void Enqueue(T item = default(T))
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full. Cannot Add element.");
                return;
            }

            if (IsEmpty())
            {
                front = rear = 0;
            }
            else
            {
                rear = (rear + 1) ;
            }

            queue[rear] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty. Cannot remove element ");
                return default(T);
            }

            if (front == rear)
            {
                T item = queue[front];
                front = rear = -1;
                return item;
                
            }
            else
            {
                T item = queue[front];
                front = (front + 1);
                return item;
               
            }
           
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty. Cannot peek.");
                return default(T);
            }

            return queue[front];
        }

        public bool IsEmpty()
        {
            return front == -1 && rear == -1;
        }

        public bool IsFull()
        {
            return (rear + 1) % size == front;
        }
    }
}
