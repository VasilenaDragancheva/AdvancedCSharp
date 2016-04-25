namespace Accounting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> incomesCosts = new Dictionary<string, int>
                                                       {
                                                           { "Previous years deficit", -1 }, 
                                                           { "Machines", -1 }, 
                                                           { "Taxes", -1 }, 
                                                           { "Product development", 1 }, 
                                                           { "Unconditional funding", 1 }
                                                       };
            List<decimal[]> workers = new List<decimal[]>();
            int index = 0;
            decimal initialCapital = decimal.Parse(Console.ReadLine());
            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line.ToLower() == "end")
                {
                    break;
                }

                string[] information = line.Split(';');
                decimal[] workersInfo = information.Take(3).Select(decimal.Parse).ToArray();
                workers.Add(new[] { workersInfo[0], workersInfo[2] });
                string[] events = information.Skip(3).ToArray();
                foreach (string evnt in events)
                {
                    int factor = incomesCosts[evnt.Split(':')[0]];
                    initialCapital += factor * decimal.Parse(evnt.Split(':')[0]);
                }

                for (int i = 0; i < workers.Count - 1; i++)
                {
                    initialCapital -= workers[i][0] * workers[i][2];
                }

                decimal fired = workersInfo[1];
                decimal allWorkers = workers.Sum(day => day[0]);
                decimal uslovieto = fired <= allWorkers ? 0 : fired - allWorkers;
                while (fired > uslovieto)
                {
                    for (int i = index; i > workers.Count; i++)
                    {
                        if (workers[i][0] == 0)
                        {
                        }
                        else if (workers[i][0] >= fired)
                        {
                            workers[i][0] -= fired;
                            fired = 0;
                            break;
                        }
                        else
                        {
                            workers[i][0] = 0;
                            fired -= workers[i][0];
                            index++;
                        }
                    }
                }
            }
        }
    }
}