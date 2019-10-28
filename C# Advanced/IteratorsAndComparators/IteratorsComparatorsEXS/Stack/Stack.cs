using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private List<T> list;

        public Stack()
        {
            this.list = new List<T>();
        }

        public void Push(T element)
        {
            this.list.Add(element);   
        }

        public T Pop()
        {
            var currentElement = this.list[list.Count - 1];
            this.list.RemoveAt(this.list.Count-1);
            return currentElement;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
