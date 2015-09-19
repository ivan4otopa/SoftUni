using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgeAfter10Years
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            Console.WriteLine("Enter your birthday: ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());
            if (today.Month > birthDay.Month)
            {
                Console.WriteLine("You are " + (today.Year - birthDay.Year) + " years old");
                Console.WriteLine("In 10 years you will be " + ((today.Year - birthDay.Year) + 10) + " years old");
            }
            else if (today.Month < birthDay.Month)
            {
                Console.WriteLine("You are " + ((today.Year - birthDay.Year) - 1) + " years old");
                Console.WriteLine("In 10 years you will be " + ((today.Year - birthDay.Year) + 9) + " years old");
            }
            else if ((today.Month == birthDay.Month) && (today.Day < birthDay.Day))
            {
                Console.WriteLine("You are " + ((today.Year - birthDay.Year) - 1) + " years old");
                Console.WriteLine("In 10 years you will be " + ((today.Year - birthDay.Year) + 9) + " years old");
            }
            else if ((today.Month == birthDay.Month) && (today.Day > birthDay.Day))
            {
                Console.WriteLine("You are " + (today.Year - birthDay.Year) + " years old");
                Console.WriteLine("In 10 years you will be " + ((today.Year - birthDay.Year) + 10) + " years old");
            }
            else if ((today.Month == birthDay.Month) && (today.Day == birthDay.Day))
            {
                Console.WriteLine("You are " + (today.Year - birthDay.Year) + " years old");
                Console.WriteLine("In 10 years you will be " + ((today.Year - birthDay.Year) + 10) + " years old");
            }
        }
    }
}
