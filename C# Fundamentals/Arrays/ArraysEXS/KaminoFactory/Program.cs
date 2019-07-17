using System;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int bestCount = 0;
            int countOfSamples = 0;
            int bestSum = 0;
            int[] bestArray = new int[lenght];
            int bestIndex = lenght;
            int bestLenght = 0;

            while (command != "Clone them!")
            {
                int index = 0;
                int[] array = new int[lenght];
                for (int i = 0; i < command.Length; i++)
                {
                    if (command[i] == '1' || command[i] == '0')
                    {
                        array[index] = command[i] - '0';
                        index++;
                    }
                }
                int startIndex = 0;
                int currentLenght = 0;
                int currentBestLenght = 0;
                int sum = 0;
                countOfSamples++;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                    if (array[i] == 1)
                    {
                        currentLenght++;

                    }
                    else
                    {
                        currentLenght = 0;
                    }
                    if (currentLenght > currentBestLenght)
                    {
                        startIndex = i - currentLenght + 1;
                        currentBestLenght = currentLenght;
                    }
                }

                if (currentBestLenght > bestLenght || startIndex < bestIndex || sum > bestSum)
                {
                    bestLenght = currentBestLenght;
                    bestCount = countOfSamples;
                    bestSum = sum;
                    bestIndex = startIndex;
                    bestArray = array;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestCount} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestArray));
        }
    }
}
