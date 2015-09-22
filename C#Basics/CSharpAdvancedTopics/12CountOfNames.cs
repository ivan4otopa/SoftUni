using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12CountOfNames
{
    class CountOfNames
    {
        static void Main(string[] args)
        {
            Console.Write("Enter names: ");
            string[] nameSequence = Console.ReadLine().Split(' ');
            Array.Sort(nameSequence);
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < nameSequence.Length; i++)
                names.Add(nameSequence[i]);
            int count = 0;
            foreach (var name in names)
            {
                for (int i = 0; i < nameSequence.Length; i++)
                {
                    if (name == nameSequence[i])
                        count++;
                }
                Console.WriteLine(name + " -> " + count);
                count = 0;
            }
            Console.WriteLine();
        }
    }
}
