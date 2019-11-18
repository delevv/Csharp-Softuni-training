namespace CollectionHierarchy
{
    using System.Collections.Generic;

    public class AddCollection : ICollection, IAddable
    {
        public AddCollection()
        {
            Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public int Add(string item)
        {
            this.Collection.Add(item);

            return this.Collection.Count - 1;
        }
    }
}
