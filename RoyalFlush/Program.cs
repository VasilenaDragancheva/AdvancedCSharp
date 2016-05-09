namespace RoyalFlush
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Card
    {
        public Card(string suit, string value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public string Suit { get; set; }

        public string Value { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var valueComparer = new Dictionary<string, int>();
            var allCards = new List<Card>();

            var suits = new Dictionary<string, string>
                            {
                                { "s", "Spades" }, 
                                { "h", "Hearts" }, 
                                { "c", "Clubs" }, 
                                { "d", "Diamonds" }
                            };

            for (int i = 2; i <= 10; i++)
            {
                valueComparer.Add(i.ToString(), i);
            }

            valueComparer.Add("J", 11);
            valueComparer.Add("Q", 12);
            valueComparer.Add("K", 13);
            valueComparer.Add("A", 14);
            var input = new StringBuilder();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input.Append(Console.ReadLine());
            }

            string line = input.ToString().Trim();
            var regex = new Regex(@"([0-9]{1,2}|[JQKA])(s|d|c|h)");
            MatchCollection matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                allCards.Add(new Card(match.Groups[2].ToString(), match.Groups[1].ToString()));
            }

            int counter = 0;
            for (int i = 0; i < allCards.Count; i++)
            {
                var currentCard = allCards[i];

                if (currentCard.Value == "10")
                {
                    var flush = new Stack<Card>();
                    flush.Push(currentCard);

                    for (int j = i + 1; j < allCards.Count; j++)
                    {
                        var lastCard = flush.Peek();
                        var nextCard = allCards[j];
                        if (lastCard.Suit == nextCard.Suit)
                        {
                            var difference = valueComparer[nextCard.Value] - valueComparer[lastCard.Value];
                            if (difference == 1)
                            {
                                flush.Push(nextCard);
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (flush.Count == 5)
                        {
                            Console.WriteLine("Royal Flush Found – {0}", suits[currentCard.Suit]);
                            counter++;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Royal’s Royal Flushes – {0}", counter);
        }
    }
}