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
            for(int i=0; i<7; i++)
            {
                Pile pile = new Pile(0);
                Tableaus.Add(pile);
                if (i < 4)
                {
                    Foundations.Add(pile);
                }
            }
            Talon = new Pile(0);
            Stock = new Pile(0);
        }

    }
}
