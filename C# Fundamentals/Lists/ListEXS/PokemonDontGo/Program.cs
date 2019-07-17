using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int valueOfAll = 0;

            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < pokemons.Count)
                {
                    int value = pokemons[index];
                    valueOfAll += value;
                    pokemons.RemoveAt(index);

                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else
                        {
                            pokemons[i] -= value;
                        }
                    }
                }
                else if (index < 0)
                {
                    int value = pokemons[0];
                    valueOfAll += value;
                    pokemons[0] = pokemons[pokemons.Count - 1];
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else
                        {
                            pokemons[i] -= value;
                        }
                    }
                }
                else if (index > pokemons.Count - 1)
                {
                    int value = pokemons[pokemons.Count - 1];
                    valueOfAll += value;
                    pokemons[pokemons.Count - 1] = pokemons[0];
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else
                        {
                            pokemons[i] -= value;
                        }
                    }
                }
            }
            Console.WriteLine(valueOfAll);
        }
    }
}
