using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly IPlayer mainPlayer;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood hood;

        public Controller()
        {
            this.civilPlayers = new List<IPlayer>();
            this.mainPlayer = new MainPlayer();
            this.guns = new List<IGun>();
            this.hood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (nameof(Rifle) == type)
            {
                gun = new Rifle(name);
            }
            else if (nameof(Pistol) == type)
            {
                gun = new Pistol(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.guns.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var currentGun = this.guns.FirstOrDefault();

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(currentGun);
                this.guns.Remove(currentGun);
                return $"Successfully added {currentGun.Name} to the Main Player: Tommy Vercetti";
            }

            var currentCivilPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);

            if (currentCivilPlayer == null)
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                currentCivilPlayer.GunRepository.Add(currentGun);
                this.guns.Remove(currentGun);

                return $"Successfully added {currentGun.Name} to the Civil Player: {currentCivilPlayer.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            var currentPlayer = new CivilPlayer(name);

            this.civilPlayers.Add(currentPlayer);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var mainPlayerHealthBeforeFight = this.mainPlayer.LifePoints;
            var civilPlayersHealthBeforeFight = this.civilPlayers.Sum(p => p.LifePoints);

            this.hood.Action(this.mainPlayer, this.civilPlayers);

            if (mainPlayerHealthBeforeFight == this.mainPlayer.LifePoints &&
                civilPlayersHealthBeforeFight == this.civilPlayers.Sum(p => p.LifePoints))
            {
                return "Everything is okay!";
            }
            else
            {
                return "A fight happened:" + Environment.NewLine
                    + $"Tommy live points: {this.mainPlayer.LifePoints}!" + Environment.NewLine
                    + $"Tommy has killed: {this.civilPlayers.Where(p => !p.IsAlive).Count()} players!" + Environment.NewLine
                    + $"Left Civil Players: {this.civilPlayers.Where(p => p.IsAlive).Count()}!";
            }
        }
    }
}
