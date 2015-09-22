using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class CompanyHierarchiTest
    {
        static void Main()
        {
            Sale saleOne = new Sale("Karburator", new DateTime(1998, 05, 15), 212.00m);
            Sale saleTwo = new Sale("Telefon", new DateTime(2012, 11, 02), 999.99m);
            List<Sale> salesOne = new List<Sale>();
            salesOne.Add(saleOne);
            salesOne.Add(saleTwo);
            Sale saleThree = new Sale("Klimatik", new DateTime(2007, 05, 20), 1999.99m);
            Sale saleFour = new Sale("Futbolna topka", new DateTime(2014, 06, 15), 22.00m);
            List<Sale> salesTwo = new List<Sale>();
            salesTwo.Add(saleThree);
            salesTwo.Add(saleFour);
            RegularEmployee regularEmployeeOne = new SalesEmployee(1, "Kiro", "Blagoev", 500.35m, "Accounting", salesOne);
            RegularEmployee regularEmployeeTwo = new SalesEmployee(2, "Dechko", "Bagdatiev", 573.22m, "Marketing", salesTwo);
            List<Employee> employeesOne = new List<Employee>();
            employeesOne.Add(regularEmployeeOne);
            employeesOne.Add(regularEmployeeTwo);
            Manager managerOne = new Manager(1, "Vilislava", "Karamartinova", 650.50m, "Marketing", employeesOne);
            Project projectOne = new Project("FIFA", new DateTime(1995, 05, 21), "Footbal Game", State.Open);
            Project projectTwo = new Project("League Of Legends", new DateTime(2008, 09, 13), "Multiplayer Game", State.Closed);
            List<Project> projectsOne = new List<Project>();
            projectsOne.Add(projectOne);
            projectsOne.Add(projectTwo);
            Project projectThree = new Project("Chess", new DateTime(222, 12, 14), "Board Game", State.Closed);
            Project projectFour = new Project("Belot", new DateTime(1312, 09, 04), "Card Game", State.Open);
            List<Project> projectsTwo = new List<Project>();
            projectsTwo.Add(projectThree);
            projectsTwo.Add(projectFour);
            RegularEmployee regularEmployeeThree = new Developer(3, "Ioncho", "Draskov", 1500.00m, "Production", projectsOne);
            RegularEmployee regularEmployeeFour = new Developer(4, "Dobri", "Mileshkov", 1300.00m, "Production", projectsTwo);
            List<Employee> employeesTwo = new List<Employee>();
            employeesTwo.Add(regularEmployeeThree);
            employeesTwo.Add(regularEmployeeFour);
            Manager managerTwo = new Manager(2, "Ioana", "Velikova", 505.03m, "Production", employeesTwo);
            List<Person> people = new List<Person>();
            people.Add(regularEmployeeOne);
            people.Add(regularEmployeeTwo);
            people.Add(regularEmployeeThree);
            people.Add(regularEmployeeFour);
            people.Add(managerOne);
            people.Add(managerTwo);
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
