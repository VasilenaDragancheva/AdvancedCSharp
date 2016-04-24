namespace MerlahShake
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string pattern = Console.ReadLine();

            int first = line.IndexOf(pattern);
            int last = line.LastIndexOf(pattern);

            while ((first >= 0 && last > first) && pattern.Length > 0)
            {
                Console.WriteLine("Shaked it.");
                int middlePartIndex = first + pattern.Length;
                int middlePartLenght = last - middlePartIndex;
                line = line.Substring(0, first - 0) + line.Substring(middlePartIndex, middlePartLenght)
                       + line.Substring(last + pattern.Length);

                pattern = pattern.Remove(pattern.Length / 2, 1);
                first = line.IndexOf(pattern);
                last = line.LastIndexOf(pattern);
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(line);
        }
    }
}