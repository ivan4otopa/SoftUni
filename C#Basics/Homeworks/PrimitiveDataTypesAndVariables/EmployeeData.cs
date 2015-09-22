using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeData
{
    class EmployeeData
    {
        static void Main(string[] args)
        {
            string firstName = "Ivan";
            string lastName = "Garnizov";
            sbyte age = 19;
            char gender = 'm';
            long personalIDNumber = 8306112507;
            int UniqueEmplyeeNumber = 27560000;
            Console.WriteLine("Name: {0} {1}, Age: {2}, Gender: {3}, Personal ID Number: {4}, Unique Employee Number: {5}", firstName,
                lastName, age, gender, personalIDNumber, UniqueEmplyeeNumber);
        }
    }
}
