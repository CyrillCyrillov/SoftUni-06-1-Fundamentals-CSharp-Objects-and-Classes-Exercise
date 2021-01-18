using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Task05_Teamwork_Projects
{
    class Team
    {
        public Team(string teamName, string creatorName)
        {
            TeamName = teamName;
            CreatorName = creatorName;
            Members = new List<string>();
        }

        public string TeamName { get; set; }

        public string CreatorName { get; set; }

        public List<string> Members { get; set; }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            List<Team> allTeams = new List<Team>();

            for (int i = 1; i <= countOfTeams; i++)
            {
                string[] newTaemDatas = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Team newTeam = new Team(newTaemDatas[1], newTaemDatas[0]);

                bool isTeamNameExost = allTeams.Select(x => x.TeamName).Contains(newTaemDatas[1]);
                bool isCreatorExist = allTeams.Select(x => x.CreatorName).Contains(newTaemDatas[0]);


                if(isTeamNameExost)
                {
                    Console.WriteLine($"Team {newTaemDatas[1]} was already created!");
                }
                else
                {
                    if(isCreatorExist)
                    {
                        Console.WriteLine($"{newTaemDatas[0]} cannot create another team!");
                    }
                    else
                    {
                        allTeams.Add(newTeam);
                        Console.WriteLine($"Team {newTaemDatas[1]} has been created by {newTaemDatas[0]}!");
                    }

                }
            }

            while(true)
            {
                string[] comand = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(comand[0].ToUpper() == "END OF ASSIGNMENT")
                {
                    break;
                }

                string naneToJoin = comand[0];
                string teamToJoin = comand[1];

                bool isTeamExist = allTeams.Select(x => x.TeamName).Contains(teamToJoin);
                bool isCreatorExist = allTeams.Select(x => x.CreatorName).Contains(naneToJoin);
                bool isMemberExist = allTeams.Select(x => x.Members).Any(x => x.Contains(naneToJoin));

                if(!isTeamExist)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if(isCreatorExist || isMemberExist)
                {
                    Console.WriteLine($"Member {naneToJoin} cannot join team {teamToJoin}!");
                }
                else
                {
                    int index = allTeams.FindIndex(x => x.TeamName == teamToJoin);
                    allTeams[index].Members.Add(naneToJoin);
                }
            }

            Team[] teamsToDisband = allTeams.OrderBy(x => x.TeamName).Where(x => x.Members.Count == 0).ToArray();
            Team[] fullTeam = allTeams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).Where(x => x.Members.Count > 0).ToArray();

            StringBuilder sb = new StringBuilder();
            
            foreach(Team team in fullTeam)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.CreatorName}");

                foreach (var member in team.Members.OrderBy(x=>x))
                {
                    sb.AppendLine($"-- {member}"); 
                }
            }

            sb.AppendLine("Teams to disband:");
            foreach (Team item in teamsToDisband)
            {
                sb.AppendLine(item.TeamName);
            }


            
            Console.WriteLine(sb.ToString());
        }
    }
}
