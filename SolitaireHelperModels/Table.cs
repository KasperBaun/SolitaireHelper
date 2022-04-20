using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelperModels
{
    public class Table
    {
        public List<Pile> Tableaus { get; set; }
        public List<Pile> Foundations { get; set; }
        public Pile Talon { get; set; }   
        public Pile Stock { get; set; }
        private List<Move> MovesList { get; set; }

        public Table(Pile stock, Pile talon, Pile T1, Pile T2, Pile T3, Pile T4, Pile T5, Pile T6, Pile T7, Pile F1, Pile F2, Pile F3, Pile F4)
        {
            Stock = stock;
            Talon = talon;
            Tableaus.Add(T1);
            Tableaus.Add(T2);
            Tableaus.Add(T3);
            Tableaus.Add(T4);
            Tableaus.Add(T5);
            Tableaus.Add(T6);
            Tableaus.Add(T7);
            Foundations.Add(F1);
            Foundations.Add(F2);
            Foundations.Add(F3);
            Foundations.Add(F4);
        }

        public void PrintTable()
        {
            Console.WriteLine("Talon: \n");
            foreach(Card card in Talon.GetCards())
            {
                Console.WriteLine(card.ToString());
            }
        }

        public List<Move> GetPossibleMove (Pile from)
        {
            List<Move> moves = new List<Move>();
            
            //Checks all cards for possible moves if the pile is not empty and add them to the list of possible moves. 
            if(!from.IsEmpty() && from.GetTopCard().Visible)
            {
                foreach(Card card in from.GetCards())
                {
                    foreach(Pile pile in Tableaus)
                    {
                        if (!pile.IsEmpty() && pile.IsMovePossible(card))
                        {
                            Move move = new Move(from, pile, card);
                            moves.Add(move);
                        }
                    }

                    foreach (Pile pile in Foundations)
                    {
                        if (!pile.IsEmpty() && pile.IsMovePossible(card))
                        {
                            Move move = new Move(from, pile, card);
                            moves.Add(move);
                        }
                    }
                }
            }
                return moves;
        }

        public List<Move> GetAllPossibleMoves()
        {
            List<Move> allMoves = new List<Move> ();
            foreach(Pile pile in Foundations)
            {
                allMoves.AddRange(GetPossibleMove(pile));
            }

            foreach (Pile pile in Tableaus)
            {
                allMoves.AddRange(GetPossibleMove(pile));
            }

            allMoves.AddRange(GetPossibleMove(Talon));

            return allMoves;
        }
    }
}
