namespace CollectionHierarchy
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void AddOperation(IAddable collection,string[] strings)
        {
            var addResult = new List<int>();

            foreach (var item in strings)
            {
                addResult.Add(collection.Add(item));
            }

            Console.WriteLine(string.Join(" ", addResult));
        }
        public static void RemoveOperation(IRemoveable collection,int removeCount)
        {
            var removeResult = new List<string>();

            for (int i = 0; i < removeCount; i++)
            {
                removeResult.Add(collection.Remove());
            }

            Console.WriteLine(string.Join(" ", removeResult));
        }
        public static void Main(string[] args)
        {
            var strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var add = new AddCollection();
            var addRemove = new AddRemoveCollection();
            var myList = new MyList();

            AddOperation(add, strings);
            
            AddOperation(addRemove, strings);
            
            AddOperation(myList, strings);

            var removeCount = int.Parse(Console.ReadLine());
            
            RemoveOperation(addRemove, removeCount);
            
            RemoveOperation(myList, removeCount);
        }
    }
}
