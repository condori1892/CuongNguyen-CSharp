using System;

namespace DeckofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck p = new Deck();
            p.InitializeDeck();
            p.PrintCard();
            p.Shuffle();
            p.PrintCard();
            Player john = new Player("John");
            john.Draw(p.Deal());
            john.Draw(p.Deal());
            john.Draw(p.Deal());
            john.Draw(p.Deal());
            john.Show();
            john.DisCard(0);
            john.Show();

        }
    }
}
