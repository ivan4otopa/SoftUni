using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComparingFloats
{
    class ComparingFloats
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double number1 = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double subtract = number1 - number;
            bool equal = subtract < eps;
            if (subtract < eps)
                Console.WriteLine("{0} = {1}: {2}", number, number1, equal);
            else if(subtract < 0 || subtract >= eps)
                Console.WriteLine("{0} = {1}: {2}", number, number1, equal);
        }
    }
}
