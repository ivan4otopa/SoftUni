using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Customer.Classes;
using Customer.Enumerations;

namespace Customer
{
    class CustomerTest
    {
        static void Main(string[] args)
        {
            //Tst ToString()
            IList<Payment> payments = new List<Payment>()
            {
                new Payment("FIFA", 59.99m),
                new Payment("TV", 399.59m),
                new Payment("Laptop", 999.99m),
            };

            Customer.Classes.Customer customerOne = new Customer.Classes.Customer("Shasho", "Minigorov", "Shashev", 234156732, "Govedo st.",
                "0888253746", "Shashkata@abv.bg", payments, CustomerType.Diamond);

            Console.WriteLine(customerOne);

            Console.WriteLine();

            //Test Equals()
            Customer.Classes.Customer customerTwo = new Customer.Classes.Customer("Shasho", "Minigorov", "Shashev", 234156732, "Govedo st.",
                "0888253746", "Shashkata@abv.bg", payments, CustomerType.Diamond);

            bool isEqual = customerOne.Equals(customerTwo);

            Console.WriteLine(isEqual);

            Console.WriteLine();

            //Test == and !=
            Console.WriteLine(customerOne == customerTwo);
            Console.WriteLine(customerOne != customerTwo);

            Console.WriteLine();

            //Make clone
            object clone = customerOne.Clone();

            Console.WriteLine(clone);

            Console.WriteLine();

            //Test CompareTo()
            Console.WriteLine(customerOne.CompareTo(customerTwo));
        }
    }
}
