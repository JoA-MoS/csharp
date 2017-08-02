using System;
using System.Collections.Generic;
namespace DeckOfCards
{
    public class Deck:BaseCardSet
    {
        public static Suit[] suits = { new Suit("Clubs", ConsoleColor.White, ConsoleColor.Black),
                                       new Suit("Spades", ConsoleColor.White, ConsoleColor.Red), 
                                       new Suit("Hearts", ConsoleColor.White, ConsoleColor.Black),
                                       new Suit("Diamonds", ConsoleColor.White, ConsoleColor.Red) };
        public static string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };


       
        public Deck()
        {
            createDeck();
        }

        private void createDeck()
        {
            for (int s = 0; s < suits.Length; s++)
            {
                for (int r = 0; r < ranks.Length; r++)
                {
                    cards.Add(new Card(s, r));
                }
            }

        }

        private void resetDeck()
        {
           cards.Clear();
           createDeck();
        }
    }


}
