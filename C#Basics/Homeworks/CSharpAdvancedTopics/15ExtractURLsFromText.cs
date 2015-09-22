using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15ExtractURLsFromText
{
    class ExtractURLsFromText
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string[] text = Console.ReadLine().Split(' ');
            List<string> URLs = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Length > 6)
                {
                    if (text[i].Substring(0, 7) == "http://" || text[i].Substring(0, 4) == "www.")
                        URLs.Add(text[i]);
                }
            }
            foreach (var URL in URLs)
                Console.WriteLine(URL);
            Console.WriteLine();
        }
    }
}
