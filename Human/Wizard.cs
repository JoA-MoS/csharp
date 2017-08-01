using System;

namespace Human
{
    public class Wizard : Human
    {

        public Wizard(string name, int inteligence=25, int health=50) : base(name:name)
        {
            this.inteligence=inteligence;
            this.health=health;
        }


        public Wizard Heal()
        {
            // Can we make this heal others?
            health = 10 * inteligence;
            return this;
        }

        public Wizard Fireball(object enemy){
            Random rand = new Random();
            (enemy as Human).health -= rand.Next(20,51);
            return this;
        }
    }
}
