using System;

namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = int.Parse(Console.ReadLine());

            var galaxy = new char[rowsAndCols, rowsAndCols];
           
            var spaceShipRow = -1;
            var spaceShipCol = -1;

            var firstHoleRow = -1;
            var firstHoleCol = -1;

            var secondHoleRow = -1;
            var secondHoleCol = -1;

            var holeCount = 1;

            for (int row = 0; row < rowsAndCols; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < rowsAndCols; col++)
                {
                    galaxy[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        spaceShipRow = row;
                        spaceShipCol = col;
                    }

                    if (currentRow[col] == 'O')
                    {
                        if (holeCount == 1)
                        {
                            firstHoleRow = row;
                            firstHoleCol = col;
                            holeCount++;
                        }
                        else
                        {
                            secondHoleRow = row;
                            secondHoleCol = col;
                        }
                    }
                }
            }

            var currentStars = 0;

            while (true)
            {
                var command = Console.ReadLine();

                var moveRow = 0;
                var moveCol = 0;

                if (command == "up")
                {
                    moveRow = -1;
                }
                else if (command == "down")
                {
                    moveRow = 1;
                }
                else if (command == "right")
                {
                    moveCol = 1;
                }
                else if (command == "left")
                {
                    moveCol = -1;
                }

                galaxy[spaceShipRow, spaceShipCol] = '-';

                var isInside= spaceShipRow + moveRow >= 0 && spaceShipRow + moveRow < galaxy.GetLength(0) &&
                             spaceShipCol + moveCol >= 0 && spaceShipCol + moveCol < galaxy.GetLength(1);
                if (isInside)
                {
                    spaceShipRow += moveRow;
                    spaceShipCol += moveCol;

                    if (char.IsDigit(galaxy[spaceShipRow, spaceShipCol]))
                    {
                        currentStars += galaxy[spaceShipRow, spaceShipCol] - '0';
                    }
                    else if (galaxy[spaceShipRow, spaceShipCol] == 'O')
                    {
                        if (firstHoleRow == spaceShipRow && firstHoleCol == spaceShipCol)
                        {
                            galaxy[firstHoleRow, firstHoleCol] = '-';

                            spaceShipRow = secondHoleRow;
                            spaceShipCol = secondHoleCol;
                        }
                        else
                        {
                            galaxy[secondHoleRow, secondHoleCol] = '-';

                            spaceShipRow = firstHoleRow;
                            spaceShipCol = firstHoleCol;
                        }
                    }
                    galaxy[spaceShipRow, spaceShipCol] = 'S';

                    if (currentStars >= 50)
                    {
                        Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    break;
                }

            }
            Console.WriteLine($"Star power collected: {currentStars}");

            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    Console.Write(galaxy[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
