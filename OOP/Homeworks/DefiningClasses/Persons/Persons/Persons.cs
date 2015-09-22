using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Age must be >= 1 and <= 100!");
                }
                this.age = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (value != null && !value.Contains("@"))
                {
                    throw new ArgumentException("Email not valid!");
                }
                this.email = value;
            }
        }
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
        public Person(string name, int age)
            : this(name, age, null)
        {
        }
        public override string ToString()
        {
            if (this.email != null)
            {
                return String.Format("Name: {0}; Age: {1}; Email: {2}", this.name, this.age, this.email);
            }
            else
            {
                return String.Format("Name: {0}; Age: {1}", this.name, this.age);
            }
        }
    }
}