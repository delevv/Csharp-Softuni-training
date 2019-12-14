using MortalEngines.Core.Contracts;
using MortalEngines.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private Reader reader;
        private Writer writer;

        private MachinesManager machinesManager;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            var result = "";

            while (true)
            {
                var line = reader.Read().Split();
                var command = line[0];

                try
                {
                    if (command == "Quit")
                    {
                        Environment.Exit(0);
                    }
                    else if (command == "HirePilot")
                    {
                        result = machinesManager.HirePilot(line[1]);
                    }
                    else if (command == "PilotReport")
                    {
                        result=machinesManager.PilotReport(line[1]);
                    }
                    else if (command == "ManufactureTank")
                    {
                        result = machinesManager.ManufactureTank(line[1], double.Parse(line[2]), double.Parse(line[3]));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        result = machinesManager.ManufactureFighter(line[1], double.Parse(line[2]), double.Parse(line[3]));
                    }
                    else if (command == "MachineReport")
                    {
                        result = machinesManager.MachineReport(line[1]);
                    }
                    else if (command == "AggressiveMode")
                    {
                        result = machinesManager.ToggleFighterAggressiveMode(line[1]);
                    }
                    else if (command == "DefenseMode")
                    {
                        result = machinesManager.ToggleTankDefenseMode(line[1]);
                    }
                    else if (command == "Engage")
                    {
                        result = machinesManager.EngageMachine(line[1],line[2]);
                    }
                    else if (command == "Attack")
                    {
                        result = machinesManager.AttackMachines(line[1], line[2]);
                    }
                }
                catch (Exception ex)
                {

                    result = "Error:" + ex.Message;
                }

                writer.WriteLine(result);
            }
        }
    }
}
