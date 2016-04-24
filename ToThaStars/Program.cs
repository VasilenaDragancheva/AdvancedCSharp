using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToThaStars
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> stars = new Dictionary<string, double[]>();
            for (int i = 0; i < 3; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
               string name=data[0].ToLower();
                double xStar=double.Parse(data[1]);
                double yStar=double.Parse(data[2]);
                stars.Add(name, new double[] { xStar, yStar });
            }

            double[] ourPosition = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double x=ourPosition[0];
            double y=ourPosition[1];
            int moves = int.Parse(Console.ReadLine());
            for (int i = 0; i <= moves;i++)
            {
                bool isInSpace = true;
                foreach(var star in stars)
                {
                    double xStart=star.Value[0]-1;
                    double xEnd = star.Value[0] + 1;
                    double yEnd = star.Value[1] + 1;
                    double yStart = star.Value[1] - 1;
                    if (x >= xStart && x <= xEnd && y >= yStart && y <= yEnd)
                    {
                        isInSpace = false;
                        Console.WriteLine(star.Key);
                    }
                }
                if (isInSpace)
                {
                    Console.WriteLine("space");
                }
                y++;
            }
        }
    }
}
