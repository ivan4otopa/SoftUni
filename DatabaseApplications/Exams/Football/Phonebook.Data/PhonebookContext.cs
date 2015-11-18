namespace Phonebook.Data
{
    using Models;
    using Phonebook.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("name=PhonebookContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());
        }

        public IDbSet<Contact> Contacts { get; set; }

        public IDbSet<Email> Emails { get; set; }

        public IDbSet<Phone> Phones { get; set; }
    }
}