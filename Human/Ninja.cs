namespace Human
{
    public class Ninja : Human
    {
        ///
        public Ninja(string name, int dexterity=175) : base(name:name)
        {
            this.dexterity=dexterity;
        }
        public Ninja Steal(object enemy){
            Attack(enemy);
            Health+=10;
            return this;
        }

        public Ninja GetAway(){
            Health-=15;
            return this;
        }

        
    }
}
