using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager
{
    class Program
    {
        static void Main(string[] args)
        {
           System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Dictionary<string, Dictionary<string, double>> result = new Dictionary<string, Dictionary<string, double>>();
            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line.ToLower() == "end")
                {
                    break;
                }
                string[] data = line.Split(' ');
                string filename = data[0];
                string format = data[1];
                double size = double.Parse(data[2].Substring(0, data[2].Length - 2));
                if (!result.ContainsKey(format))
                {
                    result.Add(format, new Dictionary<string, double>());
                }
                result[format].Add(filename, size);


            }
            var sortedByTotalSize = result.OrderBy(ext => ext.Value.Values.Sum());
            foreach(var type in sortedByTotalSize)
            {
                Console.WriteLine("+++"+type.Key+"+++");
                var sortedFilesBySize = type.Value.OrderBy(file => file.Value);
                foreach(var file in sortedFilesBySize)
                {
                    Console.WriteLine("->"+file.Key+" "+file.Value);
                }
                
            }
        }
    }
}
