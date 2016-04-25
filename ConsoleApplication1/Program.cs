namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string pattern = @"^#([a-zA-Z]+):\s*@([a-zA-Z]+)\s*(\d{1,2}:\d{1,2})$";
            Regex validEvent = new Regex(pattern);
            Dictionary<string, Dictionary<string, List<string>>> events =
                new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                if (!validEvent.IsMatch(input))
                {
                    continue;
                }

                Match eventParams = validEvent.Match(input);

                string person = eventParams.Groups[1].ToString();
                string location = eventParams.Groups[2].ToString();
                string dateTime = eventParams.Groups[3].ToString();
                int separator = dateTime.IndexOf(':');
                int hours = int.Parse(dateTime.Substring(0, separator));
                int minutes = int.Parse(dateTime.Substring(separator + 1));
                if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
                {
                    continue;
                }

                if (!events.ContainsKey(location))
                {
                    events.Add(location, new Dictionary<string, List<string>>());
                }

                if (!events[location].ContainsKey(person))
                {
                    events[location].Add(person, new List<string>());
                }

                events[location][person].Add(dateTime);
            }

            string[] locationsToSearch = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(locationsToSearch);
            foreach (var location in locationsToSearch)
            {
                if (events.ContainsKey(location))
                {
                    Console.WriteLine("{0}:", location);
                    var personsByName = events[location].OrderBy(p => p.Key);
                    int counter = 1;
                    foreach (var person in personsByName)
                    {
                        var datesTime =
                            person.Value.OrderBy(t => int.Parse(t.Substring(0, t.IndexOf(':'))))
                                .ThenBy(t => int.Parse(t.Substring(t.IndexOf(':') + 1)));
                        Console.WriteLine("{0}. {1} -> {2}", counter, person.Key, string.Join(", ", datesTime));
                        counter++;
                    }
                }
            }
        }
    }
}