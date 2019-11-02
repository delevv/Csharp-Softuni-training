using System;
using System.Linq;

namespace PointInRectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var topLeft = new Point(rectangleCoordinates[0], rectangleCoordinates[1]);
            var bottomRight = new Point(rectangleCoordinates[2], rectangleCoordinates[3]);

            var rectangle = new Rectangle(topLeft, bottomRight);

            var countOfPoints = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPoints; i++)
            {
                var pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var currentPoint = new Point(pointCoordinates[0], pointCoordinates[1]);

                Console.WriteLine(rectangle.Contains(currentPoint));
            }
        }
    }
}
