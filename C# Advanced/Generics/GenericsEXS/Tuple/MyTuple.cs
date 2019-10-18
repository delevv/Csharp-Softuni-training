using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class MyTuple<Titem1,Titem2>
    {
        public MyTuple(Titem1 item1, Titem2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public Titem1 item1 { get; set; }
        public Titem2 item2 { get; set; }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
