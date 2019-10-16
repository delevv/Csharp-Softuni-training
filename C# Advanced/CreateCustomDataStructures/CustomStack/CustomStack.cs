using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T>
    {
        private const int InitialCapacity = 4;

        T[] items;

        public int Count { get; private set; }

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        public void Push(T element)
        {
            Resize();
            this.items[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            ThrowWhenEmpty();
            var lastElement = this.items[this.Count - 1];
            this.Count--;

            return lastElement;
        }

        public T Peek()
        {
            ThrowWhenEmpty();
            return this.items[this.Count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void ThrowWhenEmpty()
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is empty.");
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
    }
}
