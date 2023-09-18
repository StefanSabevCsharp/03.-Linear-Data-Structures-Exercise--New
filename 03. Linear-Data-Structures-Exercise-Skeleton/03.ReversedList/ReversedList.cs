namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            
            get
            {
                if (CheckValidIndex(index))
                {
                    return this.items[this.Count - 1 - index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (CheckValidIndex(index))
                {
                    this.items[this.Count - 1 - index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count >= this.items.Length)
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

        public bool Contains(T item)
        {
            for (int i = 0;i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {

            int index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;

        }

        public void Insert(int index, T item)
        {
            if (this.Count >= this.items.Length)
            {
                this.Grow();
            }
           if (CheckValidIndex(index))
            {
                for (int i = this.Count; i > index; i--)
                {
                    this.items[i] = this.items[i - 1];
                }
                this.items[index] = item;
                this.Count++;
            }

        }

        private bool CheckValidIndex(int index)
        {
            if (index < 0 || index >= this.Count) // da proverq moje bi nqma ravno
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            return true;
        }

        public bool Remove(T item)
        {
           
            int index = this.IndexOf(item);
            if (index != -1)
            {
                this.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (CheckValidIndex(index))
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    this.items[i] = this.items[i + 1];
                }
                this.Count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
          

            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}