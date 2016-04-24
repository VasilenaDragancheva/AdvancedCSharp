using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex whiteSpace = new Regex(@"(\+|%20)");
            Regex multiWS=new Regex(@"\s{2,}");
            string line;
            while(true)
            {
                   line = Console.ReadLine();
                 if (line.Contains('?'))
                {
                   char[] query=line.ToCharArray().Skip(Array.IndexOf(line.ToCharArray(), '?')+1).ToArray();
                   line = new string(query);
                }
             
                if(line.ToLower()=="end")
                {
                    break;
                }
                line = whiteSpace.Replace(line, " ");
                line = line.Trim();
                line = multiWS.Replace(line, " ");
                
                string[] data = line.Split('&');
                Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
                foreach (string field in data)
                {
                    string fieldName = field.Split('=')[0].Trim();
                    string fieldValue = field.Split('=')[1].Trim();
                    if (!result.ContainsKey(fieldName))
                    {
                        result.Add(fieldName, new List<string>());
                    }
                    result[fieldName].Add(fieldValue);
                }
                foreach (var field in result)
                {
                    Console.Write("{0}=[{1}]",field.Key,string.Join(", ",field.Value));
                }
                Console.WriteLine();
            }
                
        }
    }
}
