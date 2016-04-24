using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {                 //color         name    data  
            Dictionary<string, Dictionary<string, double[]>> dragoons = new Dictionary<string, Dictionary<string, double[]>>();
            int n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                string[] dataDragon = Console.ReadLine().Split(' ');
                string color = dataDragon[0];
                string name = dataDragon[1];
                double[] stat = new double[3];
                for (int m  = 0; m< 3; m++)
                {
                    if (dataDragon[m + 2] == "null")
                    {
                        if (m == 0)
                        {
                            stat[m] = 250;
                        }
                        if (m == 1)
                        {
                            stat[m] = 45;
                        }
                        if (m == 2)
                        {
                            stat[m] = 10;
                        }
                    }
                    else
                    {
                        stat[m] = double.Parse(dataDragon[m + 2]);
                    }
                }
                if (!dragoons.ContainsKey(color))
                {
                    dragoons.Add(color,new Dictionary<string, double[]>());
                }
                if(!dragoons[color].ContainsKey(name))
                {
                    dragoons[color].Add(name, stat);
                }
            }
            var dragoonsByColor = dragoons.OrderBy(color => color.Key);
            foreach (var color in dragoonsByColor)
            {
                var dragoonsByName = color.Value.OrderBy(drg => drg.Key);
               
                double? averDamage = color.Value.Average(dragName => dragName.Value[0]);
                double? averHealth=color.Value.Average(dragName=>dragName.Value[1]);
                double? averArmor = color.Value.Average(dragName => dragName.Value[2]);
                Console.WriteLine(string.Format("{0}{1:f2}{2:f2}{3:f2}",color.Key,averDamage,averHealth,averArmor));
                foreach (var dragoon in dragoonsByName)
                {
                    Console.WriteLine("-{0}->damage:{1:f2},health:{2:f2},armor:{3:f2}",dragoon.Key,dragoon.Value[0],dragoon.Value[1],dragoon.Value[2]); 
                }   
            }


        }
    }
}
