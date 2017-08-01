using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human h = new Human("Justin");
            Wizard w = new Wizard("wizard");
            Ninja n = new Ninja("ninja");
            Samurai s = new Samurai("sam");

            
            Console.WriteLine(h);
            Console.WriteLine(w);
            Console.WriteLine(n);
            Console.WriteLine(s);

            Console.WriteLine(Samurai.Count);
            
        }
    }
}
