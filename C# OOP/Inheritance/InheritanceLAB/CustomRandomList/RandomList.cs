using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            var randomIndex = new Random().Next(0,this.Count);

            var currentString = this[randomIndex];

            this.RemoveAt(randomIndex);

            return currentString;
        }
    }
}
