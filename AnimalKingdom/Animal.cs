using System;

namespace AnimalKingdom
{
    public abstract class Animal
    {
        public string name;
        public int legs;

        public int weight;

        public bool canSwim;

        public bool warmBlooded;

        public string noise;

        // public Animal()
        // {

        // }

        public Animal(string name, int legs, int weight, string noise, bool warmBlooded = true, bool canSwim = true)
        {
            this.name = name;
            this.legs = legs;
            this.weight = weight;
            this.noise = noise;
            this.warmBlooded = warmBlooded;
            this.canSwim = canSwim;
        }

        public string speak(){
            Console.WriteLine(noise);
            return noise;
        }

         void move(){

        }


        public override string ToString(){
            return $"{name}: {legs}, {noise}, {weight}, {warmBlooded}, {canSwim}";
        }

    }
}
