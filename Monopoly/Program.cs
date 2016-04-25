namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int hotels;

        private static decimal money = 50m;

        private static int turns;

        public static void Main(string[] args)
        {
            int[] dimensions =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            List<string> gameField = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                gameField.Add(Console.ReadLine());
            }

            for (int r = 0; r < rows; r++)
            {
                if (r % 2 == 0)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        var result = FindResult(gameField, r, c);

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            Console.WriteLine(result);
                        }
                    }
                }
                else
                {
                    for (int c = cols - 1; c >= 0; c--)
                    {
                        var result = FindResult(gameField, r, c);

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            Console.WriteLine(result);
                        }
                    }
                }
            }

            Console.WriteLine("Turns {0}", turns);
            Console.WriteLine("Money {0}", money);
        }

        private static string FindResult(List<string> gameField, int r, int c)
        {
            char gameObject = gameField[r][c];
            string result;
            switch (gameObject)
            {
                case 'J':
                    result = string.Format("Gone to jail at turn {0}.", turns);
                    turns += 3;
                    money += 3 * hotels * 10;
                    break;

                case 'H':
                    hotels++;
                    result = string.Format("Bought a hotel for {0}. Total hotels: {1}.", money, hotels);
                    money = 0;
                    money += hotels * 10;
                    turns++;
                    break;
                case 'S':
                    var productPrice = (r + 1) * (c + 1);
                    var moneySpent = productPrice <= money ? productPrice : money;
                    result = string.Format("Spent {0} money at the shop.", moneySpent);
                    money -= moneySpent;
                    money += hotels * 10;
                    turns++;
                    break;
                default:
                    turns++;
                    money += hotels * 10;
                    result = string.Empty;
                    break;
            }

            return result;
        }
    }
}