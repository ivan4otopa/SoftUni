using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExchangeVariableValues
{
    class ExchangeVariableValues
    {
        static void Main(string[] args)
        {
            sbyte a = 5;
            sbyte b = 10;
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            sbyte t;
            t = a;
            a = b;
            b = t;
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
        }
    }
}
