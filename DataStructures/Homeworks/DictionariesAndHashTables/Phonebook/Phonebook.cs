namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Phonebook
    {
        static void Main()
        {
            var phonebook = new Dictionary.Dictionary<string, string>();
            string line = Console.ReadLine();
            string name = string.Empty;
            string number = string.Empty;
            List<string> names = new List<string>();

            while (line != "search")
            {
                string[] parts = line.Split('-');

                name = parts[0];
                number = parts[1];
                phonebook.Add(name, number);
                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (!String.IsNullOrEmpty(line))
            {
                names.Add(line);
                line = Console.ReadLine();
            }

            foreach (var personName in names)
            {
                if (phonebook.ContainsKey(personName))
                {
                    Console.WriteLine("{0} -> {1}", personName, phonebook[personName]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", personName);
                }
            }
        }
    }
}
