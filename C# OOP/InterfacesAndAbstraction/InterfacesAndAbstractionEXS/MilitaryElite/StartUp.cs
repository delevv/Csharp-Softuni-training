namespace MilitaryElite
{
    using MilitaryElite.Enums;
    using MilitaryElite.Interfaces;
    using MilitaryElite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var soldiers = new Dictionary<string, ISoldier>();

            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] inputInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string soldierType = inputInfo[0];
                string id = inputInfo[1];
                string firstName = inputInfo[2];
                string lastName = inputInfo[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    soldier = new Private(firstName, lastName, id, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    var privates = new Dictionary<string, IPrivate>();

                    for (int i = 5; i < inputInfo.Length; i++)
                    {
                        string soldierId = inputInfo[i];
                        var currentSoldier = (IPrivate)soldiers[soldierId];
                        privates.Add(soldierId, currentSoldier);
                    }

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    bool isValidCorps = Enum.TryParse<Corps>(inputInfo[5], out Corps corps);

                    if (isValidCorps)
                    {
                        ICollection<IRepair> repairs = new List<IRepair>();

                        for (int i = 6; i < inputInfo.Length; i += 2)
                        {
                            string partName = inputInfo[i];
                            int hours = int.Parse(inputInfo[i + 1]);
                            IRepair repair = new Repair(partName, hours);
                            repairs.Add(repair);
                        }

                        soldier = new Engineer(firstName, lastName, id, salary, corps, repairs);
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    bool isValidCorps = Enum.TryParse<Corps>(inputInfo[5], out Corps corps);

                    if (isValidCorps)
                    {
                        ICollection<IMission> missions = new List<IMission>();

                        for (int i = 6; i < inputInfo.Length; i += 2)
                        {
                            string missionName = inputInfo[i];
                            string missionState = inputInfo[i + 1];

                            bool isValidMissionState = Enum.TryParse<State>(missionState, out State stateResult);

                            if (!isValidMissionState)
                            {
                                continue;
                            }

                            IMission mission = new Mission(missionName, stateResult);
                            missions.Add(mission);
                        }

                        soldier = new Commando(firstName, lastName, id, salary, corps, missions);
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(inputInfo[4]);
                    soldier = new Spy(firstName, lastName, id, codeNumber);
                }

                if (soldier != null)
                {
                    Console.WriteLine(soldier);
                    soldiers.Add(id, soldier);
                }
            }
        }
    }
}
