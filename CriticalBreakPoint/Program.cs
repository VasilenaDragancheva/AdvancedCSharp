namespace CriticalBreakPoint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<long[]> points = new List<long[]>();
            List<long> critialRatios = new List<long>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Break it.")
                {
                    break;
                }

                var point = line.Split(' ').Select(long.Parse).ToArray();

                var critialBreakPoint = Math.Abs((point[2] + point[3]) - (point[0] + point[1]));
                points.Add(point);
                critialRatios.Add(critialBreakPoint);
            }

            var uniqueValues = critialRatios.Distinct().ToArray();

            if ((uniqueValues.Count() == 1 && uniqueValues[0] != 0) || (uniqueValues.Count() == 2 && uniqueValues.Contains(0)))
            {
                var number = uniqueValues.FirstOrDefault(x => x != 0);
                var breakPoint = CalculateBreakPoint(number, points.Count);
                foreach (var longse in points)
                {
                    Console.WriteLine("Line: [{0}]", string.Join(", ", longse));
                }

                Console.WriteLine("Critical Breakpoint: {0}", breakPoint);
            }
            else
            {
                Console.WriteLine("Critical breakpoint does not exist.");
            }
        }

        private static BigInteger CalculateBreakPoint(long number, int count)
        {
            BigInteger start = BigInteger.Pow(number,count);
            

            BigInteger result;
            BigInteger.DivRem(start, count, out result);
            return result;
        }
    }
}