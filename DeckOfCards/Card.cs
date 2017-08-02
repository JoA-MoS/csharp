using System;

namespace DeckOfCards
{

    public class Card
    {

        public string strValue;
        public int suit;
        public int rank;

        public Card(int suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;

        }

        public override string ToString()
        {
            return $"{Deck.ranks[rank]} of {Deck.suits[suit].name}";
        }

        public void Show(){
            Console.BackgroundColor = Deck.suits[suit].backgroundColor;
            Console.ForegroundColor = Deck.suits[suit].textColor;
            Console.WriteLine(this);
            Console.ResetColor();
        }
    }
}
