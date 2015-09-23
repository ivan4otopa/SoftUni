namespace CallAStoredProcedure
{
    using System;

    class CallAStoredProcedure
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();

            var projectsByEmployeeName = context.usp_FindAllProjectsForEmployeeName("Roberto", "Tamburello");

            foreach (var project in projectsByEmployeeName)
            {
                Console.WriteLine("{0}, {1} - {2}", project.Name, project.Description, project.StartDate);
            }
        }
    }
}
