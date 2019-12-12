using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riders;
        private MotorcycleRepository motorcycles;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.riders = new RiderRepository();
            this.motorcycles = new MotorcycleRepository();
            this.races = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var currentRider = this.riders.GetAll().FirstOrDefault(r => r.Name == riderName);

            if (currentRider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var currentMotorcycle = this.motorcycles.GetAll().FirstOrDefault(m => m.Model == motorcycleModel);

            if (currentMotorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            currentRider.AddMotorcycle(currentMotorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);

        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var currentRace = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);

            if (currentRace == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var currentRider = this.riders.GetAll().FirstOrDefault(r => r.Name == riderName);

            if (currentRider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderInvalid, riderName));
            }

            currentRace.AddRider(currentRider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycles.GetAll().Any(m => m.Model == model))
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            if (type == "Speed")
            {
                var motorcycle = new SpeedMotorcycle(model, horsePower);
                this.motorcycles.Add(motorcycle);

                return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
            }
            else
            {
                var motorcycle = new PowerMotorcycle(model, horsePower);
                this.motorcycles.Add(motorcycle);

                return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
            }
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);

            this.races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            var currentRider = new Rider(riderName);

            if (this.riders.GetAll().Any(r => r.Name == riderName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            this.riders.Add(currentRider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var currentRace = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);

            if (currentRace == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (currentRace.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var winningRiders = currentRace.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(currentRace.Laps)).ToList();

            this.races.Remove(currentRace);

            var firstRider = winningRiders[0];
            var secondRider = winningRiders[1];
            var thirdRider = winningRiders[2];

            return $"Rider {firstRider.Name} wins {currentRace.Name} race." + Environment.NewLine +
                   $"Rider {secondRider.Name} is second in {currentRace.Name} race." + Environment.NewLine +
                   $"Rider {thirdRider.Name} is third in {currentRace.Name} race.";
        }

        public void End()
        {
            Environment.Exit(0);
        }
    }
}
