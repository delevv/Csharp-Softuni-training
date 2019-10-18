using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
       private List<T> List { get; set; }

        public int Count => this.List.Count;

        public Box()
        {
            this.List = new List<T>();
        }

        public void Add(T element)
        {
            this.List.Add(element);
        }
        public T Remove()
        {
            var elementToRemove = List[List.Count - 1];
            List.RemoveAt(List.Count - 1);

            return elementToRemove;
        }
    }
}
