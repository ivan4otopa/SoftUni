using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04DifferenceBetweenDates
{
    class DifferenceBetweenDates
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two dates: ");
            Console.Write("Date 1: ");
            string date1 = Console.ReadLine();
            Console.Write("Date 2: ");
            string date2 = Console.ReadLine();
            DateTime a = DateTime.ParseExact(date1, "d.MM.yyyy", null);
            DateTime b = DateTime.ParseExact(date2, "d.MM.yyyy", null);
            Console.WriteLine((b - a).TotalDays);
        }
    }
}
