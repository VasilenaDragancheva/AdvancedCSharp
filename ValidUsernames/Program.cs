using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            Regex validUsername = new Regex(@"^[a-zA-Z]\w{2,24}$");
           List<string> valid = usernames.Where(name => validUsername.IsMatch(name)).ToList();
           foreach (string name in valid)
           {
               Console.WriteLine(name);
           }
        }
    }
}
