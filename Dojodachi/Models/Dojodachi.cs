using System;

namespace Dojodachi.Models
{

    public class Dojodachi
    {
        public enum states { DEAD, ALIVE, WON }


        int happiness = 20;
        int fullness = 20;
        int energy = 50;
        //It might be cool to seperate meals out to a player class so the meal moves with the player and they can
        //choose what Dojodachi to feed.
        int meals = 3;
        states state = Dojodachi.states.ALIVE;

        public Dojodachi() { }

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
                return State;
            }
            set
            {
                state = value;
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


        public Dojodachi Feed()
        {
            if (Meals >= 1)
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
            }
            else
            {
                throw new Exception("You have no meals to feed");
            }
            return this;
        }

        public Dojodachi Play()
        {
            if (Energy >= 5)
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
            }
            else
            {
                throw new Exception("You have no energy to play");
            }
            return this;
        }

        public Dojodachi Work()
        {

            if (Energy >= 5)
            {
                Energy -= 5;
                Random rand = new Random();
                Meals += rand.Next(1, 4);
            }
            else
            {
                throw new Exception("You have no energy to work");
            }
            return this;
        }

        public Dojodachi Sleep()
        {
            if (Fullness >= 5)
            {
                if (Happiness >= 5)
                {

                }
                else
                {
                    throw new Exception("You are to sad to sleep");
                }
            }
            return this;
        }

        private void CheckStatus()
        {
            if (happiness <= 0 || fullness <= 0)
            {
                state = states.DEAD;
            }
            if (fullness > 100 && happiness > 100)
            {
                state = states.WON;
            }
        }
    }
}
