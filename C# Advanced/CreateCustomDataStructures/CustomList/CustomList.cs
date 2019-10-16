using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;

        private T[] items;

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return this.items[index];
            }
            set
            {
                CheckIndex(index);
                this.items[index] = value;
            }
        }

        public CustomList()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        public void Add(T element)
        {
            Resize();
            this.items[this.Count] = element;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            CheckIndex(index);
            var element = this.items[index];

            Shift(index);
            this.Count--;
            Shrink();
            return element;
        }

        public void Reverse()
        {
            for (int i = 0; i < this.Count/2; i++)
            {
                Swap(i, this.Count - i - 1);
            }
        }

        public bool Contains(T element)
        {
            bool isFound = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(element))
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        public void InsertAt(int index, T item)
        {
            CheckIndex(index);
            Resize();
            this.Count++;
            ShiftToRight(index);

            this.items[index] = item;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndex(firstIndex);
            CheckIndex(secondIndex);

            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count - 1] = default;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count - 1; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void Resize()
        {
            if (this.items.Length > this.Count)
            {
                return;
            }
            var temp = new T[2 * this.items.Length];

            for (int i = 0; i < this.items.Length; i++)
            {
                temp[i] = this.items[i];
            }
            this.items = temp;
        }

        private void Shrink()
        {
            if (this.Count * 4 >= this.items.Length)
            {
                return;
            }
            var temp = new T[this.items.Length / 2];
            for (int i = 0; i <= this.Count; i++)
            {
                temp[i] = this.items[i];
            }
            this.items = temp;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count - 1] = default;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {

            var sb = new StringBuilder();

            for (int i = 0; i < this.Count-1; i++)
            {
                sb.Append($"{this.items[i]}, ");
            }

            return sb.ToString().TrimEnd(' ',',');
        }
    }
}
