using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelperModels
{
    /* This class is used as a base when creating the different piles used in the solitaire game.
     * Tableaus 1-7, Stock, Talon and Foundations 1-4 are all Pile classes from this
     */
    public class Pile
    {
        protected List<Card> Cards { get; set; }
        public int Type { get; set; }

        public Pile()
        {
            Cards = new List<Card>();
        }

        public void PushCards(List<Card> cards)
        {
            foreach(Card card in cards)
            {
                Cards.Add(card);
            }
        }
        public void PopCards(List<Card> cardsToRemove)
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
        public int GetNumberOfCards()
        {
            return Cards.Count;
        }
        public int GetNumberOfClosedCards()
        {
            List<Card> ClosedCards = Cards.FindAll(c => c.Visible == false);
            return ClosedCards.Count;
        }

        public bool IsMoveToFoundationPossible(Card toCard)
        {
            //Checks if card is ace             
            if(IsEmpty() && toCard.Rank == 1 && SuitToType(toCard.Suit) == Type)
            {
                return true;
            }

            //Checks if other cards can be moved to foundation
            if (!IsEmpty() && GetTopCard().Suit == toCard.Suit && GetTopCard().Rank == toCard.Rank - 1)
            {
                return true;
            }
            return false;
        }

        public bool IsMoveToTableauPossible(Card toCard)
        {
            //Checks if card can be moved to another pile
            if (!IsEmpty() && GetTopCard().IsRed() && toCard.IsBlack() || (GetTopCard().IsBlack() && toCard.IsRed()))
            {
                if (toCard.Rank == GetTopCard().Rank - 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMovePossible(Card toCard)
        {
            if(Type == 8 || Type == 9 || Type == 10 || Type == 11 )
            {
                return IsMoveToFoundationPossible(toCard);

            }
            if (Type == 1 || Type == 2 || Type == 3 || Type == 4 || Type == 5 || Type == 6 || Type == 7)
            {
                return IsMoveToTableauPossible(toCard);
            }
            return false;
        }
        private int SuitToType(int suit)
        {
            switch (suit)
            {
                case 1: return 8;
                case 2: return 9;
                case 3: return 10;
                case 4: return 11;
                default: return 0;
            }
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
