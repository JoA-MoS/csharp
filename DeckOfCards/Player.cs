namespace DeckOfCards
{
    public class Player : BaseCardSet
    {
        public string name;
        // hand = cards from Abstrace Base Class

        public Player(string name)
        {
            this.name = name;
        }


        public override string ToString()
        {
            string strCards = "";

            return $"=================={name}=================\r\n"+base.ToString();
        }
    }
}
