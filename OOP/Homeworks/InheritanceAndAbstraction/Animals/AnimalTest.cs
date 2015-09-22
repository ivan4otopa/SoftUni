using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class AnimalTest
    {
        static void Main()
        {
            var animals = new Animal[]
            {
                new Dog("Miro", 2, "male"),
                new Dog("Laila", 5, "female"),
                new Cat("Kotka", 3, "male"),
                new Cat("Murla", 7, "female"),
                new Frog("Kraker", 4, "male"),
                new Frog("Angelica", 6, "female"),
                new Tomcat("Tom", 1),
                new Tomcat("Frank", 1),
                new Kitten("Sashka", 1),
                new Kitten("Igrivka", 1)
            };
            int totalAnimalAge = 0;
            foreach (var animal in animals.OfType<Dog>())
            {
                totalAnimalAge += animal.Age;
            }
            Console.WriteLine("Average age of animals of type Dog is " + (totalAnimalAge / 2));
            totalAnimalAge = 0;
            foreach (var animal in animals.OfType<Cat>())
            {
                totalAnimalAge += animal.Age;
            }
            Console.WriteLine("Average age of animals of type Cat is " + ((totalAnimalAge - 4) / 2));
            totalAnimalAge = 0;
            foreach (var animal in animals.OfType<Frog>())
            {
                totalAnimalAge += animal.Age;
            }
            Console.WriteLine("Average age of animals of type Frog is " + (totalAnimalAge / 2));
            totalAnimalAge = 0;
            foreach (var animal in animals.OfType<Tomcat>())
            {
                totalAnimalAge += animal.Age;
            }
            Console.WriteLine("Average age of animals of type Tomcat is " + (totalAnimalAge / 2));
            totalAnimalAge = 0;
            foreach (var animal in animals.OfType<Kitten>())
            {
                totalAnimalAge += animal.Age;
            }
            Console.WriteLine("Average age of animals of type Kitten is " + (totalAnimalAge / 2));
        }
    }
}
