using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;
    using MXGP.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new ChampionshipController());

            engine.Run();
         
            //Motorcycle varche = new PowerMotorcycle("12214235", 75);
         //Console.WriteLine(varche.HorsePower);
        }
    }
}
