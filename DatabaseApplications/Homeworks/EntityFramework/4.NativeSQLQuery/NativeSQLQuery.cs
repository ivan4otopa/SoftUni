namespace NativeSQLQuery
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    class NativeSQLQuery
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            var totalCount = context.Employees.Count();
            var sw = new Stopwatch();

            sw.Start();

            var employeesNativeSQL = context.Database.SqlQuery<string>("SELECT e.FirstName FROM Employees e " +
                                                              "JOIN EmployeesProjects ep " +
                                                              "ON e.EmployeeID = ep.EmployeeID " +
                                                              "JOIN Projects p " +
                                                              "ON ep.ProjectID = p.ProjectID " +
                                                              "WHERE YEAR(p.StartDate) = 2001");

            Console.WriteLine("Native: {0}", sw.Elapsed);
            sw.Restart();

            var employeesLINQ = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
                .Select(e => new
                {
                    e.FirstName
                });

            Console.WriteLine("Linq: {0}", sw.Elapsed);
        }
    }
}
