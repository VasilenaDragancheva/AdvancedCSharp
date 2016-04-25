namespace BadCat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> numbers = new HashSet<int>();
            List<string[]> locations = new List<string[]>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                locations.Add(input);
                int num1 = int.Parse(input[0]);
                int num2 = int.Parse(input[3]);
                numbers.Add(num1);
                numbers.Add(num2);
            }

            var arranged = new List<int>(numbers);

            arranged.Sort();

            if (arranged[0] == 0)
            {
                arranged.Remove(0);
                arranged.Insert(1, 0);
            }

            foreach (var location in locations)
            {
                int replaced = int.Parse(location[0]);
                string direction = location[2];
                int marked = int.Parse(location[3]);

                int indexReplaced = arranged.IndexOf(replaced);
                int indexMarked = arranged.IndexOf(marked);

                if ((indexReplaced > indexMarked && direction == "before")
                    || (indexReplaced < indexMarked && direction == "after"))
                {
                    arranged.Remove(replaced);
                    arranged.Insert(indexMarked, replaced);
                }
            }

            if (arranged[0] == 0)
            {
                var allAfter =
                    locations.Where(l => l[2] == "after").OrderBy(l => int.Parse(l[3])).Select(l => int.Parse(l[3]));
                var allBefore =
                    locations.Where(l => l[2] == "before").OrderBy(l => int.Parse(l[0])).Select(l => int.Parse(l[0]));

                int number = allAfter.FirstOrDefault(num => !allBefore.Contains(num));
                arranged.Remove(number);
                arranged.Insert(0, number);
            }

            Console.WriteLine(string.Join(string.Empty, arranged));
        }
    }
}