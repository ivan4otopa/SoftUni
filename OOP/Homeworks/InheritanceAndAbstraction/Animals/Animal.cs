using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    abstract class Animal : ISound
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public override string ToString()
        {
            return String.Format("Name: {0}; Age: {1}; Gender: {2}", this.Name, this.Age, this.Gender);
        }
        public abstract void ProduceSound();
    }
}
