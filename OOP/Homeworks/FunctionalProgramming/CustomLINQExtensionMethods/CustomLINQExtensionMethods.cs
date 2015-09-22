using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomLINQExtensionMethods.Extensions;

namespace CustomLINQExtensionMethods
{
    class CustomLINQExtensionMethods
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);

            var numbersBiggerThanTwo = numbers.WhereNot(n => n <= 2).Select(n => n);
            Console.WriteLine("Numbers that are bigger than 2:");
            foreach (var number in numbersBiggerThanTwo)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            var repeatNumbers = numbers.Repeat(3);
            Console.WriteLine("Repeat the collection:");
            foreach (var number in repeatNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            string[] names = { "Petkan", "Dragan", "Mauricio", "Miladina" };
            string[] suffixes = { "n", "a" };

            var filteredNames = names.WhereEndsWith<string>(suffixes);
            Console.WriteLine("Names that end with 'n' or 'a': ");
            foreach (var name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
