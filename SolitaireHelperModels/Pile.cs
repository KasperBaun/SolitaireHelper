using System;
using System.Collections.Generic;

namespace SolitaireHelperModels
{
    /* This class is used as a base when creating the different piles used in the solitaire game.
     * Tableaus 1-7, Stock, Talon and Foundations 1-4 are all Pile classes
     */
    public class Pile
    {
        private readonly List<Card> Cards;
        public int Type { get; set; }

        public Pile()
        {
            Cards = new List<Card>();
        }

        public void AddCards(List<Card> cards)
        {
            if(cards != null & cards.Count > 0)
            {
                foreach(Card card in cards)
                {
                    Cards.Add(card);
                }
            }
        }
        public void RemoveCards(List<Card> cardsToRemove)
        {
            foreach(Card card in cardsToRemove)
            {
                if(Cards.Contains(card))
                    Cards.Remove(card);
            }
        }
        public Card GetTopCard()
        {
            if(Cards.Count == 0 || Cards ==  null)
            {
                return null;
            }
            else
            {
                return Cards[Cards.Count - 1];
            }
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
            if (Cards.Count == 0 || Cards == null) return true;
            return false;
        }
        public int GetNumberOfCards()
        {
            return Cards.Count;
        }
        public void PrintPile()
        {
            Console.WriteLine(PileTypeToString());
            foreach(Card card in Cards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine();
        }
        private bool IsMoveToFoundationPossible(Card card)
        {
            //Checks if card is ace             
            if(IsEmpty() && card.Rank == 1 && SuitToType(card.Suit) == Type)
            {
                return true;
            }

            //Checks if other cards can be moved to foundation
            if (!IsEmpty() && card.Suit == GetTopCard().Suit && card.Rank - 1 == GetTopCard().Rank)
            {
                return true;
            }
            return false;
        }
        private bool IsMoveToTableauPossible(Card card)
        {
            if(IsEmpty() && card.Rank == 13) return true;
            
            if(IsEmpty() && card.Rank != 13)
            {
                return false;
            }
            if (!IsEmpty() && ((GetTopCard().IsRed() && card.IsBlack()) || (GetTopCard().IsBlack() && card.IsRed())))
            {
                if (card.Rank == GetTopCard().Rank - 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsMovePossible(Card toCard)
        {
            // Call this function if this pile is a foundation-pile
            if(IsFoundation())
            {
                return IsMoveToFoundationPossible(toCard);

            }
            // Call this function if this pile is a tableau-pile
            if (IsTableau())
            {
                return IsMoveToTableauPossible(toCard);
            }
            return false;
        }
        public bool IsFoundation()
        {
            if (Type == 8 || Type == 9 || Type == 10 || Type == 11)
                return true;
            return false;
        }
        public bool IsTableau()
        {
            if (Type == 1 || Type == 2 || Type == 3 || Type == 4 || Type == 5 || Type == 6 || Type == 7)
                return true;
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
}
