using System;

namespace DeckofCards
{
//     Create a class called "Card"

//     Give the Card class a property "stringVal" which will hold the value of the card ex.
//  (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a String
//     Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds)
//     Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers
    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;
        string[] CardValue = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        string[] Suit = { "Clubs", "Spades", "Hearts", "Diamonds"};

        public Card(int suit_num, int card_num)
        {
            suit = Suit[suit_num];
            stringVal = CardValue[card_num];
            val = card_num +1;
        }
    


    }
    
}