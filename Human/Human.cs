using System;

namespace Human
{
    public class Human
    {
        public string name;
        public int strength = 3;
        public int inteligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string name)
        {
            this.name = name;
        }


        public Human(string name, int strength, int inteligence, int dexterity, int health)
        {
            this.name = name;
            this.strength = strength;
            this.inteligence = inteligence;
            this.dexterity = dexterity;
            this.health = health;
        }

        public override string ToString()
        {
            return "Name: " + name + " Health: " + health;
        }

        public Human Attack(object enemy)
        {
            if (enemy is Human)
            {
                ((Human)enemy).health -= strength * 5;
            }
            else
            {
                throw new NotImplementedException();
            }
            return this;
        }
    }
}