using System;
using System.Linq;
using System.Collections.Generic;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Card> listOfCards = new List<Card>();

            foreach (string card in cards)
            {
                List<string> cardInf = card.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
                try
                {
                    Card c = null;
                    if (cardInf[1] == "S")
                    {
                        c = new Card(cardInf[0], '\u2660');

                    }
                    else if (cardInf[1] == "H")
                    {
                        c = new Card(cardInf[0], '\u2665');
                    }
                    else if(cardInf[1] == "D")
                    {
                        c = new Card(cardInf[0], '\u2666');
                    }
                    else if( cardInf[1] == "C")
                    {
                        c = new Card(cardInf[0], '\u2663');
                    }
                    else
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    listOfCards.Add(c);
                    
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
                
            }
            listOfCards.ForEach(c => Console.Write(c.ToString() + " "));
        }
    }
    public class Card
    {
        private string face;
        private char suit;
        public string Face
        {
            get { return face; }
            set
            {
                List<string> faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "J", "Q", "K", "A" };

                if (!faces.Contains(value) && value != "10")
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public char Suit
        {
            get { return suit; }
            set
            {
                suit = value;
            }
        }


        public Card(string face, char suit)
        {
            Face = face;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
