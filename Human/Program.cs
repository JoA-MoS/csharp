using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human justin = new Human("Justin");
            Human christian = new Human("Christian");

            justin.Attack(christian);
            Console.WriteLine(christian);
            justin.Attack(5);
        }
    }
}
