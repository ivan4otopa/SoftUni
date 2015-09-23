namespace ConcurrentDatabaseChanges
{
    using System.Linq;

    class ConcurrentDatabaseChanges
    {
        static void Main(string[] args)
        {
            var contextOne = new SoftUniEntities();
            var contextTwo = new SoftUniEntities();
            var employee = contextOne.Employees
                .Where(e => e.EmployeeID == 1)
                .FirstOrDefault();
            var sameEmployee = contextTwo.Employees
                .Where(e => e.EmployeeID == 1)
                .FirstOrDefault();

            employee.FirstName = "Haralampi";
            sameEmployee.FirstName = "Unufri";

            contextOne.SaveChanges();
            contextTwo.SaveChanges();
        }
    }
}
