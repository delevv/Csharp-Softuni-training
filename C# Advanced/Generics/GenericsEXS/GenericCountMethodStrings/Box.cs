using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.Values = new List<T>();
        }


        public List<T> Values { get; set; }

        public int CountOfGreaterValuesThan(T targetItem)
        {
            int counter = 0;

            foreach (var value in this.Values)
            {
                int isGreater = value.CompareTo(targetItem);

                if (isGreater == 1)
                {
                    counter++;
                }
            }
            return counter;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var value in Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }
            return sb.ToString().Trim();
        }

        void CheckIndex(int a)
        {
            bool isInRange = a >= 0 && a < Values.Count;

            if (!isInRange)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}

