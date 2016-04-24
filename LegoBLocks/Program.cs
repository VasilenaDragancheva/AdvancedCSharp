using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBLocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int[][] block1 = new int[n][];
            int[][] block2 = new int[n][];
            List<int>[] result=new List<int>[n];
            bool fits = true;
            int totalCells=0;
            for (int i = 0; i < n; i++)
            {
                block1[i] = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                totalCells+=block1[i].Length;
                result[i] = new List<int>();
                result[i].AddRange(block1[i]);
            }
            for (int i = 0; i < n; i++)
            {
                block2[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                totalCells += block2[i].Length;
                Array.Reverse(block2[i]);
                result[i].InsertRange(block1[i].Length, block2[i]);
            }
            int length = result[0].Count();
            for (int r =1; r < n; r++)
            {
                if (result[r].Count != length)
                {
                    fits = false;
                    break;
                }
            }

            if (fits)
            {
                for(int i=0;i<n;i++)
                {
                    Console.WriteLine("["+string.Join(", ",result[i])+"]");
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}",totalCells);
            }

        }
    }
}
