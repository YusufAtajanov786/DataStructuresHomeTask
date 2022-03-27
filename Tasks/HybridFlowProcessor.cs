using System;
using Tasks.DoNotChange;

namespace Tasks
{

    public class DoubleNode<T>
    {
        public T data { get; }
        public DoubleNode<T> next { get; set; }
        public DoubleNode<T> previous { get; set; }

        public DoubleNode(T value)
        {
            data = value;
            next = null;
            previous = null;
        }
    }
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public DoubleNode<T> head;

        public T Dequeue()
        {
            if (head == null)
                throw new InvalidOperationException();
            DoubleNode<T> last = head;
            DoubleNode<T> previous = head;
            T data;
            while (last.next != null)
            {
                previous = last;
                last = last.next;
            }
            previous.next = null;
            data = last.data;
            return data;
        }

        public void Enqueue(T item)
        {
            DoubleNode<T> node = new DoubleNode<T>(item);
            
            if(head == null)
            {
                head = node;
                return;
            }

            head.previous = node;
            node.next = head;                
            head = node;
        }

        public T Pop()
        {
            if(head == null)
            {
                throw new InvalidOperationException();
            }

            DoubleNode<T> last = head;
            DoubleNode<T> previous = head;
            T data ;
            while (last.next != null)
            {
                previous = last;
                last = last.next;
            }
            data = last.data;
            previous.next = null;
            return data;
        }

        public void Push(T item)
        {
            DoubleNode<T> node = new DoubleNode<T>(item);
            if(head == null)
            {
                head = node;
                return;
            }
            node.next = null;
            DoubleNode<T> last = head;
            while (last.next != null)
            {
                last = last.next;
            }
            node.previous = last;
            last.next = node;
            
        }
    }
}
