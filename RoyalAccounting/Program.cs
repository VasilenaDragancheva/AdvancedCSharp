namespace RoyalAccounting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;

    public class Employee
    {
        public Employee(string name, int hours, decimal payment)
        {
            this.Name = name;

            this.Hours = hours;
            this.Payment = payment;
        }

        public string Name { get; set; }

        public string Team { get; set; }

        public int Hours { get; set; }

        public decimal Payment { get; set; }

        public decimal MonthlyPayment
        {
            get
            {
                return this.DailyIncome * 30;
            }
        }

        public decimal DailyIncome
        {
            get
            {
                return ((this.Payment * this.Hours) / 24);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var employees = new Dictionary<string, List<Employee>>();

            var pattern = @"^([a-zA-Z]+)\;(\d+)\;(\d*.\d*)\;([a-zA-Z]+)$";
            var regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Contains("Pishi kuf"))
                {
                    break;
                }

                if (!regex.IsMatch(input))
                {
                    continue;
                }

                var matches = regex.Match(input);
                var name = matches.Groups[1].ToString();
                var hours = int.Parse(matches.Groups[2].ToString());
                var m = matches.Groups[3].ToString();
                var money = decimal.Parse(matches.Groups[3].ToString());
                var team = matches.Groups[4].ToString();

                if (employees.Any(t => t.Value.Any(em => em.Name == name)))
                {
                    continue;
                }

                var employee = new Employee(name, hours, money);
                if (!employees.ContainsKey(team))
                {
                    employees.Add(team, new List<Employee>());
                }
                employees[team].Add(employee);
            }
            var orderedTeams = employees.OrderByDescending(t => t.Value.Sum(em => em.MonthlyPayment));

            foreach (var orderedTeam in orderedTeams)
            {
                Console.WriteLine("Team - {0}", orderedTeam.Key);
                var empl =
                    orderedTeam.Value.OrderByDescending(em => em.Hours)
                        .ThenByDescending(em => em.DailyIncome)
                        .ThenBy(em => em.Name, StringComparer.Ordinal);
                foreach (var em in empl)
                {
                    Console.WriteLine("$$${0} - {1} -{2:f6}", em.Name, em.Hours, em.DailyIncome);
                }
            }

        }
    }
}