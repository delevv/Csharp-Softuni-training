using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int rowsCount = int.Parse(Console.ReadLine());
        char[][] room = new char[rowsCount][];

        int[] samCoordinates = InitializeMatrix(room);

        string command = Console.ReadLine();

        foreach (var move in command)
        {
            MoveEnemies(room);
            CheckEnemies(room);
            MoveSam(move, room, samCoordinates);
            CheckNikoladze(room);
        }
    }

    private static void CheckNikoladze(char[][] room)
    {
        for (var row = 0; row < room.Length; row++)
        {
            if (room[row].Contains('N') && room[row].Contains('S'))
            {
                room[row][Array.IndexOf(room[row], 'N')] = 'X';
                Console.WriteLine($"Nikoladze killed!");
                PrintMatrix(room);
            }
        }
    }

    private static void MoveSam(char move, char[][] room, int[] coordinates)
    {
        switch (move)
        {
            case 'U':
                room[coordinates[0]][coordinates[1]] = '.';
                room[--coordinates[0]][coordinates[1]] = 'S';
                break;
            case 'D':
                room[coordinates[0]][coordinates[1]] = '.';
                room[++coordinates[0]][coordinates[1]] = 'S';
                break;
            case 'L':
                room[coordinates[0]][coordinates[1]] = '.';
                room[coordinates[0]][--coordinates[1]] = 'S';
                break;
            case 'R':
                room[coordinates[0]][coordinates[1]] = '.';
                room[coordinates[0]][++coordinates[1]] = 'S';
                break;
            default:
                break;
        }
    }

    private static void CheckEnemies(char[][] room)
    {
        for (var row = 0; row < room.Length; row++)
        {
            if (room[row].Contains('b') && room[row].Contains('S'))
            {
                if (Array.IndexOf(room[row], 'b') < Array.IndexOf(room[row], 'S'))
                {
                    room[row][Array.IndexOf(room[row], 'S')] = 'X';
                    Console.WriteLine($"Sam died at {row}, {Array.IndexOf(room[row], 'X')}");
                    PrintMatrix(room);
                }
            }
            else if (room[row].Contains('d') && room[row].Contains('S'))
            {
                if (Array.IndexOf(room[row], 'd') > Array.IndexOf(room[row], 'S'))
                {
                    room[row][Array.IndexOf(room[row], 'S')] = 'X';
                    Console.WriteLine($"Sam died at {row}, {Array.IndexOf(room[row], 'X')}");
                    PrintMatrix(room);
                }
            }
        }
    }

    private static void PrintMatrix(char[][] room)
    {
        foreach (var row in room)
        {
            Console.WriteLine(String.Join("", row));
        }
        Environment.Exit(0);
    }

    private static void MoveEnemies(char[][] room)
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'b')
                {
                    if (col == room[row].Length - 1)
                    {
                        room[row][col] = 'd';
                    }
                    else
                    {
                        room[row][col] = '.';
                        room[row][++col] = 'b';
                    }
                }
                else if (room[row][col] == 'd')
                {
                    if (col == 0)
                    {
                        room[row][col] = 'b';
                    }
                    else
                    {
                        room[row][col] = '.';
                        room[row][col - 1] = 'd';
                    }
                }
            }
        }
    }

    private static int[] InitializeMatrix(char[][] room)
    {
        int[] coordinates = null;
        for (int i = 0; i < room.Length; i++)
        {
            string row = Console.ReadLine();

            room[i] = row.ToCharArray();

            if (room[i].Contains('S'))
            {
                coordinates = new int[] { i, Array.IndexOf(room[i], 'S') };
            }
        }
        return coordinates;
    }
}
