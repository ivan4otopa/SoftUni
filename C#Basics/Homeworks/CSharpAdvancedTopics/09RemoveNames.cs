using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09RemoveNames
{
    class RemoveNames
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            string[] firstNames = Console.ReadLine().Split(' ');
            string[] secondNames = Console.ReadLine().Split(' ');
            for (int i = 0; i < firstNames.Length; i++)
            {
                names.Add(firstNames[i]);
                for (int j = 0; j < secondNames.Length; j++)
                {
                    if (firstNames[i] == secondNames[j])
                        names.Remove(firstNames[i]);
                }
            }
            foreach (var name in names)
                Console.Write(name + " ");
            Console.WriteLine();
        }
    }
}
