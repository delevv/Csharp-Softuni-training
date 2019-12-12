using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astro in astronauts)
            {
                while (planet.Items.Count > 0)
                {
                    if (astro.CanBreath)
                    {
                        astro.Breath();
                    }
                    else
                    {
                        break;
                    }

                    var currentItem = planet.Items.FirstOrDefault();

                    astro.Bag.Items.Add(currentItem);
                    planet.Items.Remove(currentItem);
                }
            }
        }
    }
}
