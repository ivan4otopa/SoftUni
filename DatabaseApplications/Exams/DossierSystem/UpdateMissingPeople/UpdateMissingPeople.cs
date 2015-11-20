namespace UpdateMissingPeople
{
    using System.Linq;

    using DossierSystem.Data;
    using DossierSystem.Models;

    class UpdateMissingPeople
    {
        static void Main()
        {
            var context = new DossierSystemContext();
            var individuals = context.Individuals
                .Where(i => !i.Locations
                    .Any(l => l.LastSeen.Year >= 2010) && i.Status == Status.Active);

            foreach (var individual in individuals)
            {
                individual.Status = Status.Missing;
            }

            context.SaveChanges();
        }
    }
}
