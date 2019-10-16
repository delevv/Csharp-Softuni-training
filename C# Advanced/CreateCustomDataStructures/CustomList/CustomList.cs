using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                this.items[index] = value;
            }
        }



        public CustomList()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }



        public void Add(int element)
        {

        }
        public int RemoveAt(int index)
        {
            return 0;
        }
        public bool Contains(int element)
        {
            return true;
        }
        public void Swap(int firstIndex, int secondIndex)
        {

        }

        private void Resize()
        {

        }
        private void Shrink()
        {

        }
        private void Shift()
        {

        }
    }
}
