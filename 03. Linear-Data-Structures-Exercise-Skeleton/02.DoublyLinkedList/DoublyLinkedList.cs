namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node head;
        private Node tail;
        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }
        public class Node
        {
            public Node(T item)
            {
                this.Value = item;
            }
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);
            if (this.head == null)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (this.tail == null)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            if (this.head is null)
            {
                throw new InvalidOperationException();
            }
            return this.head.Value;
        }

        public T GetLast()
        {
            if (this.tail is null)
            {
                throw new InvalidOperationException();
            }
            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            if (this.head is null)
            {
                throw new InvalidOperationException();
            }
            var currentElement = this.head.Value;
           
            if(this.head.Next is not null)
            {
                var node = this.head.Next;
                node.Previous = null;
                this.head = node;
            }
            this.Count--;
           return currentElement;
        }

        public T RemoveLast()
        {
            if (this.tail is null)
            {
                throw new InvalidOperationException();
            }
            var currentElement = this.tail.Value;
            if (this.tail.Previous is not null)
            {
                var node = this.tail.Previous;
                node.Next = null;
                this.tail = node;
            }
            this.Count--;

            return currentElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
           Node node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}