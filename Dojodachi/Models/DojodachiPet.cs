using System;

namespace Dojodachi.Models
{

    public class DojodachiPet
    {
        public enum states { DEAD, ALIVE, WON }


        int happiness = 20;
        int fullness = 20;
        int energy = 50;
        //It might be cool to seperate meals out to a player class so the meal moves with the player and they can
        //choose what Dojodachi to feed.
        int meals = 3;
        public event EventHandler DidNotEat;
        public event EventHandler DidNotPlay;
        public event EventHandler Death;
        public event EventHandler Won;
        public DojodachiPet() { }
        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        public DojodachiPet(DojodachiPet pet) : this(pet.Happiness, pet.Fullness, pet.Energy, pet.Meals) { }
        public DojodachiPet(int happiness, int fullness, int energy, int meals)
        {
            Happiness = happiness;
            Fullness = fullness;
            Energy = energy;
            Meals = meals;
        }

        protected virtual void OnDidNotEat(EventArgs e)
        {
            if (DidNotEat != null)
                DidNotEat(this, e);
        }

        protected virtual void OnDidNotPlay(EventArgs e)
        {
            if (DidNotPlay != null)
                DidNotPlay(this, e);
        }

        protected virtual void OnWin(EventArgs e)
        {
            if (Won != null)
                Won(this, e);
        }

        protected virtual void OnDeath(EventArgs e)
        {
            if (Death != null)
                Death(this, e);
        }

        public int Happiness
        {
            get
            {
                return happiness;
            }
            set
            {
                happiness = value;
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
                fullness = value;
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
                meals = value;
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
                energy = value;
            }
        }


        public DojodachiPet Feed()
        {
            Meals -= 1;
            Random rand = new Random();
            if (rand.Next(4) != 3)
            {
                Fullness += rand.Next(5, 11);
            }
            else
            {
                // Should we handle these events differently
                Console.WriteLine("Dojodachi does not like the meal");
                OnDidNotEat(EventArgs.Empty);
            }
            return this;
        }

        public DojodachiPet Play()
        {
            Energy -= 5;
            Random rand = new Random();
            if (rand.Next(4) != 3)
            {
                Happiness += rand.Next(5, 11);
            }
            else
            {
                Console.WriteLine("Dojodachi does not like how you are playing");
                OnDidNotPlay(EventArgs.Empty);
                // throw new Exception("Dojodachi does not like how you are playing");
            }
            return this;
        }

        public DojodachiPet Work()
        {
            Energy -= 5;
            Random rand = new Random();
            Meals += rand.Next(1, 4);
            return this;
        }

        public DojodachiPet Sleep()
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
                Console.WriteLine("Dojodachi died");
                OnDeath(EventArgs.Empty);
            }
            if (State == states.WON)
            {
                Console.WriteLine("Dojodachi WON!");
                OnWin(EventArgs.Empty);
            }
        }
    }
}
