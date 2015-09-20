using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullValuesArithmetic
{
    class NullValuesArithmetic
    {
        static void Main(string[] args)
        {
            int? a = null;
            double? b = null;
            Console.WriteLine(a);
            Console.WriteLine(b);
            a += 1;
            b += 1;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
