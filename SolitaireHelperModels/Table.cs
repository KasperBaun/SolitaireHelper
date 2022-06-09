﻿using System;
using System.Collections.Generic;

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
            // Constructor for a custom table to be used by the image recognitition
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
        public Table()
        {
            // Constructor for a table with a fresh set of shuffled cards
            CardDeck CardDeck = new CardDeck();
            CardDeck.ShuffleDeck();
            Stock = new Pile() { Type = 0 };
            Tableaus = new List<Pile>();
            Foundations = new List<Pile>();
            Pile T1 = new Pile() { Type = 1 };
            Pile T2 = new Pile() { Type = 2 };
            Pile T3 = new Pile() { Type = 3 };
            Pile T4 = new Pile() { Type = 4 };
            Pile T5 = new Pile() { Type = 5 };
            Pile T6 = new Pile() { Type = 6 };
            Pile T7 = new Pile() { Type = 7 };
            Pile F1 = new Pile() { Type = 8 };
            Pile F2 = new Pile() { Type = 9 };
            Pile F3 = new Pile() { Type = 10 };
            Pile F4 = new Pile() { Type = 11 };
            Talon = new Pile() { Type = 12 };
            T1.AddCards(CardDeck.Deck.GetRange(0, 1));
            T1.GetTopCard().Visible = true;
            T2.AddCards(CardDeck.Deck.GetRange(1, 2));
            T2.GetTopCard().Visible = true;
            T3.AddCards(CardDeck.Deck.GetRange(3, 3));
            T3.GetTopCard().Visible = true;
            T4.AddCards(CardDeck.Deck.GetRange(6, 4));
            T4.GetTopCard().Visible = true;
            T5.AddCards(CardDeck.Deck.GetRange(10, 5));
            T5.GetTopCard().Visible = true;
            T6.AddCards(CardDeck.Deck.GetRange(15, 6));
            T6.GetTopCard().Visible = true;
            T7.AddCards(CardDeck.Deck.GetRange(21, 7));
            T7.GetTopCard().Visible = true;
            Stock.AddCards(CardDeck.Deck.GetRange(28, 24));
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
                        // Can the visible card be moved to a tableau?
                        foreach(Pile pile in Tableaus)
                        {
                            if (pile.IsMovePossible(card))
                            {
                                Move move = new Move(from, pile, card);
                                moves.Add(move);
                            }
                        }
                        // Can the visible card be moved to a foundation?
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

            // Find all possible moves in Talon
            if (CardsInStock() >= 3)
            {
                List<Move> talonMoves = GetPossibleMovesInPile(Talon);
                allMoves.AddRange(talonMoves);
            }

            // Find all possible moves in Foundations
            foreach (Pile pile in Foundations)
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

            // Find all possible moves in Tableaus
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

          
           
                
            // Remove all moves that are on the infinite-moves list and uneligible moves
            allMoves.RemoveAll(move => move.GetCard() == null || move.GetTo() == null || move.GetFrom() == null);
            allMoves.RemoveAll(move => MoveIsInfiniteLoop(move));

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
                // We found the card in the list of cards in the from pile that we want to move
                if (c.Rank == move.GetCard().Rank && c.Suit == move.GetCard().Suit)
                {
                    // We make sure that if there are cards beneath the card to be moved,
                    // that these cards move with
                    int cardIndex = move.GetFrom().GetCards().IndexOf(c);
                    int listCount = move.GetFrom().GetCards().Count;
                    CardsToMove.AddRange(move.GetFrom().GetCards().GetRange(cardIndex,(listCount - cardIndex)));
                    
                }
            }

            // Find the correct pile in the table to make the move from and remove the cards
            Pile fromPile = GetPileFromType(move.GetFrom().Type);
            fromPile.RemoveCards(CardsToMove);
            // Add the cards to the pile we are moving to
            Pile toPile = GetPileFromType(move.GetTo().Type);
            toPile.AddCards(CardsToMove);
            // If there are cards left in the from pile, and the top card is not visible, set it to visible
            if(fromPile.GetCards().Count > 0)
            {
                fromPile.GetTopCard().Visible = true;
            }
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
        public bool NewCardsInTalon()
        {
            // No cards in stock but more than 3 in Talon
            if(CardsInStock() == 0 && Talon.GetCards().Count > 3)
            {
                Talon.GetCards().Reverse();
                foreach (Card card in Talon.GetCards())
                {
                    card.Visible = false;
                }
                Stock.AddCards(Talon.GetCards());
                Talon.GetCards().Clear();
            }
            // This accounts for algorithm rule ST-2 (Stock minimum rule)
            if (CardsInStock() < 3 && Talon.GetCards().Count+CardsInStock() >= 3)
            {
                // Take the cards from talon and put under stock
                int cardsToTakeFromTalon = 3-CardsInStock();
                Stock.AddCards(Talon.GetCards().GetRange(0,cardsToTakeFromTalon));
                Talon.GetCards().RemoveRange(0, cardsToTakeFromTalon);
                NewCardsInTalon();
            }

            if (CardsInStock() >= 3)
            {
                // Take 3 cards from stock, reverse them (flip) and put in talon
                List<Card> newCards = Stock.GetCards().GetRange(Stock.GetCards().Count - 3, 3);
                newCards.Reverse();
                Talon.AddCards(newCards);

                // Remove the 3 cards from stock
                Stock.RemoveCards(Stock.GetCards().GetRange(Stock.GetCards().Count - 3, 3));

                // All cards in talon are invisible
                foreach(Card card in Talon.GetCards())
                {
                    card.Visible = false;
                }

                // Top card is visible
                Talon.GetCards()[Talon.GetCards().Count-1].Visible = true;
                return true;
            }
            
            return false;
            
        }
        public int CardsInTable()
        {
            // Returns the amount of cards on the table (in foundations and tableaus - NOT in the stock and talon)
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
            Console.WriteLine("Table currently consists of:\n");
            Console.WriteLine("Talon:");
            if (Talon.GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach(Card card in Talon.GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nT1:");
            if (Tableaus[0].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[0].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nT2:");
            if (Tableaus[1].GetCards().Count == 0)
                Console.WriteLine("Empty");
            if (Tableaus[1].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[1].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nT3:");
            if (Tableaus[2].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[2].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nT4:");
            if (Tableaus[3].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[3].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nT5:");
            if (Tableaus[4].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[4].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nT6:");
            if (Tableaus[5].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[5].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nT7:");
            if (Tableaus[6].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[6].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nStock");
            if (Stock.GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Stock.GetCards())
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("\n\n");
        }
        public Pile GetPileFromType(int type)
        {
            switch (type)
            {
                case 0: return Stock;
                case 1: return Tableaus[0];
                case 2: return Tableaus[1];
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
