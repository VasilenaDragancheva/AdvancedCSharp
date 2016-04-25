namespace TheNumbers
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            Regex number = new Regex("([0-9]+)");
            string line = Console.ReadLine();
            Match num = number.Match(line);

            while (num.Success)
            {
                int nummmm = int.Parse(num.ToString());

                num = num.NextMatch();
            }
        }
    }
}