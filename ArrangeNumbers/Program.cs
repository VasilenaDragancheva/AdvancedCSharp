namespace ArrangeNumbers
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var customObjects = new List<IntegerToString>();
            foreach (var s in input)
            {
                customObjects.Add(new IntegerToString(s));
            }

            customObjects.Sort();
            var output = new List<string>();

            foreach (var integerToString in customObjects)
            {
                output.Add(integerToString.ToString());
            }

            Console.WriteLine(string.Join(", ", output));
        }

        public class IntegerToString : IComparable<IntegerToString>
        {
            private readonly Dictionary<int, int> intgeresOrdered = new Dictionary<int, int>
                                                                        {
                                                                            { 8, 0 }, 
                                                                            { 5, 1 }, 
                                                                            { 4, 2 }, 
                                                                            { 9, 3 }, 
                                                                            { 1, 4 }, 
                                                                            { 7, 5 }, 
                                                                            { 6, 6 }, 
                                                                            { 3, 7 }, 
                                                                            { 2, 8 }, 
                                                                            { 0, 9 }
                                                                        };

            public IntegerToString(string numberInput)
            {
                this.Number = numberInput;
            }

            public string Number { get; private set; }

            public int CompareTo(IntegerToString other)
            {
                var minLength = Math.Min(this.Number.Length, other.Number.Length);
                for (int i = 0; i < minLength; i++)
                {
                    var numberThis = int.Parse(this.Number[i].ToString());
                    var numberOther = int.Parse(other.Number[i].ToString());
                    var keyThis = this.intgeresOrdered[numberThis];
                    var keyOther = this.intgeresOrdered[numberOther];
                    if (keyThis < keyOther)
                    {
                        return -1;
                    }

                    if (keyThis > keyOther)
                    {
                        return 1;
                    }
                }

                if (this.Number.Length < other.Number.Length)
                {
                    return -1;
                }

                if (this.Number.Length > other.Number.Length)
                {
                    return 1;
                }

                return 0;
            }

            public override string ToString()
            {
                return this.Number;
            }
        }
    }
}