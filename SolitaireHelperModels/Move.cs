using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelperModels
{
    public class Move
    {
        private Pile From;
        private Pile To;
        private Card Card;
        protected int Score;

        public Move(Pile from, Pile to, Card card)
        {
            Pile fromPile = new Pile();
            fromPile.Type = from.Type;
            if(from.GetCards() != null && from.GetCards().Count > 0)
            {
                fromPile.PushCards(from.GetCards());
            }
            From = fromPile;

            Pile toPile = new Pile();
            toPile.Type = to.Type;
            if(to.GetCards() != null && to.GetCards().Count > 0)
            {
                toPile.PushCards(to.GetCards());
            }
            To = toPile;

            Card newCard = new Card(card.Suit, card.Rank, card.Visible);
            Card = newCard;
            CalculateScore();
        }
        public void CalculateScore()
        {
            if (Card.Visible == false || Card == null)
            {
                Score = 0;
                return ;
            }

            // Test if ace can move to any of the Foundations
            if (Card.Rank == 1 && IsTableau(From) && IsFoundation(To)) {
                Score = 95 + From.GetCards().Count;
                return;
            }

            // Test if 2 can move to any of the Foundations
            if (Card.Rank == 2 && IsTableau(From) && IsFoundation(To)) {
                Score = 85 + From.GetCards().Count;
                return;
            }

            // Test if king can move to an empty Tableau
            if (Card.Rank == 13 && IsTableau(From) && IsTableau(To) && To.IsEmpty() && !From.IsEmpty()) {
                Score = 75 + From.GetCards().Count;
                return;
            }
            // Test if card can move from Table to Foundation
            if (IsTableau(From) && IsFoundation(To)) {
                Score = From.GetCards().Count + 40;
                return;
            }

            // Test if card can move from Tableau to Tableau
            if (Card.Rank != 13 && IsTableau(From) && IsTableau(To)) {
                Score = From.GetCards().Count + 30;
                return;
            }

            // Test if card can move from Stock to Tableau
            if (From.Type==0 && IsTableau(To)) {
                Score = From.GetCards().Count + 20;
                return;
            }

            // Test if card can move from Stock to any of the foundations
            if (From.Type==0 && IsFoundation(To)) {
                Score = From.GetCards().Count + 10;
                return;
            }

            Score = -1;
            Card = null;
        }

        private bool IsFoundation(Pile pile)
        {
            switch (pile.Type)
            {
                case 8:
                    return true;
                case 9:
                    return true;
                case 10:
                    return true;
                case 11:
                    return true;
                default:
                    return false;
            }
        }
        private bool IsTableau(Pile pile)
        {
            switch (pile.Type)
            {
                case 1:
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                case 4:
                    return true;
                case 5:
                    return true;
                case 6:
                    return true;
                case 7:
                    return true;
                default:
                    return false;
            }
        }
        public int GetScore()
        {
            return Score;
        }
        public Pile GetFrom()
        {
            return From;
        }
        public Pile GetTo()
        {
            return To;
        }
        public Card GetCard()
        {
            return Card;
        }
  
        public override string ToString()
        {
            // If the move is the first move to a foundation there is no GetTopCard() in Pile.
            if(To.GetTopCard() == null)
            {
                return "Move " + Card.RankAsChar()+ Card.SuitAsChar() + " from " + From.PileToString() + " --> " + To.PileToString() + " - Score: " + "[" + Score + "]";
            }
            else
            {
                Card toCard = To.GetTopCard();
                string toCardString = toCard.RankAsChar()+toCard.SuitAsChar();
                return "Move " + Card.RankAsChar() + Card.SuitAsChar() + " from " + From.PileToString() +  " --> " + toCardString + " in " + To.PileToString() + " - Score: " + "[" + Score + "]";
            }
        }

    }
}
