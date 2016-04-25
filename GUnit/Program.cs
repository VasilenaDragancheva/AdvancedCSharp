namespace GUnit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            var validInputPattern = @"^([A-Z][a-zA-Z0-9]+)\s\|\s([A-Z][a-zA-Z0-9]+)\s\|\s([A-Z][a-zA-Z0-9]+)$";

            Regex inputValidator = new Regex(validInputPattern);

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "It's testing time!")
                {
                    break;
                }

                if (!inputValidator.IsMatch(line))
                {
                    continue;
                }

                var paramteres = inputValidator.Match(line);
                var className = paramteres.Groups[1].ToString();
                var methodName = paramteres.Groups[2].ToString();
                var testName = paramteres.Groups[3].ToString();

                if (!data.ContainsKey(className))
                {
                    data.Add(className, new Dictionary<string, HashSet<string>>());
                }

                if (!data[className].ContainsKey(methodName))
                {
                    data[className].Add(methodName, new HashSet<string>());
                }

                data[className][methodName].Add(testName);
            }

            var orderedClasses =
                data.OrderByDescending(c => c.Value.Sum(m => m.Value.Count))
                    .ThenBy(c => c.Value.Keys.Count)
                    .ThenBy(c => c.Key, StringComparer.InvariantCulture);
            foreach (var orderedClass in orderedClasses)
            {
                Console.WriteLine("{0}:", orderedClass.Key);
                var methods = orderedClass.Value.OrderByDescending(m => m.Value.Count).ThenBy(m => m.Key);
                foreach (var method in methods)
                {
                    Console.WriteLine("##{0}", method.Key);
                    var tests = method.Value.OrderBy(t => t.Length).ThenBy(t => t, StringComparer.InvariantCulture);
                    foreach (var test in tests)
                    {
                        Console.WriteLine("####{0}", test);
                    }
                }
            }
        }
    }
}