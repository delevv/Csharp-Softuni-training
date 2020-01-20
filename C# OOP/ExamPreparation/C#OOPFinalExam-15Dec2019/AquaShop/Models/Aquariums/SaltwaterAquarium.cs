using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int InitialCapacity = 25;
        public SaltwaterAquarium(string name)
            : base(name, InitialCapacity)
        {
        }

        public override void AddFish(IFish fish)
        {
            if (this.Capacity == this.Fish.Count)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            if (fish is SaltwaterFish)
            {
                this.Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }
    }
}
