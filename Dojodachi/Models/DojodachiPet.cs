using System;

namespace Dojodachi.Models
{

    public class Pet
    {
        public enum states { DEAD, ALIVE, WON }


        int happiness = 20;
        int fullness = 20;
        int energy = 50;
        //It might be cool to seperate meals out to a player class so the meal moves with the player and they can
        //choose what Dojodachi to feed.
        int meals = 3;

        public Pet() { }

        public int Happiness
        {
            get
            {
                return happiness;
            }
            set
            {
                happiness += value;
                CheckStatus();
            }
        }

        public int Fullness
        {
            get
            {
                return fullness;
            }
            set
            {
                fullness += value;
                CheckStatus();
            }
        }

        public states State
        {
            get
            {
                if (Happiness <= 0 || Fullness <= 0)
                {
                    return states.DEAD;
                }
                else if (Energy > 100 && Fullness > 100 && Happiness > 100)
                {
                    return states.WON;
                }
                else
                {
                    return states.ALIVE;
                }

            }
        }

        public int Meals
        {
            get
            {
                return meals;
            }
            set
            {
                meals += value;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }
            set
            {
                energy += value;
            }
        }


        public Pet Feed()
        {
            Meals -= 1;
            Random rand = new Random();
            if (rand.Next(4) != 3)
            {
                Fullness += rand.Next(5, 11);
            }
            else
            {
                throw new Exception("Dojodachi does not like the meal");
            }
            return this;
        }

        public Pet Play()
        {
            Energy -= 5;
            Random rand = new Random();
            if (rand.Next(4) != 3)
            {
                Energy += rand.Next(5, 11);
            }
            else
            {
                throw new Exception("Dojodachi does not like how you are playing");
            }
            return this;
        }

        public Pet Work()
        {
            Energy -= 5;
            Random rand = new Random();
            Meals += rand.Next(1, 4);
            return this;
        }

        public Pet Sleep()
        {
            Fullness -= 5;
            Happiness -= 5;
            Energy += 15;
            return this;
        }

        private void CheckStatus()
        {
            if (State == states.DEAD)
            {
                throw new Exception("Your Dojodachi has Died :-(");
            }
            if (State == states.WON)
            {
                throw new Exception("You WON!");
            }
        }
    }
}
