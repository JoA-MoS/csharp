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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strength"></param>
        /// <param name="inteligence"></param>
        /// <param name="dexterity"></param>
        /// <param name="health"></param>
        public Human(string name, int strength=3, int inteligence=3, int dexterity=3, int health=100)
        {
            this.name = name;
            this.strength = strength;
            this.inteligence = inteligence;
            this.dexterity = dexterity;
            this.Health = health;
        }

        public override string ToString()
        {
            string format="=========================\r\n";
            format+=$"Name: {name}\r\n";
            format+=$"Strengh: {strength}\r\n";
            format+=$"Inteligence: {inteligence}\r\n";
            format+=$"Dexterity: {dexterity}\r\n";
            format+=$"Health: {Health}";
            return format;
        }

        public Human Attack(object enemy)
        {
            if (enemy is Human)
            {
                ((Human)enemy).Health-= strength * 5;
            }
            else
            {
                throw new NotImplementedException();
            }
            return this;
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if(health-value<0){
                    health=0;
                }
                else{
                    health -= value;
                }
            }
        }
    }
}
