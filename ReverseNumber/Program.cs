﻿namespace ReverseNumber
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int reversed = 0;

            while (number > 0)
            {
                int n = number % 10;
                reversed *= 10;
                reversed += n;
                number /= 10;
            }

            Console.WriteLine(reversed);
        }
    }
}