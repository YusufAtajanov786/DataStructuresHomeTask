using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{

    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> current;

        public LinkedListEnumerator(Node<T> current)
        {
            this.current = current;
        }

        public T Current => current.data;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (current == null) return false;
            current = current.next;
            return (current != null);
        }

        public void Dispose()
        {

        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    public class Node<T>
    {
        public T data { get; }
        public Node<T> next { get; set; }

        public Node(T value)
        {
            data = value;
            next = null;

        }
    }

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerable<T>
    {
        public Node<T> head;
        public Node<T> temp;
        public Node<T> EnumerateNode;
        public DoublyLinkedList()
        {
            temp = head;
            EnumerateNode = head;
        }
       

        public int Length => Count();

      

        public int Count()
        {
            int cnt = 0;
            temp = head;
            while (temp != null)
            {
                temp = temp.next;
                cnt++;
            }
            return cnt;
        }

        public void Add(T e)
        {
            Node<T> node = new Node<T>(e);
            if(head == null)
            {
                head = node;
                return;
            }
            node.next = null;
            Node<T> last = head;
            while (last.next != null)           
                last = last.next;
            last.next = node;
           
        }

        public void AddAt(int index, T e)
        {
            Node<T> node = new Node<T>(e);
            temp = head.next;
            Node<T> previousNode = head;

            if(index == 0)
            {
                node.next = head;
                head = node;
                return;
            }
            int cnt = 1;
            while(cnt != index )
            {
                previousNode = temp;
                temp = temp.next;
                cnt++;
            }

            if(previousNode is null)
            {
                throw new IndexOutOfRangeException();
            }
            node.next = temp;
            previousNode.next = node;
           
        }

        public T ElementAt(int index)
        {
            temp = head;

            if (index == 0 && temp != null)
            {
                return head.data;
            }
            int cnt = 0;
            while (cnt < index)
            {
                temp = temp.next;
                cnt++;
            }
            if(temp is null || index<0)
            {
                throw new IndexOutOfRangeException();
            }
            return temp.data;
        }

     
        public void Remove(T item)
        {
            temp = head;
            Node<T> previousNode = temp;
            if (head.data.Equals(item))
            {
                head = head.next;
                return;
            }
            while ( temp != null && !temp.data.Equals(item))
            {
                previousNode = temp;
                temp = temp.next;
            }
            if(temp != null && temp.data.Equals(item))
            {
                previousNode.next = temp.next;
            }
            temp = head;
        }

        public T RemoveAt(int index)
        {
            

            if (index < 0 || Length <= index)
            {
                throw new IndexOutOfRangeException();
            }
            temp = head;
            Node<T> previousNode = head;
            T data;
            if (index == 0)
            {
                data = temp.data;
                temp = temp.next;
                return data;
            }
             
            for(int i=0; temp != null && i <index; i++)
            {
                previousNode = temp;
                temp = temp.next;
            }

            Node<T> next = temp.next;
            data = temp.data;
            previousNode.next = next;
            temp = head;
            return data;

        }
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(temp);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
      
    }
}
