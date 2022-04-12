using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelper.Models
{
    public class Move
    {
        public Pile From { get; set; }
        public Pile To { get; set; }
        public Card Card { get; set; }
        protected int Score { get; set; }

        public Move(Pile from, Pile to, Card card)
        {
            From = from;
            To = to;
            Card = card;
            Score = CalculateScore();
        }

        private int CalculateScore()
        {

        }

        public bool IsReverseMove(Move oldMove)
        {
            if(oldMove == null) { return false; }

            Card to = To.GetTopCard();
            Card from = From.GetTopCard();
            if(oldMove.From.IsEqual(to) && oldMove.To.IsEqual(from)  && oldMove.Card == Card)
            {
                return true;
            }
            return false;
        }

    }
}
