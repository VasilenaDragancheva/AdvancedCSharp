using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightlife
{
    class Program
    {//result[city][venue]=performer
       
        static void Main(string[] args)
        {
             Dictionary<string, Dictionary<string, List<string>>> result = new Dictionary<string, Dictionary<string,List<string>>>();
            string line;
            while (true)
            {
                line = Console.ReadLine();
                if(line.ToLower()=="end")
                {
                    break;
                }
                string[] data = line.Split(';');
                string city = data[0];
                string venue = data[1];
                string performer = data[2];
              if(!result.ContainsKey(city))
              {
                  result.Add(city, new Dictionary<string, List<string>>());
                 
              }
              if (!result[city].ContainsKey(venue))
              {
                  result[city].Add(venue,new List<string>());
              }

              if (!result[city][venue].Contains(performer))
              {
                  result[city][venue].Add(performer);
              }
              
            }
            var citiesByName = result.OrderBy(city => city.Key);
            foreach(var city in citiesByName)
            {
                var venuesByName = city.Value.OrderBy(vnue => vnue.Key);
                Console.WriteLine(city.Key);
                foreach (var venu in venuesByName)
                {
                    var performersByName=venu.Value.OrderBy(x=>x,StringComparer.InvariantCulture);
                    Console.WriteLine(string.Format("->{0}: {1}", venu.Key, string.Join(", ", performersByName)));
                }
            }
        }
    }
}
