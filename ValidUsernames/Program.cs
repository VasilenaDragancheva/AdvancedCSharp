namespace ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            Regex validUsername = new Regex(@"^[a-zA-Z]\w{2,24}$");
            List<string> valid = usernames.Where(name => validUsername.IsMatch(name)).ToList();
            foreach (string name in valid)
            {
                Console.WriteLine(name);
            }
        }
    }
}