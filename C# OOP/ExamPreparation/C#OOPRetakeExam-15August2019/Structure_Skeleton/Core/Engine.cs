using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        private Controller controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                
                var result = "";

                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        result = controller.AddAstronaut(input[1], input[2]);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var planetMaterials = new List<string>();

                        for (int i = 2; i < input.Length; i++)
                        {
                            planetMaterials.Add(input[i]);
                        }
                        result = controller.AddPlanet(input[1], planetMaterials.ToArray());
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        result = controller.RetireAstronaut(input[1]);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        result = controller.ExplorePlanet(input[1]);
                    }
                    else if(input[0] == "Report")
                    {
                        result = controller.Report();
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
                
                writer.WriteLine(result);
            }
        }
    }
}
