using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : ICollection, IAddable, IRemoveable
    {
        public AddRemoveCollection()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public int Add(string item)
        {
            this.Collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            var currentItem = this.Collection[Collection.Count - 1];
            this.Collection.RemoveAt(Collection.Count - 1);

            return currentItem;
        }
    }
}
