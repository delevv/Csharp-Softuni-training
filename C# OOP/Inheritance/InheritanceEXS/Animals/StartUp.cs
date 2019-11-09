namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                string[] animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string name = animalInfo[0];

                    if (!int.TryParse(animalInfo[1], out int age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string gender = String.Empty;

                    if (animalInfo.Length == 3)
                    {
                        gender = animalInfo[2];
                    }

                    Animal animal = null;

                    animalType = animalType.ToLower();

                    if (animalType == "dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (animalType == "cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (animalType == "frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (animalType == "kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (animalType == "tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    if (animal != null)
                    {
                        animals.Add(animal);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }
    }
}