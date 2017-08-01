using System;

namespace AnimalKingdom
{
    public class Bird : Animal
    {
        public string color;
        public bool canFly = true;

        public Bird(string name, int weight, string noise, string color, bool canFly = true, bool swims = false) : base(name, 2, weight, noise, canSwim: swims)
        {
            this.color = color;
            this.canFly = canFly;
        }

        public void move()
        {
            string movement = "";
            if (canFly)
            {
                movement = "flies";
            }
            else if (canSwim)
            {
                movement = "swims";
            }
            else
            {
                movement = "runs";
            }
            Console.WriteLine($"{name} {movement}");
        }
    }
}
