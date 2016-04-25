namespace Commandnterpeter
{
    using System;
    using System.Linq;

    class Program
    {
        public static void RevesreMatric(int[] arr)
        {
            for (int r = 0; r < arr.Length; r++)
            {
                arr[r]++;
            }
        }

        static void Main(string[] args)
        {
            int[] array =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            array = array.Reverse().ToArray();

            // RevesreMatric(array);
            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }
    }
}