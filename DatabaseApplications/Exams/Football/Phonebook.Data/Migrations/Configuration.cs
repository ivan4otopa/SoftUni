namespace Phonebook.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Phonebook.Data.PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Phonebook.Data.PhonebookContext";
        }

        protected override void Seed(Phonebook.Data.PhonebookContext context)
        {
            if (context.Contacts.Any())
            {
                return;
            }

            context.Contacts.Add(new Contact()
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Smart Ideas",
                Site = "http://blog.peter.com",
                Notes = "Friend from school"
            });
            context.Contacts.Add(new Contact()
            {
                Name = "Maria"
            });
            context.Contacts.Add(new Contact()
            {
                Name = "Angie Stanton",
                Site = "http://angiestanton.com"
            });

            context.SaveChanges();

            context.Contacts.Find(1).Emails.Add(new Email()
            {
                EmailAddress = "peter@gmail.com"
            });
            context.Contacts.Find(1).Emails.Add(new Email()
            {
                EmailAddress = "peter_ivanov@yahoo.com"
            });
            context.Contacts.Find(3).Emails.Add(new Email()
            {
                EmailAddress = "info@angiestanton.com"
            });

            context.Contacts.Find(1).Phones.Add(new Phone()
            {
                PhoneNumber = "+359 2 22 22 22"
            });
            context.Contacts.Find(1).Phones.Add(new Phone()
            {
                PhoneNumber = "+359 88 77 88 99"
            });
            context.Contacts.Find(2).Phones.Add(new Phone()
            {
                PhoneNumber = "+359 22 33 44 55"
            });

            context.SaveChanges();
        }
    }
}
