namespace Phonebook.ConsoleClient
{
    using Data;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhonebookContext();

            //1.ListContactsWithTheirEmailAndPhone
            //var contacts = context.Contacts
            //    .Select(c => new
            //    {
            //        c.Name,
            //        Emails = c.Emails.Select(e => e.EmailAddress),
            //        Phones  = c.Phones.Select(p => p.PhoneNumber)
            //    });

            //foreach (var contact in contacts)
            //{
            //    Console.WriteLine(contact.Name);

            //    foreach (var email in contact.Emails)
            //    {
            //        Console.WriteLine(email);
            //    }

            //    foreach (var phone in contact.Phones)
            //    {
            //        Console.WriteLine(phone);
            //    }
            //}

            string json = File.ReadAllText("../../contacts.json");
            var contacts = JsonConvert.DeserializeObject<List<JObject>>(json);

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact["name"]);
            }
        }
    }
}
