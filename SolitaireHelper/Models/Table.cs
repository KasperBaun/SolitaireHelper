using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelper.Models
{
    public class Table
    {
        public List<Pile> Tableaus { get; set; }
        public List<Pile> Foundations { get; set; }
        public Pile Talon { get; set; }   
        public Pile Stock { get; set; }
        public CardDeck Deck { get; set; }
        private List<Move> LastMoveList { get; set; }

        public Table()
        {
            for(int i=1; i<8; i++)
            {
                Pile pile = new Pile(0);
                pile.Type = i;
                Tableaus.Add(pile);
                if (i < 4)
                {
                    pile.Type = i + 7;
                    Foundations.Add(pile);
                }
            }
            Stock = new Pile(0);
            Stock.Type = 0;
            Talon = new Pile(0);
            Talon.Type = 12;
        }

        public void Move(Move move, Card card)
        {
            if(LastMoveList.Count > 5)
            {
                LastMoveList.RemoveAt(0);
            }
            LastMoveList.Add(move);
            if(move.Card == null || move.GetScore() == -1 || move.GetScore() == 5)
            {
                Talon.PushCard(card);
            }
            else
            {
                move.
            }
        }

    }
}
