using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    public abstract class AbstractCardSet
    {
        public List<Card> cards = new List<Card>();

        public AbstractCardSet shuffle()
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

        // public List<Card> draw(AbstractCardSet source, int count=1)
        // {
        //     Card card = cards[0];
        //     cards.RemoveAt(0);
        //     return card;
        // }


        public Card draw(AbstractCardSet source)
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

    }
}
