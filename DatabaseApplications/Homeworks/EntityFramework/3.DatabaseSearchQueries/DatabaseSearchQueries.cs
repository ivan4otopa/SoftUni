namespace DatabaseSearchQueries
{
    using System;
    using System.Linq;

    class DatabaseSearchQueries
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            //var employees = context.Employees
            //    .Where(e => e.Projects.Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
            //    .Select(e => new
            //    {
            //        EmployeeName = e.FirstName + " " + e.LastName,
            //        ManagerName = e.Employee1.FirstName + " " + e.Employee1.LastName,
            //        EmployeeProjects = e.Projects.Select(p => new
            //        {
            //            p.Name,
            //            p.StartDate,
            //            p.EndDate
            //        })
            //    });

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("Employee Name: {0}\nParticipates In Projects:", employee.EmployeeName);

            //    foreach (var project in employee.EmployeeProjects)
            //    {
            //        Console.WriteLine("Project Name: {0}\nProject Start Date: {1}\nProject End Date: {2}", project.Name, project.StartDate,
            //            project.EndDate);
            //    }

            //    Console.WriteLine("With Manager: {0}\n{1}", employee.ManagerName, new string('-', 30));
            //}

            //var addresses = context.Addresses
            //    .OrderByDescending(a => a.Employees.Count)
            //    .ThenBy(a => a.Town.Name)
            //    .Select(a => new
            //    {
            //        Address = a.AddressText,
            //        Town = a.Town.Name,
            //        EmployeeCount = a.Employees.Count
            //    })
            //    .Take(10);

            //foreach (var address in addresses)
            //{
            //    Console.WriteLine("{0}, {1} - {2}", address.Address, address.Town, address.EmployeeCount);
            //}

            //var employee = context.Employees
            //    .Where(e => e.EmployeeID == 147)
            //    .Select(e => new
            //    {
            //        EmployeeName = e.FirstName + " " + e.LastName,
            //        e.JobTitle,
            //        Projects = e.Projects.Select(p => new
            //        {
            //            p.Name
            //        }).OrderBy(p => p.Name)
            //    }).FirstOrDefault();

            //Console.WriteLine("Employee Name: {0}\nJob Title: {1}\nProjects:", employee.EmployeeName, employee.JobTitle);

            //foreach (var project in employee.Projects)
            //{
            //    Console.WriteLine(project.Name);
            //}

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = d.Employee.FirstName + " " + d.Employee.LastName,
                    Employees = d.Employees.Select(e => new 
                    {
                        e.FirstName,
                        e.LastName,
                        e.HireDate,
                        e.JobTitle
                    })
                }).ToList();

            Console.WriteLine(departments.Count);

            foreach (var department in departments)
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}", department.DepartmentName, department.ManagerName, 
                    department.Employees.Count());
            }
        }
    }
}
