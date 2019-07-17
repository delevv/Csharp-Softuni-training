using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamWorkProjects
{
    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team(string name,string creator)
        {
            this.TeamName = name;
            this.Creator = creator;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                string[] userInfo = Console.ReadLine().Split("-");

                string user = userInfo[0];
                string teamName = userInfo[1];

                bool isTeamExisting = true;
                bool isCreator = false;
                foreach (var currentTeam in teams)
                {
                    if (currentTeam.TeamName == teamName)
                    {
                        isTeamExisting = false;
                    }
                    if (currentTeam.Creator == user)
                    {
                        isCreator = true;
                    }
                }

                if (!isTeamExisting)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (isCreator)
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                else
                {
                    Team team = new Team(teamName, user);
                    team.Members = new List<string>();
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                }
            }
            string info;

            while ((info = Console.ReadLine()) != "end of assignment")
            {
                string[] userInfo = info.Split("->");
                string user = userInfo[0];
                string teamName = userInfo[1];

                bool isMemeber = false;

                foreach (var team in teams)
                {
                    if (team.Members.Contains(user) || team.Creator==user)
                    {
                        isMemeber = true;
                    }
                }
                if (!teams.Any(x=>x.TeamName==teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isMemeber)
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    for (int i = 0; i < teams.Count; i++)
                    {
                        if (teams[i].TeamName == teamName)
                        {
                            teams[i].Members.Add(user);
                        }
                    }
                }
            }
            List<Team> validTeams = teams.OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName).
                Where(x => x.Members.Count > 0).
                ToList();
            List<Team> disband = teams.OrderBy(x => x.TeamName).Where(x => x.Members.Count == 0).ToList();

            foreach (var team in validTeams)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");

            for (int i = 0; i < disband.Count; i++)
            {
                Console.WriteLine(disband[i].TeamName);
            }
        }
    }
}
