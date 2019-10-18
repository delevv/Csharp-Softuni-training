using System;

namespace DoubleLinkedList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //•	void AddFirst(int element) – adds an element at the beginning of the collection
            //•	void AddLast(int element) – adds an element at the end of the collection
            //•	int RemoveFirst() – removes the element at the beginning of the collection
            //•	int RemoveLast() – removes the element at the end of the collection
            //•	void ForEach() – goes through the collection and executes a given action
            //•	void Clear() – delete all elements in collection
            //•	int[] ToArray() – returns the collection as an array

            var doubleLinkedList = new DoubleLinkedList<int>();

            doubleLinkedList.AddFirst(1);
            doubleLinkedList.AddFirst(2);
            doubleLinkedList.AddFirst(3);

            doubleLinkedList.ForEach(Console.WriteLine, false);

            int[] arr = doubleLinkedList.ToArray();

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
