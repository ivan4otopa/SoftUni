using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintCompanyInformation
{
    class PrintCompanyInformation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter information about a company and its' manager: ");
            Console.Write("Company name: ");
            string companyName = Console.ReadLine();
            Console.Write("Company adress: ");
            string companyAdress = Console.ReadLine();
            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Fax number: ");
            string faxNumber = Console.ReadLine();
            string noFax = String.IsNullOrEmpty(faxNumber) ? "(no fax)" : faxNumber;
            Console.Write("Web site: ");
            string webSite = Console.ReadLine();
            Console.Write("Manager first name: ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Manager last name: ");
            string managerLastName = Console.ReadLine();
            Console.Write("Manager age: ");
            int managerAge = int.Parse(Console.ReadLine());
            Console.Write("Manager phone: ");
            string managerPhone = Console.ReadLine();
            Console.WriteLine("{0} \nAdress: {1} \nTel. +{2} \nFax: {3} \nWebSite: {4} \nManager: {5} {6} (age: {7}, tel. +{8})", companyName,
                companyAdress, phoneNumber, noFax, webSite, managerFirstName, managerLastName, managerAge, managerPhone);
        }
    }
}
