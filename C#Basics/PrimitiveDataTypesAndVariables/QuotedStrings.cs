using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuotedStrings
{
    class QuotedStrings
    {
        static void Main(string[] args)
        {
            string quotedString = "The \"use\" of quotations causes difficulties";
            string unquotedString = @"The ""use"" of quotations causes difficulties";
            Console.WriteLine(quotedString);
            Console.WriteLine(unquotedString);
        }
    }
}
`