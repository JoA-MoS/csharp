using System;

namespace AnimalKingdom
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog rover = new Dog("rover", "Chow", 50);
            rover.move();
            Console.WriteLine(rover);
            rover.speak();
            rover.move();
            Bird tweety = new Bird("tweety", 2, "tweet", "yellow", false, true);

            Console.WriteLine(tweety);
            tweety.speak();
            tweety.move();

            

            Test a = new Test();
            Console.WriteLine(a.age);
            Test b= new Test(70);
            Console.WriteLine(b.age);
        }
    }
}
