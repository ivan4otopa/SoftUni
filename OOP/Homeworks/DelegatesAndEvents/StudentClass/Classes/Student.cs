using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentClass.Classes
{
    public delegate void ChangedPropertyEventHandler(object sender, PropertyChangedEventArgs e);

    class Student
    {
        private string name;
        private int age;
        private event ChangedPropertyEventHandler PropertyChanged;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.PropertyChanged += this.Message;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                var ev = new PropertyChangedEventArgs { PreviousName = this.name, Name = value, ChangedProperty = "Name" };
                this.name = value;
                this.OnChanged(this, ev);
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
                var ev = new PropertyChangedEventArgs { PreviousAge = this.age, Age = value, ChangedProperty = "Age" };
                this.age = value;
                this.OnChanged(this, ev);
            }
        }

        protected virtual void OnChanged(object sender, PropertyChangedEventArgs e)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }

        private void Message(object sender, PropertyChangedEventArgs e)
        {
            switch(e.ChangedProperty)
            {
                case "Name":
                    Console.WriteLine("Property changed: Name (From {0} to {1}).", e.PreviousName, e.Name);
                    break;
                case "Age":
                    Console.WriteLine("Property changed: Age (from {0} to {1}).", e.PreviousAge, e.Age);
                    break;
            }
        }
    }
}
