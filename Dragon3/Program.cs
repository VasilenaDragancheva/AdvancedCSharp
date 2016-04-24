using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Dragon3
    //swtiched with hyperlinks

{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"<a\b[^>]*\bhref\s*=\s*([^\s]+)[^>]*>";
        }
    }
}
