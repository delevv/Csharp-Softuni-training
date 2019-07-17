using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            double halfOfN = N *0.5;
            int countOfTargets = 0;

            while (N >= M)
            {
                if (N == halfOfN)
                {
                    if(Y>0)
                        N /= Y;
                    if (N < M) break;
                }

                N -= M;
                countOfTargets++;
            }
            Console.WriteLine(N);
            Console.WriteLine(countOfTargets);

        }
    }
}
