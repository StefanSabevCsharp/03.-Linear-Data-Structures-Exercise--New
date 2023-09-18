namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        public CircularQueue()
        {
            this.items = new T[DefaultCapacity];
        }
        public int Count { get; private set; }
        public T Dequeue()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            var currentElement = this.items[0];
            for(int i = 0; i < this.Count - 1; i++)
            {
                if(i == this.Count - 1)
                {
                    this.items[i] = default;
                }
                else
                {
                    this.items[i] = this.items[i + 1];
                }
            }
            this.Count--;
           return currentElement;
        }

        public void Enqueue(T item)
        {
            if(this.Count >= this.items.Length)
            {
                this.Grow();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        private void Grow()
        {
            var newArray = new T[this.items.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.items[i];
            }
            this.items = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        public T Peek()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
           return items[0];
        }

        public T[] ToArray()
        {
            if(this.Count == 0)
            {
                return new T[0];
            }
            var array = new T[this.Count];
            for (int i = 0;i < this.Count; i++)
            {
                array[i] = this.items[i];
            }
            return array;
        }

        IEnumerator IEnumerable.GetEnumerator()
       => GetEnumerator();
    }

}
