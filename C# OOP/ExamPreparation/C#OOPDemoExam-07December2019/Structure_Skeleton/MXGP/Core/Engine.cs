using MXGP.Core.Contracts;
using MXGP.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private ConsoleReader reader;
        private ConsoleWriter writer;
        private ChampionshipController controller;

        public Engine(ConsoleReader reader, ConsoleWriter writer, ChampionshipController controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = controller;
        }

        public void Run()
        {
            while (true)
            {
                var inputLine = reader.ReadLine().Split();
                var command = inputLine[0];

                var result = "";
                try
                {
                    switch (command)
                    {
                        case "CreateRider":
                            result = controller.CreateRider(inputLine[1]);
                            break;
                        case "CreateMotorcycle":
                            result = controller.CreateMotorcycle(inputLine[1], inputLine[2], int.Parse(inputLine[3]));
                            break;
                        case "AddMotorcycleToRider":
                            result = controller.AddMotorcycleToRider(inputLine[1], inputLine[2]);
                            break;
                        case "AddRiderToRace":
                            result = controller.AddRiderToRace(inputLine[1], inputLine[2]);
                            break;
                        case "CreateRace":
                            result = controller.CreateRace(inputLine[1], int.Parse(inputLine[2]));
                            break;
                        case "StartRace":
                            result = controller.StartRace(inputLine[1]);
                            break;
                        case "End":
                            controller.End();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    result=ex.Message;
                }
                
                writer.WriteLine(result);
            }
        }
    }
}
