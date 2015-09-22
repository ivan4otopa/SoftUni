using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringDisperser.Classes;

namespace StringDisperser
{
    class StringDisperserTest
    {
        static void Main(string[] args)
        {
            StringDisperser.Classes.StringDisperser stringDisperser = new StringDisperser.Classes.StringDisperser("gosho", "pesho", "tanio");
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();
        }
    }
}
