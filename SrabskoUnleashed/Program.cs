namespace SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Program
    {
        public static void Main(string[] args)
        {
            var venues = new Dictionary<string, Dictionary<string, decimal>>();
            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                if (!line.Contains('@'))
                {
                    continue;
                }

                string[] commandParams = new string[4];
                bool validInput = ParseValidCommand(line, out commandParams);
                if (!validInput)
                {
                    continue;
                }
                string venue = commandParams[0];
                string singer = commandParams[1];
                decimal price = decimal.Parse(commandParams[2]);
                int count = int.Parse(commandParams[3]);

                if (!venues.ContainsKey(venue))
                {
                    venues.Add(venue, new Dictionary<string, decimal>());
                }
                if (!venues[venue].ContainsKey(singer))
                {
                    venues[venue].Add(singer, 0);
                }
                venues[venue][singer] += price * count;
            }

            foreach (var venue in venues)
            {
                Console.WriteLine(venue.Key);
                var singersByIncomes = venue.Value.OrderByDescending(singer => singer.Value);
                foreach (var singer in singersByIncomes)
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }
            }
        }

        private static bool ParseValidCommand(string line, out string[] commandParams)
        {
            string[] parts = line.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                commandParams = new string[4];
                return false;
            }
            string[] secondPart = parts[1].Split(' ');
            if (secondPart.Length < 3)
            {
                commandParams = new string[4];
                return false;
            }
            string singerName = parts[0];
            int places;
            decimal price;

            bool validSingerName = singerName[singerName.Length - 1] == ' ';
            bool validPlaces = int.TryParse(secondPart[secondPart.Length - 1], out places);
            bool validPrice = decimal.TryParse(secondPart[secondPart.Length - 2], out price);
            bool validCommand = validSingerName && validPlaces && validPrice;
            commandParams = new string[4];
            if (!validCommand)
            {
                return false;
            }


            commandParams[1] = singerName.Substring(0, singerName.Length - 1);
            commandParams[0] = string.Join(" ", secondPart, 0, secondPart.Length - 2);
            commandParams[2] = secondPart[secondPart.Length - 2];
            commandParams[3] = secondPart[secondPart.Length - 1];
            return true;
        }
    }
}