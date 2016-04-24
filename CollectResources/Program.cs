using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectResources
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] resources = Console.ReadLine().Split(' ');
            int possibleWays = int.Parse(Console.ReadLine());
            List<int> countCOllected = new List<int>();
            string[] validResourced = { "stone", "gold", "wood", "food" };
            for (int i = 0; i < possibleWays; i++)
            {
                int[] currentWay = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int start = currentWay[0];
                int step = currentWay[1];
                bool[] collectedResources = new bool[resources.Length];
                int currentCollected = 0;

                while (!collectedResources[start])
                {
                    string current;
                    int count;
                    if (resources[start].Contains('_'))
                    {
                        current = resources[start].Split('_')[0];
                        count = int.Parse(resources[start].Split('_')[1]);
                    }
                    else
                    {
                        current = resources[start];
                        count = 1;
                    }

                    if (validResourced.Contains(current))
                    {
                        currentCollected += count;
                        collectedResources[start] = true;
                    }

                    start = (start + step) % resources.Length;

                }

                countCOllected.Add(currentCollected);
            }
            Console.WriteLine(countCOllected.Max());
        }
    }
}
