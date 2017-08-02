using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    public class BaseCardSet
    {
        public List<Card> cards = new List<Card>();

        public BaseCardSet(){}

        public BaseCardSet(BaseCardSet source){
            this.cards = source.cards;
        }

        

        public BaseCardSet shuffle()
        {
            Random rand = new Random();
            cards = cards.OrderBy(x => rand.Next()).ToList();
            return this;
        }

        public int Count
        {
            get
            {
                return cards.Count;
            }
        }


        public Card deal()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public List<Card> deal(int number=1)
        {
            List<Card> deltCards = cards.GetRange(0,number);
            cards.RemoveRange(0,number);
            return deltCards;
        }

        public List<Card> draw(BaseCardSet source, int number=1)
        {
            List<Card> deltCards = source.cards.GetRange(0,number);
            source.cards.RemoveRange(0,number);
            cards.AddRange(deltCards);
            return deltCards;
        }


        public Card draw(BaseCardSet source)
        {
            Card card = source.cards[0];
            source.cards.RemoveAt(0);
            cards.Add(card);
            return card;
        }

        public Card discard(int index)
        {
            if (index >= 0 && index < cards.Count)
            {
                Card card = cards[index];
                cards.RemoveAt(index);
                return card;
            }
            else
            {
                return null;
            }
        }


        public override string ToString()
        {
            string strCards = "";
            foreach (Card card in cards)
            {
                strCards += card.ToString() + "\r\n";
            }
            return strCards;
        }

        public  void Show()
        {
            
            foreach (Card card in cards)
            {
                card.Show();
            }
        }

    }
}
