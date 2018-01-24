using System;
using System.Collections.Generic;

namespace DeckofCards
{
//     Finally, create a class called "Player"

// Give the Player class a name property
// Give the Player a hand property that is a List of type Card
// Give the Player a draw method of which draws a card from a deck, adds it to the player's hand 
// and returns the Card
// Note this method will require reference to a deck object
// Give the Player a discard method which discards the Card at the specified index 
// from the player's hand and returns this Card or null if the index does not exist.
    public class Player
    {
        public string Name;
        public List<Card> hand = new List<Card>();

        public Card DisCard(int index)
        {
            if(index > hand.Count)
                return null;
            else
            {
                Card temp = hand[index];
                hand.Remove(hand[index]);
                return temp;
            }
                
        }

        public void Draw(Card c)
        {
            hand.Add(c);
        }
        public void Show()
        {
            Console.WriteLine(Name + " player has: ");
            foreach(Card i in hand)
                Console.WriteLine(i.stringVal + " " + i.suit);
        }

        public Player(string n)
        {
            Name = n;
        }
    }
}