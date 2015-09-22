using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }
        public override string ToString()
        {
            return String.Format("Dog: {0}", base.ToString());
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Bark");
        }
    }
}
