using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Threeuple<Titem1,Titem2,Titem3>
    {
        public Threeuple(Titem1 item1, Titem2 item2, Titem3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public Titem1 item1 { get; set; }

        public Titem2 item2 { get; set; }

        public Titem3 item3 { get; set; }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}";
        }
    }
}
