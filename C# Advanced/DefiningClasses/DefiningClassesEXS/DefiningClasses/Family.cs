using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> peopleList;

        public List<Person> PeopleList
        {       
            get { return this.peopleList; }
            set { this.peopleList = value; }
        }

        public Family()
        {
            this.peopleList = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.peopleList.Add(member);
        }
        public Person GetOldestMember()
        {
            return peopleList.OrderByDescending(p => p.Age).FirstOrDefault();
        }

    }
}
