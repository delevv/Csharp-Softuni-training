using System;

namespace Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string text = Console.ReadLine();
                int nameStartIndex = text.IndexOf("@")+1;
                int nameEndIndex = text.IndexOf("|");
                string name = text.Substring(nameStartIndex, nameEndIndex - nameStartIndex);

                int ageStartIndex = text.IndexOf("#") + 1;
                int ageEndIndex = text.IndexOf("*");
                string age = text.Substring(ageStartIndex, ageEndIndex - ageStartIndex);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
