using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelperModels
{
    public class Table
    {
        private readonly List<Pile> Tableaus;
        private readonly List<Pile> Foundations;
        private readonly Pile Talon;
        private readonly Pile Stock;
        private readonly List<Move> PreviousMovesList;

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
            PreviousMovesList = new List<Move>();
        }

        public List<Move> GetPossibleMovesInPile (Pile from)
        {
            List<Move> moves = new List<Move>();
            
            //Checks all cards for possible moves if the pile is not empty and add them to the list of possible moves. 
            if(!from.IsEmpty())
            {
                foreach(Card card in from.GetCards())
                {
                    if(card.Visible == true)
                    {
                        foreach(Pile pile in Tableaus)
                        {
                            if (pile.IsMovePossible(card))
                            {
                                Move move = new Move(from, pile, card);
                                moves.Add(move);
                            }
                        }

                        foreach (Pile pile in Foundations)
                        {
                            if (pile.IsMovePossible(card))
                            {
                                Move move = new Move(from, pile, card);
                                moves.Add(move);
                            }
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
                if (pile.IsEmpty())
                {
                    continue;
                }
                else
                {
                    List<Move> pileMoves = GetPossibleMovesInPile(pile);
                    allMoves.AddRange(pileMoves);
                }
            }

            foreach (Pile pile in Tableaus)
            {
                if (pile.IsEmpty())
                {
                    continue;
                }
                else
                {
                    List<Move> pileMoves = GetPossibleMovesInPile(pile);
                    allMoves.AddRange(pileMoves);
                }
            }
            List<Move> talonMoves = GetPossibleMovesInPile(Talon);
            allMoves.AddRange(talonMoves);

            allMoves.RemoveAll(move => move.GetCard() == null || move.GetTo() == null || move.GetFrom() == null);

            allMoves.RemoveAll(move => MoveIsInfiniteLoop(move));

            /*
            if (PreviousMovesList != null && PreviousMovesList.Count > 0)
            {
                foreach(Move move in allMoves)
                {
                    if(MoveIsInfiniteLoop(move))
                        allMoves.Remove(move);
                }
            }
            */

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
        public void MakeMove(Move move)
        {
            PreviousMovesList.Add(move);    
            List<Card> CardsToMove = new List<Card>();
            foreach (Card c in move.GetFrom().GetCards())
            {
                if (c.Rank == move.GetCard().Rank && c.Suit == move.GetCard().Suit)
                {
                    int cardIndex = move.GetFrom().GetCards().IndexOf(c);
                    int listCount = move.GetFrom().GetCards().Count;
                    CardsToMove.AddRange(move.GetFrom().GetCards().GetRange(cardIndex,(listCount - cardIndex)));
                    // Check if the card beneath the moved card is not visible - if it is not visible, change it
                    if(cardIndex != 0 && TypeToPile(move.GetFrom().Type).GetCards()[cardIndex-1] != null)
                    {
                        TypeToPile(move.GetFrom().Type).GetCards()[cardIndex - 1].Visible = true;
                    }
                }
            }
            
            TypeToPile(move.GetFrom().Type).PopCards(CardsToMove);
            TypeToPile(move.GetTo().Type).PushCards(CardsToMove);
            return;
        }
        public bool MoveIsInfiniteLoop(Move move)
        {
            foreach(Move m in PreviousMovesList)
            {
                if(m.GetCard().Rank == move.GetCard().Rank && m.GetCard().Suit == move.GetCard().Suit && m.GetFrom().Type == move.GetFrom().Type && m.GetTo().Type == move.GetTo().Type)
                {
                    return true;
                }
            }
            if(PreviousMovesList.Count >= 5)
                PreviousMovesList.RemoveAt(0);
            return false;
        }
        public bool IsTableEmpty()
        {
            int cardsInFoundations = 0;
            foreach(Pile pile in Foundations)
            {
                cardsInFoundations += pile.GetCards().Count;
            }
            
            if(cardsInFoundations == 52) 
                return true; 
            else 
                return false;
        }
        public int CardsInStock()
        {
            return Stock.GetCards().Count;
        }
        public bool ChangeCardsInTalon()
        {
            if (CardsInStock() > 0)
            {
                List<Card> oldTalonCards = Talon.GetCards();
                Talon.GetCards().Clear();
                if (Stock.GetCards().Count >= 3)
                {
                    List<Card> newTalonCards = Stock.GetCards().GetRange(0, 3);
                    foreach (Card card in newTalonCards)
                    {
                        card.Visible = true;
                    }
                    Talon.PushCards(newTalonCards);

                }
                else
                {
                    List<Card> newTalonCards = Stock.GetCards();
                    foreach (Card card in newTalonCards)
                    {
                        card.Visible = true;
                    }
                    Talon.PushCards(newTalonCards);
                }
                foreach (Card card in oldTalonCards)
                {
                    card.Visible = false;
                }
                Stock.PushCards(oldTalonCards);
                //Talon.PrintPile();
                return true;
            }
            // No cards in stock remaining
            return false;
        }
        // For debugging purposes
        public int CardsInTable()
        {
            int cards = 0;
            foreach (Pile pile in Foundations)
            {
                cards += pile.GetNumberOfCards();
            }
            foreach (Pile pile in Tableaus)
            {
                cards += pile.GetNumberOfCards();
            }
            return cards+ Talon.GetNumberOfCards() + Stock.GetNumberOfCards();
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
        private Pile TypeToPile(int type)
        {
            switch (type)
            {
                case 0: return this.Stock;
                case 1: return this.Tableaus[0];
                case 2: return this.Tableaus[1];
                case 3: return Tableaus[2];
                case 4: return Tableaus[3];
                case 5: return Tableaus[4];
                case 6: return Tableaus[5];
                case 7: return Tableaus[6];
                case 8: return Foundations[0];
                case 9: return Foundations[1];
                case 10: return Foundations[2];
                case 11: return Foundations[3];
                case 12: return Talon;
                default: return null;
            }
        }
    }
}
