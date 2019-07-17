using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] bugsIndex = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] fieldWithBugs = new int[sizeOfField];

            for (int i = 0; i < bugsIndex.Length; i++)
            {
                if (bugsIndex[i] >= 0 && bugsIndex[i] < fieldWithBugs.Length)
                {
                    fieldWithBugs[bugsIndex[i]] = 1;
                }
            }
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] bugsInstruction = command.Split().ToArray();

                int currentBugPosition = int.Parse(bugsInstruction[0]);
                string direction = bugsInstruction[1];
                int moves = int.Parse(bugsInstruction[2]);
                if (moves < 0)
                {
                    moves = Math.Abs(moves);
                    if (direction == "left") direction = "right";
                    else if (direction == "right") direction = "left";
                }

                if (currentBugPosition >= 0 && currentBugPosition < sizeOfField)
                {
                    if (fieldWithBugs[currentBugPosition] == 1)
                    {
                        fieldWithBugs[currentBugPosition] = 0;
                        if (direction == "right")
                        {
                            if (currentBugPosition + moves < sizeOfField)
                            {
                                int currentMoves = moves;
                                if (fieldWithBugs[currentBugPosition + currentMoves] == 0)
                                {
                                    fieldWithBugs[currentBugPosition + currentMoves] = 1;
                                }
                                else
                                {
                                    while (fieldWithBugs[currentBugPosition + currentMoves] != 0)
                                    {
                                        currentMoves += moves;
                                        if (currentBugPosition + currentMoves > sizeOfField - 1) break;
                                        else if (fieldWithBugs[currentBugPosition + currentMoves] == 0)
                                        {
                                            fieldWithBugs[currentBugPosition + currentMoves] = 1;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            if (currentBugPosition - moves >= 0)
                            {
                                int currentMoves = moves;
                                if (fieldWithBugs[currentBugPosition - currentMoves] == 0)
                                {
                                    fieldWithBugs[currentBugPosition - currentMoves] = 1;
                                }
                                else
                                {
                                    while (fieldWithBugs[currentBugPosition - currentMoves] != 0)
                                    {
                                        currentMoves += moves;
                                        if (currentBugPosition - currentMoves < 0) break;
                                        else if (fieldWithBugs[currentBugPosition - currentMoves] == 0)
                                        {
                                            fieldWithBugs[currentBugPosition - currentMoves] = 1;
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", fieldWithBugs));
        }
    }
}