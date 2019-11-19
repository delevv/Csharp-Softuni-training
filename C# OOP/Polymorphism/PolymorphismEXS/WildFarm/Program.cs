namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Foods;

    public class Program
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();

            var command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                var animalInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var animalType = animalInfo[0];
                var animalName = animalInfo[1];
                var animalWeight = double.Parse(animalInfo[2]);

                Animal animal = null;

                switch (animalType)
                {
                    case "Owl":
                        animal = new Owl(animalName, animalWeight, double.Parse(animalInfo[3]));
                        break;
                    case "Hen":
                        animal = new Hen(animalName, animalWeight, double.Parse(animalInfo[3]));
                        break;
                    case "Mouse":
                        animal = new Mouse(animalName, animalWeight, animalInfo[3]);
                        break;
                    case "Dog":
                        animal = new Dog(animalName, animalWeight, animalInfo[3]);
                        break;
                    case "Cat":
                        animal = new Cat(animalName, animalWeight, animalInfo[3], animalInfo[4]);
                        break;
                    case "Tiger":
                        animal = new Tiger(animalName, animalWeight, animalInfo[3], animalInfo[4]);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(animal.ProduceSound());

                var foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var foodType = foodInfo[0];
                var foodQuantity = int.Parse(foodInfo[1]);

                Food food = null;

                switch (foodType)
                {
                    case "Vegetable":
                        food = new Vegetable(foodQuantity);
                        break;
                    case "Fruit":
                        food = new Fruit(foodQuantity);
                        break;
                    case "Meat":
                        food = new Meat(foodQuantity);
                        break;
                    case "Seeds":
                        food = new Seeds(foodQuantity);
                        break;
                    default:
                        break;
                }

                animal.Feed(food);
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
