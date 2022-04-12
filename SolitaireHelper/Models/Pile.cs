using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelper.Models
{
    /* This class is used as a base to inherit from when creating the different piles used in the solitaire game.
     * Tableaus 1-7, Stock, Talon and Foundations 1-4 inherit from this
     */
    public class Pile
    {
        protected List<Card> Cards { get; set; }

        public Pile(int numberOfCards)
        {
            Cards = new List<Card>();
            for(int i = 1; i <= numberOfCards; i++)
            {
                Cards.Add(new Card());
            }
        }

        public void PushCard(Card card)
        {
            Cards.Add(card);
        }

        public void PopCard(List<Card> cardsToRemove)
        {
            foreach(Card card in cardsToRemove)
            {
                Cards.Remove(card);
            }
        }
        public Card GetTopCard()
        {
            return Cards.FindLast(c => c.Rank != 0);
        }
        public bool IsEqual(Card card)
        {
            return Cards[(Cards.Count-1)].IsEqual(card);
        }
        public override string ToString()
        {
            if(Cards.Count == 0)
            {
                return "Pile is empty";
            }
            else
            {
                foreach(Card card in Cards)
                {
                    return card.ToString();
                }
            }
            return "Something went wrong";
        }
        public bool IsEmpty()
        {
            return Cards.Count == 0;
        }
        public int Size()
        {
            return Cards.Count;
        }
    }
}
