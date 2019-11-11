using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var boxLenght = double.Parse(Console.ReadLine());
            var boxWidth = double.Parse(Console.ReadLine());
            var boxHeight = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(boxLenght, boxWidth, boxHeight);
                Console.WriteLine(box);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);            
            } 
        }
    }
}
