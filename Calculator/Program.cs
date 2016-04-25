namespace Calculator
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string maxValue = int.MaxValue.ToString();
            string minValue = int.MinValue.ToString();
            char zero = '0';
            bool notValidInt = false;
            if (string.IsNullOrEmpty(number))
            {
                notValidInt = true;
                Console.WriteLine("FormatException");
            }
            else if ((number.Length > maxValue.Length && char.IsDigit(number[0]))
                     || (number.Length > minValue.Length && number[0] == '-'))
            {
                notValidInt = true;
                Console.WriteLine("OverflowException");
            }
            else if ((number.Length == maxValue.Length && char.IsDigit(number[0]))
                     || (number.Length == minValue.Length && number[0] == '-'))
            {
                int start = number[0] == '-' ? 1 : 0;
                List<int> differences = new List<int>();
                for (int i = start; i < number.Length; i++)
                {
                    int diff = 0;
                    if (start == 0)
                    {
                        diff = maxValue[i] - number[i];
                    }
                    else
                    {
                        diff = minValue[i] - number[i];
                    }

                    if (diff > 0)
                    {
                    }

                    differences.Add(diff);
                }
            }
            {
            }
        }

        static void AnalyzeDiff(List<int> differences)
        {
        }
    }
}