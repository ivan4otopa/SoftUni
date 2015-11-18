namespace EntityFrameworkMappings
{
    using System;
    using System.Linq;

    class EntityFrameworkMappings
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var characters = context.Characters
                .Select(c => c.Name);

            foreach (var characterName in characters)
            {
                Console.WriteLine(characterName);
            }
        }
    }
}
