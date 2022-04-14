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
        public int Type { get; set; }

        public Pile(int numberOfCards)
        {
            Cards = new List<Card>();
            for(int i = 1; i <= numberOfCards; i++)
            {
                Cards.Add(new Card());
            }
        }

        public void PushCards(List<Card> cards)
        {
            foreach(Card card in cards)
            {
                Cards.Add(card);
            }
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
        public List<Card> GetCards() { return Cards; }
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

    public enum PileType
    {
        Stock = 0,
        T1 = 1,
        T2 = 2,
        T3 = 3,
        T4 = 4,
        T5 = 5,
        T6 = 6,
        T7 = 7,
        F1 = 8,
        F2 = 9,
        F3 = 10,
        F4 = 11,
        Talon = 12
    }
}
