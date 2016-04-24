using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> windsByClub = new Dictionary<string, int>();
        Dictionary<string, List<string>> opponentsByClub = new Dictionary<string, List<string>>();

        string line;
        while (true)
        {
            line = Console.ReadLine();
            if (line.ToLower() == "stop")
            {
                break;
            }

            string[] input = line.Split('|');
            var team1 = input[0].Trim();
            var team2 = input[1].Trim();
            var result1 = input[2].Trim().Split(':').Select(int.Parse).ToArray();
            var result2 = input[3].Trim().Split(':').Select(int.Parse).ToArray();
            var firstHome = result1[0];
            var firstGuests = result2[1];
            var secondHome = result2[0];
            var secondGuest = result1[1];

            if (!windsByClub.ContainsKey(team1))
            {
                windsByClub.Add(team1, 0);
                opponentsByClub.Add(team1, new List<string>());
            }

            if (!windsByClub.ContainsKey(team2))
            {
                windsByClub.Add(team2, 0);
                opponentsByClub.Add(team2, new List<string>());
            }

            opponentsByClub[team1].Add(team2);
            opponentsByClub[team2].Add(team1);

            if (firstGuests + firstHome > secondGuest + secondHome)
            {
                windsByClub[team1]++;
            }
            else if (firstGuests + firstHome < secondGuest + secondHome)
            {
                windsByClub[team2]++;
            }
            else
            {
                if (firstGuests > secondGuest)
                {
                    windsByClub[team1]++;
                }
                else
                {
                    windsByClub[team2]++;
                }
            }
        }

        var sortedInitiallyteams = windsByClub.OrderByDescending(cl => cl.Value).ThenBy(cl => cl.Key);
        foreach (var team in sortedInitiallyteams)
        {
            opponentsByClub[team.Key].Sort();
            Console.WriteLine(team.Key);
            Console.WriteLine("- Wins: {0}", team.Value);
            Console.WriteLine("- Opponents: {0}", string.Join(", ", opponentsByClub[team.Key]));
        }
    }
}