using System;

namespace AnimalKingdom
{
    public class Dog : Animal
    {
        public string breed;

        public Dog(string name, string breed, int weight):base(name, 4, weight, "woof"){
            this.breed = breed;
            
        }

        public void move(){
            Console.WriteLine($"{name} runs home");
        }

    }
}
