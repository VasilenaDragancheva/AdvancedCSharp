using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TheNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex number = new Regex("([0-9]+)");
            string line = Console.ReadLine();
            Match num = number.Match(line);
            
                while(num.Success)
                {
                    int nummmm = int.Parse(num.ToString());

                    num=num.NextMatch();
                }
               

        }
    }
}
