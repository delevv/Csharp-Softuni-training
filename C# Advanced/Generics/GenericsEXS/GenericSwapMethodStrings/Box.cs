using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        public Box()
        {
            this.Values = new List<T>();
        }

        
        public List<T> Values { get; set; }

        public void Swap(int a,int b)
        {
            CheckIndex(a);
            CheckIndex(b);

            var temp = this.Values[a];

            Values[a] = Values[b];
            Values[b] = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var value in Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }
            return sb.ToString().Trim() ;
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
