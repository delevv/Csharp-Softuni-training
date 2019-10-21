using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int,Person> data;
        public int Count => this.data.Count;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public void Add(Person person)
        {
            this.data[this.data.Count] = person;
        }

        public Person Get(int id)
        {
            return this.data[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if(this.data.ContainsKey(id))
            {
                this.data[id] = newPerson;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (this.data.ContainsKey(id))
            {
                this.data.Remove(id);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
