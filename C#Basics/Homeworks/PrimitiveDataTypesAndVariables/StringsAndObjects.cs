using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringsAndObjects
{
    class StringsAndObjects
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";
            object concatenated = hello + " " + world;
            string helloWorld = (string)concatenated;
        }
    }
}
