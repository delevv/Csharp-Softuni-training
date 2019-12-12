using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private int ExploredPlanetsCount;
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private Mission mission;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astro = null;

            if (nameof(Biologist) == type)
            {
                astro = new Biologist(astronautName);
            }
            else if (nameof(Geodesist) == type)
            {
                astro = new Geodesist(astronautName);
            }
            else if (nameof(Meteorologist) == type)
            {
                astro = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astro);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsWithMoreThan60Oxygen = this.astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (astronautsWithMoreThan60Oxygen.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            var currentPlanet = this.planets.Models.First(p => p.Name == planetName);

            var liveAstronautsCount = this.astronauts.Models.Where(a => a.CanBreath).Count();

            this.mission.Explore(currentPlanet, astronautsWithMoreThan60Oxygen);

            ExploredPlanetsCount++;

            var deadAstronauts = liveAstronautsCount - this.astronauts.Models.Where(a => a.CanBreath).Count();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);

        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{ExploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astro in astronauts.Models)
            {
                sb.AppendLine($"Name: {astro.Name}");
                sb.AppendLine($"Oxygen: {astro.Oxygen}");

                if (astro.Bag.Items.Count > 0)
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astro.Bag.Items)}");
                }
                else
                {
                    sb.AppendLine($"Bag items: none");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var currentAstro = this.astronauts.Models.FirstOrDefault(m => m.Name == astronautName);

            if (currentAstro == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(currentAstro);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
