using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearingCommands

{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> directions = new List<char>()
                {
                    '>','<','v','^'
                };
            List<char[]> matrix = new List<char[]>();
            string line;
            while(true)
            {
                line=Console.ReadLine();
                if (line.ToLower() == "end")
                {
                    break;
                }
                matrix.Add(line.ToCharArray());
            }
            for(int r=0;r<matrix.Count;r++)
            {
                for(int c=0;c<matrix[r].Length;c++)
                {
                    if (directions.Contains(matrix[r][c]))
                    {
                        int nextR = r;
                        int nextC = c;
                        switch(matrix[r][c])
                        {
                            case '<':
                                nextC -= 1;
                               while(nextC>=0&&!directions.Contains(matrix[nextR][nextC]))
                               {
                                   
                                   matrix[nextR][nextC] = ' ';
                                   nextC--;
                               }
                               break;
                            case'>':
                               nextC += 1;
                               while (nextC <matrix[nextR].Length&& !directions.Contains(matrix[nextR][nextC]))
                               {
                                   
                                   matrix[nextR][nextC] = ' ';
                                   nextC++;
                               }
                               break;
                            case 'v':
                               nextR += 1;
                               while (nextR<matrix.Count &&!directions.Contains(matrix[nextR][nextC]))
                               {
                                   
                                   matrix[nextR][nextC] = ' ';
                                   nextR++;
                               }
                               break;
                            case '^':
                               nextR -= 1;
                               while (nextR >= 0 && !directions.Contains(matrix[nextR][nextC]))
                               {
                                   matrix[nextR][nextC] = ' ';
                                   nextR--;
                               }
                               break;
                        }
                    }

                }

            }
            for (int r = 0; r < matrix.Count; r++)
            {
                
                    Console.WriteLine("<p>"+System.Security.SecurityElement.Escape(new string(matrix[r]))+"</p>");
                
            }
        }
    }
}
