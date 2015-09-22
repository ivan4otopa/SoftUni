using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05SortingNumbers
{
    class SortingNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            List<int> sort = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                sort.Add(a);
            }
            sort.Sort();
            foreach (var b in sort)
                Console.WriteLine(b);
        }
    }
}
