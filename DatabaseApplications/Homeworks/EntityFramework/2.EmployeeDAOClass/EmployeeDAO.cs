namespace EmployeeDAOClass
{
    using System;
    using System.Data.Entity;

    public static class EmployeeDAO
    {
        public static void Add(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public static Employee FindByKey(object key)
        {
            Employee employee = null;

            using (var context = new SoftUniEntities())
            {
                employee = context.Employees.Find(key);
            }

            return employee;
        }

        public static void Modify(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                Console.Write("What column from the employee table would you wish to update (FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID:");

                string updateChoice = Console.ReadLine();
                string updateParameter = Console.ReadLine();

                switch (updateChoice.ToLower())
                {
                    case "firstname":
                        employee.FirstName = updateParameter;
                        break;
                    case "lastname":
                        employee.LastName = updateParameter;
                        break;
                    case "middlename":
                        employee.MiddleName = updateParameter;
                        break;
                    case "jobtitle":
                        employee.JobTitle = updateParameter;
                        break;
                    case "departmentid":
                        employee.DepartmentID = int.Parse(updateParameter);
                        break;
                    case "managerid":
                        employee.ManagerID = int.Parse(updateParameter);
                        break;
                    case "hiredate":
                        employee.HireDate = DateTime.Parse(updateParameter);
                        break;
                    case "salary":
                        employee.Salary = decimal.Parse(updateParameter);
                        break;
                    case "adressid":
                        employee.AddressID = int.Parse(updateParameter);
                        break;
                    default:
                        Console.WriteLine("Invalid column: {0}", updateChoice);
                        break;
                }

                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(Employee employee)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Attach(employee);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}
