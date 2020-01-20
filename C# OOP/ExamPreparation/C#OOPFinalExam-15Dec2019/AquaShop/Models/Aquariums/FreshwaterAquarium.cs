using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int InitialCapacity = 50;
        public FreshwaterAquarium(string name)
            : base(name, InitialCapacity)
        {
        }

        public override void AddFish(IFish fish)
        {
            if (this.Capacity == this.Fish.Count)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            if (fish is FreshwaterFish)
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
