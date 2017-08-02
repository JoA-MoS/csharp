using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck standardDeck = new Deck();
            Player p1 = new Player("player 1");
            Console.WriteLine(standardDeck);

            Console.WriteLine(standardDeck.Count);
            standardDeck.shuffle();

            p1.draw(standardDeck);
            p1.draw(standardDeck);
            p1.draw(standardDeck);
            p1.draw(standardDeck);
            p1.draw(standardDeck);

            

            Console.WriteLine(p1);
            Console.WriteLine(p1.Count);
            Console.WriteLine(standardDeck.Count);

            Console.WriteLine(p1.discard(2));
            Console.WriteLine(p1);

            standardDeck.Show();

        }


    }
}
