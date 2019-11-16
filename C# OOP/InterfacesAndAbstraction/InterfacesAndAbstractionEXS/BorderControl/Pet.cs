using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IId
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.Birthdate = birthDate;
        }

        public string Birthdate { get; }

        public string Name { get; }

        public string Id => "no id";
    }
}
