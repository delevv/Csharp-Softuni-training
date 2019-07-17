using System;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] array = new int[count];
            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                int sum = 0;
                for (int j = 0; j < name.Length; j++)
                {
                    int currentLetterValue = name[j];
                    switch (name[j])
                    {
                        case 'a':
                        case 'A':
                        case 'e':
                        case 'E':
                        case 'i':
                        case 'I':
                        case 'o':
                        case 'O':
                        case 'u':
                        case 'U':
                            sum += name[j] * name.Length;
                            break;
                        default:
                            sum += name[j] / name.Length;
                            break;
                    }
                    array[i] = sum;
                }
            }
            Array.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
