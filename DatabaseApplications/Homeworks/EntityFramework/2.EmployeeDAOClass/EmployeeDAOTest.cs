namespace EmployeeDAOClass
{
    using System;
    using System.Linq;

    class EmployeeDAOTest
    {
        static void Main(string[] args)
        {
            //var employee = new Employee()
            //{
            //    FirstName = "a",
            //    LastName = "b",
            //    MiddleName = "c",
            //    JobTitle = "d",
            //    DepartmentID = 1,
            //    ManagerID = null,
            //    HireDate = DateTime.Now,
            //    Salary = 32455,
            //    AddressID = null
            //};

            //EmployeeDAO.Add(employee);

            //var foundEmployee = EmployeeDAO.FindByKey(294);

            //Console.WriteLine(foundEmployee.FirstName);

            //EmployeeDAO.Modify(foundEmployee);

            //var sameFoundEmployee = EmployeeDAO.FindByKey(294);

            //Console.WriteLine(sameFoundEmployee.FirstName);

            var foundEmployee = EmployeeDAO.FindByKey(294);

            EmployeeDAO.Delete(foundEmployee);
        }
    }
}
