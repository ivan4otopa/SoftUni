using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09PlayWithIntDoubleAndString
{
    class PlayWithIntDoubleAndString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, choose a type: \n1 --> int \n2 --> double \n3 --> string");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Please, enter an int: ");
                    int i = int.Parse(Console.ReadLine());
                    Console.WriteLine(i + 1);
                    break;
                case 2:
                    Console.Write("Please, enter a double: ");
                    double d = double.Parse(Console.ReadLine());
                    Console.WriteLine(d + 1);
                    break;
                case 3:
                    Console.Write("Please, enter a string: ");
                    string s = Console.ReadLine();
                    Console.WriteLine(s + "*");
                    break;
            }
        }
    }
}
