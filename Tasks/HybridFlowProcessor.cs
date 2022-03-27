using System;
using Tasks.DoNotChange;

namespace Tasks
{

    
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public Node<T> head;

        public T Dequeue()
        {
            if (head == null)
                throw new InvalidOperationException();
            Node<T> last = head;
            Node<T> previous = head;
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
            Node<T> node = new Node<T>(item);
            
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

            Node<T> last = head;
            Node<T> previous = head;
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
            Node<T> node = new Node<T>(item);
            if(head == null)
            {
                head = node;
                return;
            }
            node.next = null;
            Node<T> last = head;
            while (last.next != null)
            {
                last = last.next;
            }
            node.previous = last;
            last.next = node;
            
        }
    }
}
