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
            if(cardsToRemove == Cards)
            {
                cardsToRemove.Clear();
            }
            foreach(Card card in cardsToRemove)
            {
                Cards.Remove(card);
            }
        }
        public Card GetTopCard()
        {
            if(Cards.Count == 0)
            {
                return null;
            }
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
            if (Cards.Count == 0) return true;
            if (Cards == null) return true;
            return false;
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

        private bool IsMoveToFoundationPossible(Card toCard)
        {
            //Checks if card is ace             
            if(IsEmpty() && toCard.Rank == 1 && SuitToType(toCard.Suit) == Type)
            {
                return true;
            }

            //Checks if other cards can be moved to foundation
            if (!IsEmpty() && GetTopCard().Visible && GetTopCard().Suit == toCard.Suit && GetTopCard().Rank == toCard.Rank - 1)
            {
                return true;
            }
            return false;
        }

        private bool IsMoveToTableauPossible(Card toCard)
        {
            if(IsEmpty()) return true;
            /* Checks if toCard can be moved to top of this pile
             * Checks done:
             * - Tableau-pile should not be empty
             * - Topcard should be visible
             * - Topcard should have a color different than toCard
             */
            if (!IsEmpty() && GetTopCard().Visible && GetTopCard().IsRed() && toCard.IsBlack() || (GetTopCard().IsBlack() && toCard.IsRed()))
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
            // Call this function if this pile is a foundation-pile
            if(Type == 8 || Type == 9 || Type == 10 || Type == 11 )
            {
                return IsMoveToFoundationPossible(toCard);

            }
            // Call this function if this pile is a tableau-pile
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
        public string PileToString()
        {
            return PileTypeToString();
        }
        private string PileTypeToString()
        {
            switch (Type)
            {
                case 0:     return "Stock";
                case 1:     return "T1";
                case 2:     return "T2";
                case 3:     return "T3";
                case 4:     return "T4";
                case 5:     return "T5";
                case 6:     return "T6";
                case 7:     return "T7";
                case 8:     return "F1";
                case 9:     return "F2";
                case 10:    return "F3";
                case 11:    return "F4";
                case 12:    return "Talon";
                default:    return null;
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
