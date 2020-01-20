using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if(aquariumType== "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if(aquariumType== "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if(fishType== "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if(fishType== "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            var currentAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if(currentAquarium.GetType().Name==nameof(FreshwaterAquarium) && fish.GetType().Name == nameof(SaltwaterFish))
            {
                return "Water not suitable.";
            }

            if (currentAquarium.GetType().Name == nameof(SaltwaterAquarium) && fish.GetType().Name == nameof(FreshwaterFish))
            {
                return "Water not suitable.";
            }

            currentAquarium.AddFish(fish);

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            var currentAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            var fishValue = currentAquarium.Fish.Sum(f => f.Price);
            var decorationValue = currentAquarium.Decorations.Sum(d => d.Price);

            return $"The value of Aquarium {aquariumName} is {fishValue + decorationValue:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var currentAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            currentAquarium.Feed();

            return $"Fish fed: {currentAquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var currentDecoration = this.decorations.Models.FirstOrDefault(d => d.GetType().Name == decorationType);

            if (currentDecoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            var currentAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            currentAquarium.AddDecoration(currentDecoration);

            this.decorations.Remove(currentDecoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
