using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleaRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int jumps = int.Parse(Console.ReadLine());
            int race = int.Parse(Console.ReadLine());
            Dictionary<string, int> fleas = new Dictionary<string, int>();
            Dictionary<string,char[]> traces = new Dictionary<string,char[]>();
            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                string[] data = line.Split(',');
                string name = data[0];
                int jump = int.Parse(data[1].Trim());
                char[] trace = Enumerable.Repeat('.', race).ToArray();
                trace[0] = name.ToUpper()[0];
                traces.Add(name, trace);
                fleas.Add(name,jump);
             
            }
            string winner = null;
            bool endOfRace = false;
            int longestDistance = 0;
            for (int i = 0; i < jumps; i++)
            {

                foreach (var flea in traces)
                {
                   char sign = flea.Key.ToUpper()[0];
                   int currentPosition=Array.IndexOf(flea.Value,sign);
                   int nextPostion = currentPosition + fleas[flea.Key];
                   if (nextPostion >= race-1)
                   {
                       winner = flea.Key;
                       endOfRace = true;
                       break;
                   }
                   else
                   {
                       traces[flea.Key][nextPostion] = sign;
                       traces[flea.Key][currentPosition] = '.';
                       if (currentPosition >= longestDistance)
                       {
                           longestDistance = currentPosition;
                           winner = flea.Key;
                       }
                   }
                }

               
                //if (endOfRace)
                //{
                //    Console.WriteLine("Winner: " + winner);
                //    break;
                //}
                
            }
            Console.WriteLine("Winner: " + winner);
        }
    }
}
