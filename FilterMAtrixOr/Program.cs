namespace FilterMAtrixOr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = new List<string>();
            var inputToRemove = new List<bool>();
            var stringsPerRow = new List<int>();
            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                var nums = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                input.AddRange(nums);
                stringsPerRow.Add(nums.Length);
                inputToRemove.AddRange(new bool[nums.Length]);
            }

            int equalsCount = int.Parse(input[input.Count - 1]);

            for (int i = 0; i < input.Count - equalsCount - 1; i++)
            {
                int uniques = input.Skip(i).Take(equalsCount).Distinct().Count();
                if (uniques == 1)
                {
                    for (int k = i; k < i + equalsCount; k++)
                    {
                        inputToRemove[k] = true;
                    }
                    i += equalsCount - 1;
                }
            }

            int passedElements = 0;
            for (int i = 0; i < stringsPerRow.Count - 1; i++)
            {
                var numbersOnRow = new List<string>();
                for (int j = passedElements; j < passedElements + stringsPerRow[i]; j++)
                {
                    if (!inputToRemove[j])
                    {
                        numbersOnRow.Add(input[j]);
                    }
                }
                Console.WriteLine(numbersOnRow.Count > 0 ?
                    string.Join(" ", numbersOnRow) : "(empty");
                passedElements += stringsPerRow[i];
            }
        }
    }
}