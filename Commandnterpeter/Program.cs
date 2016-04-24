using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandnterpeter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            array = array.Reverse().ToArray();
          //RevesreMatric(array);
            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }
        public static void RevesreMatric(int[] arr)
        {
            for (int r = 0; r < arr.Length; r++)
            {
                arr[r]++;
            }
        }
    }
}
