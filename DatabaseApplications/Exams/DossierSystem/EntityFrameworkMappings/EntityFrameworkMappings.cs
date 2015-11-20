namespace EntityFrameworkMappings
{
    using System;
    using System.Linq;

    class EntityFrameworkMappings
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var photographs = context.Photographs
                .Select(p => new
                {
                    p.Title,
                    p.Link
                });

            foreach (var photograph in photographs)
            {
                Console.WriteLine("{0} -- {1}", photograph.Title, photograph.Link);
            }
        }
    }
}
