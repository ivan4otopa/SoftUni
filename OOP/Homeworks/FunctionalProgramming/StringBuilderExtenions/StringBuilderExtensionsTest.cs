using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringBuilderExtenions.Extrensions;

namespace StringBuilderExtenions
{
    class StringBuilderExtensionsTest
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string hi = "high";
            stringBuilder.Append(hi);
            string substringedString = stringBuilder.Substring(0, 3);
            Console.WriteLine("Before substring: {0}\nAfter substring: {1}", stringBuilder, substringedString);
            Console.WriteLine();

            string removeString = "GH";
            Console.WriteLine("String to remove from: {0}\nPart to be removed: {1}", stringBuilder, removeString);
            stringBuilder.RemoveText(removeString);
            Console.WriteLine("After removing: {0}", stringBuilder);

            stringBuilder = new StringBuilder();
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);

            stringBuilder.AppendAll(numbers);
            Console.WriteLine(stringBuilder);
        }
    }
}
