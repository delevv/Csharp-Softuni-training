namespace CollectionHierarchy
{
    using System.Collections.Generic;

    public class MyList : ICollection, IAddable, IRemoveable
    {
        public MyList()
        {
            this.Collection = new List<string>();
        }

        public int Used => this.Collection.Count;
        public List<string> Collection { get; }

        public int Add(string item)
        {
            this.Collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            var currentItem = this.Collection[0];
            this.Collection.RemoveAt(0);

            return currentItem;
        }
    }
}
