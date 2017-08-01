using System.Threading;

namespace Human
{
    public class Samurai : Human
    {

        static int counter = 0;
        public Samurai(string name, int health=200) : base(name:name)
        {
            Interlocked.Increment(ref counter);
            this.health=health;
        }

        ~Samurai()
        {
            Interlocked.Decrement(ref counter);
        }

        public Samurai DeathBlow(object enemy)
        {
            (enemy as Human).Health -= 50;
            return this;
        }

        public Samurai Meditate()
        {
            Health = 200;
            return this;
        }

        public static int Count
        {
            get
            {
                return counter;
            }
        }
    }
}
