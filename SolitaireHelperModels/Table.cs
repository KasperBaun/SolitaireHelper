﻿using System;
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
        private List<Move> PreviousMovesList { get; set; }

        public Table(Pile stock, Pile talon, Pile T1, Pile T2, Pile T3, Pile T4, Pile T5, Pile T6, Pile T7, Pile F1, Pile F2, Pile F3, Pile F4)
        {
            Tableaus = new List<Pile>();
            Foundations = new List<Pile>();
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
            Console.WriteLine("Talon:");
            foreach(Card card in Talon.GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("T1:");
            foreach (Card card in Tableaus[0].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("T2:");
            foreach (Card card in Tableaus[1].GetCards())
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("T3:");
            foreach (Card card in Tableaus[2].GetCards())
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("T4:");
            foreach (Card card in Tableaus[3].GetCards())
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("T5:");
            foreach (Card card in Tableaus[4].GetCards())
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("T6:");
            foreach (Card card in Tableaus[5].GetCards())
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("T7:");
            foreach (Card card in Tableaus[6].GetCards())
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("Stock");
            foreach (Card card in Stock.GetCards())
            {
                Console.WriteLine(card.ToString());
            }
        }
        public List<Move> GetPossibleMove (Pile from)
        {
            List<Move> moves = new List<Move>();
            
            //Checks all cards for possible moves if the pile is not empty and add them to the list of possible moves. 
            if(from.GetCards().Count>=1 && from.GetTopCard().Visible)
            {
                foreach(Card card in from.GetCards())
                {
                    foreach(Pile pile in Tableaus)
                    {
                        if (pile.GetCards().Count>=1 && pile.IsMovePossible(card))
                        {
                            Move move = new Move(from, pile, card);
                            moves.Add(move);
                        }
                    }

                    foreach (Pile pile in Foundations)
                    {
                        if (pile.GetCards().Count >= 1 && pile.IsMovePossible(card))
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
        public Move GetBestMove(List<Move> allPossibleMoves)
        {
            Move bestMove = null;
            if (allPossibleMoves.Count == 0)
            {
                return new Move(null, null, null);
            }

            foreach (Move move in allPossibleMoves)
            {
                bool addToList = true;
                foreach (Move lastMove in PreviousMovesList)
                {
                    if (move.IsReverseMove(lastMove))
                    {
                        addToList = false;
                    }
                }
                if (bestMove == null && addToList)
                {
                    bestMove = move;
                }
                else if (addToList && (move.GetScore() > bestMove.GetScore()))
                {
                    bestMove = move;
                }

            }
            return bestMove;
        }
        public void MakeMove(Move move, Card card)
        {
            if (PreviousMovesList.Count > 5)
            {
                PreviousMovesList.RemoveAt(0);
            }
            if (move.Card == null || move.GetScore() == -1 || move.GetScore() == 5)
            {
                Talon.GetCards().Add(card);
            }
            else
            {
                PreviousMovesList.Add(move);
                move.MoveCard();
            }
        }
    }
}
