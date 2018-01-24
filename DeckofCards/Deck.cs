using System;
using System.Collections.Generic;

namespace DeckofCards
{
//     Next, create a class called "Deck"

// Give the Deck class a property called "cards" which is a list of Card objects
// When initializing the deck make sure that it has a list of 52 unique cards as its "cards" property
// Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards,
//  and returns the Card
// Give the Deck a reset method that resets the cards property to the contain the original 52 cards
// Give the Deck a shuffle method that randomly reorders the deck's cards
    class Deck
    {
        public List<Card> cards;
        public void Reset()
        {
            InitializeDeck();
        }
        public Card Deal()
        {
            Card cardRemove = cards[0];
            cards.RemoveAt(0);
            return cardRemove;
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for(int i = 0; i < cards.Count; i++)
            {
                int index = rand.Next(cards.Count);
                Card temp = cards[0];
                cards[0] = cards[index];
                cards[index] = temp;
            }

        }

        public void InitializeDeck()
        {
            cards = new List<Card>();
            for(int suitVal = 0; suitVal <4; suitVal++)
                for(int cardVal = 0; cardVal <13; cardVal++)
                    cards.Add(new Card(suitVal,cardVal));

        }
        public void PrintCard()
        {
            foreach(Card c in cards)
                Console.WriteLine(c.stringVal +"  "+ c.suit);        }
    }


}