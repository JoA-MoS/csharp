namespace DeckOfCards
{
    public class Rank
    {
        public string name;
        public int value;
        public int score;

        public Rank(){}

        public Rank(string name, int value, int score){
            this.name = name;
            this.value = value;
            this.score = score;
        }

    }
}
