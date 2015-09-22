using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintTheASCIITable
{
    class PrintTheASCIITable
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("ASCII Table");
            for (int i = 0; i < 256; i++)
            {
                char ascii = (char)i;
                Console.WriteLine(ascii);
            }
        }
    }
}
