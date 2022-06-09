using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelperModels
{
    public class Move
    {
        private string From;
        private string To;
        private Card Card;
        private int Score;

        public Move(string from, string to, Card card, int score)
        {
            From = from;
            To = to;
            Card = card;
            Score = score;
        }
       
        public int GetScore()
        {
            return Score;
        }
        public string GetFrom()
        {
            return From;
        }
        public string GetTo()
        {
            return To;
        }
        public Card GetCard()
        {
            return Card;
        }
        public override string ToString()
        {
            /*
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
            */

            return "Move " + Card.RankAsChar() + Card.SuitAsChar() + " from " + From + " --> " + To + " - Score: " + "[" + Score + "]";
        }

    }
}
