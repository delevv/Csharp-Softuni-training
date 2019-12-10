using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                var line = this.reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                var commandArgs = line.Split();
                var command = commandArgs[0];

                var result = "";

                if(command== "AddPlayer")
                {
                    var playerType = commandArgs[1];
                    var playerName = commandArgs[2];

                    result = this.managerController.AddPlayer(playerType, playerName);
                }
                else if(command== "AddCard")
                {
                    var cardType = commandArgs[1];
                    var cardName = commandArgs[2];

                    result = this.managerController.AddCard(cardType, cardName);
                }
                else if(command== "AddPlayerCard")
                {
                    var username = commandArgs[1];
                    var cardName = commandArgs[2];

                    result = this.managerController.AddPlayerCard(username, cardName);
                }
                else if(command== "Fight")
                {
                    var attackUser = commandArgs[1];
                    var enemyUser = commandArgs[2];

                    result = this.managerController.Fight(attackUser, enemyUser);
                }
                else if (command == "Report")
                {
                    result = this.managerController.Report();
                }

                this.writer.WriteLine(result);
            }
        }
    }
}
