using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace SolitaireHelperModels
{
    [Serializable]
    public class Table
    {
        private readonly List<Pile> Tableaus;
        private readonly List<Pile> Foundations;
        private readonly Pile Talon;
        private readonly Pile Stock;
        private readonly List<int> PreviousMovesList;

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
            PreviousMovesList = new List<int>();
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
            PreviousMovesList = new List<int>();
        }
        private List<Move> GetPossibleMovesInPile(Pile fromPile)
        {
            List<Move> moves = new List<Move>();

            //Checks if the fromPile is empty
            if (fromPile.IsEmpty())
            {
                return moves;
            }

            // If the fromPile is a foundation, we can only move the topCard
            if(fromPile.IsFoundation())
            {
                Card topCard = fromPile.GetTopCard();
                // Can the visible card be moved to a tableau?
                foreach (Pile pile in Tableaus)
                {
                    if (pile.IsMovePossible(topCard))
                    {
                        int score = CalculateScore(topCard, fromPile, pile);
                        Move move = new Move(fromPile.PileToString(), pile.PileToString(), topCard, score);
                        int moveState = CreateTableStateHash(move);
                        if (!PreviousMovesList.Contains(moveState))
                        {
                            moves.Add(move);
                        }
                    }
                }
                return moves;
            }

            List<Card> cardsInFromPile = fromPile.GetCards();
            foreach (Card card in cardsInFromPile)
            {
                if (card.Visible == true)
                {

                    // Can the visible card be moved to a tableau?
                    foreach (Pile pile in Tableaus)
                    {
                        if (pile.IsMovePossible(card))
                        {
                            int score = CalculateScore(card, fromPile, pile);
                            Move move = new Move(fromPile.PileToString(), pile.PileToString(), card, score);
                            int moveState = CreateTableStateHash(move);
                            if (!PreviousMovesList.Contains(moveState))
                            {
                                moves.Add(move);
                            }
                        }
                    }
                    // Can the visible card be moved to a foundation?
                    foreach (Pile pile in Foundations)
                    {
                        if (pile.IsMovePossible(card))
                        {
                            int score = CalculateScore(card, fromPile, pile);
                            Move move = new Move(fromPile.PileToString(), pile.PileToString(), card, score);
                            int moveState = CreateTableStateHash(move);
                            if (!PreviousMovesList.Contains(moveState))
                            {
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
            List<Move> moves = new List<Move>();

            // See if there is any legal moves in talon
            moves.AddRange(GetPossibleMovesInPile(Talon));

            // Find all possible moves in Foundations (only top-cards)
            foreach (Pile pile in Foundations)
            {
                List<Move> pileMoves = GetPossibleMovesInPile(pile);
                moves.AddRange(pileMoves);
            }

            // Find all possible moves in the visible cards currently in Tableaus
            foreach (Pile pile in Tableaus)
            {
                List<Move> pileMoves = GetPossibleMovesInPile(pile);
                moves.AddRange(pileMoves);
            }

            // If no moves, turn 3 cards to Talon and find possible move
            if(moves.Count == 0)
            {
                DrawNewCardsToTalon();
                moves.AddRange(GetPossibleMovesInPile(Talon));
            }
          
            moves.RemoveAll(move => move.GetScore() == -1);
         
            return moves;
        }
        public Move FindNextMove()
        {
            /* This function is responsible for the primary logic in the solving of the solitaire game.
             * This is done as so:
             * 1. Check that the solitaire on the table is not solved by counting the amount of king-cards in the foundations with the method IsTableEmpty().
             * 2. Create a list of all possible moves from the current state of the table
             * 3. If that list contains valid moves, find the move with the highest score (ranked by CalculateScore() method)
             * 4. Return that move
             */

            // This accounts for the case where all the foundations are full and the solitaire is solved
            if (IsTableEmpty())
            {
                return null;
            }

            List<Move> possibleMoves = GetAllPossibleMoves();

            if (possibleMoves.Count > 0)
            {
                Move bestMove = GetBestMove(possibleMoves);
                return bestMove;
            }

            if(possibleMoves.Count == 0)
            {
                DrawNewCardsToTalon();
                FindNextMove();
            }

            return FindNextMove();
        }
        public int CreateTableStateHash(Move moveToBeMade)
        {
            int cardHashCodeSum = 0;
            List<Card> cardsOnTable = new List<Card>();
            cardsOnTable.AddRange(Stock.GetCards());
            cardsOnTable.AddRange(Talon.GetCards());
            cardsOnTable.AddRange(Tableaus[0].GetCards());
            cardsOnTable.AddRange(Tableaus[1].GetCards());
            cardsOnTable.AddRange(Tableaus[2].GetCards());
            cardsOnTable.AddRange(Tableaus[3].GetCards());
            cardsOnTable.AddRange(Tableaus[4].GetCards());
            cardsOnTable.AddRange(Tableaus[5].GetCards());
            cardsOnTable.AddRange(Tableaus[6].GetCards());
            cardsOnTable.AddRange(Foundations[0].GetCards());
            cardsOnTable.AddRange(Foundations[1].GetCards());
            cardsOnTable.AddRange(Foundations[2].GetCards());
            cardsOnTable.AddRange(Foundations[3].GetCards());
            
            foreach(Card card in cardsOnTable)
            {
                cardHashCodeSum += card.GetHashCode();
                //Console.WriteLine(card.GetHashCode());
            }
            
            Console.WriteLine("Stock card 0 hashcode: " + Stock.GetCards()[0].GetHashCode());
            Console.WriteLine("cardsOnTable HashCode: " + cardHashCodeSum);
            Console.WriteLine("moveToBeMade HashCode: " + moveToBeMade.GetHashCode());
            return cardHashCodeSum + moveToBeMade.GetHashCode();
        }
        public Move GetBestMove(List<Move> moves)
        {
            Move bestMove = moves[0];

            foreach (Move move in moves)
            {
                if (move.GetScore() > bestMove.GetScore())
                {
                    bestMove = move;
                }
            }

            return bestMove;
        }
        public void MakeMove(Move move)
        {
            int stateHash = CreateTableStateHash(move);
            PreviousMovesList.Add(stateHash);
            List<Card> CardsToMove = new List<Card>();
            // Find the correct pile in the table to make the move from and remove the cards
            Pile fromPile = GetPileFromType(GetPileTypeFromString(move.GetFrom()));
            // We make sure that if there are cards beneath the card to be moved,
            // that these cards move with
            int cardIndex = fromPile.GetCards().IndexOf(move.GetCard());
            int listCount = fromPile.GetCards().Count;
            CardsToMove.AddRange(fromPile.GetCards().GetRange(cardIndex, (listCount - cardIndex)));
            fromPile.RemoveCards(CardsToMove);
            
            // Add the cards to the pile we are moving to
            Pile toPile = GetPileFromType(GetPileTypeFromString(move.GetTo()));
            toPile.AddCards(CardsToMove);
            // If there are cards left in the from pile, and the top card is not visible, set it to visible
            if (fromPile.GetCards().Count > 0)
            {
                fromPile.GetTopCard().Visible = true;
            }

            return;
        }
        private int CalculateScore(Card card, Pile fromPile, Pile toPile)
        {
            if (card.Visible == false || card == null)
            {
                return 0;
            }

            // Test if ace can move to any of the Foundations
            if (card.Rank == 1 && toPile.IsFoundation())
            {
                return 95 + fromPile.GetCards().Count;
            }

            // Test if 2 can move to any of the Foundations
            if (card.Rank == 2 && fromPile.IsTableau() && toPile.IsFoundation())
            {
                return 85 + fromPile.GetCards().Count;
            }

            // Test if king can move to an empty Tableau
            if (card.Rank == 13 && fromPile.IsTableau() && toPile.IsTableau() && toPile.IsEmpty() && !fromPile.IsEmpty())
            {
                return 75 + fromPile.GetCards().Count;
            }
            // Test if card can move from Tableau to Foundation
            if (fromPile.IsTableau() && toPile.IsFoundation())
            {
                return fromPile.GetCards().Count + 40;
            }

            // Test if card can move from Talon to Foundation
            if (fromPile.Type == 12 && toPile.IsFoundation())
            {
                return fromPile.GetCards().Count + 40;
            }

            // Test if card can move from Tableau to Tableau
            if (card.Rank != 13 && fromPile.IsTableau() && toPile.IsTableau())
            {
                return fromPile.GetCards().Count + 30;
            }

            // Test if card can move from Talon to Tableau
            if (fromPile.Type == 12 && toPile.IsTableau())
            {
                return fromPile.GetCards().Count + 20;
            }

            // Test if card can move from Talon to any of the foundations
            if (fromPile.Type == 12 && toPile.IsFoundation())
            {
                return fromPile.GetCards().Count + 10;
            }

            return -1;
        }
        private void RefillStock()
        {
            Console.WriteLine("## Refilling stock ##");
            foreach (Card card in Talon.GetCards())
            {
                card.Visible = false;
            }
            Stock.AddCards(Talon.GetCards());
            Talon.GetCards().Clear();
        }
        public bool IsTableEmpty()
        {
            int kingsInFoundations = 0;
            foreach (Pile pile in Foundations)
            {
                if (pile.GetCards().Count > 0 && pile.GetTopCard().Rank == 13)
                {
                    kingsInFoundations++;
                }
            }

            if (kingsInFoundations == 4)
                return true;
            else
                return false;
        }
        public int CardsInStock()
        {
            return Stock.GetCards().Count;
        }
        public int CardsInTalon()
        {
            return Talon.GetCards().Count;
        }
        public bool DrawNewCardsToTalon()
        {

            if (CardsInStock() >= 3)
            {
                // Take 3 cards from stock, reverse them (flip) and put in talon
                List<Card> newCards = Stock.GetCards().GetRange(0, 3);
                //newCards.Reverse();
                Talon.AddCards(newCards);

                // Remove the 3 cards from stock
                Stock.RemoveCards(Stock.GetCards().GetRange(0, 3));

                // All cards in talon are invisible
                foreach (Card card in Talon.GetCards())
                {
                    card.Visible = false;
                }

                // Top card is visible
                Talon.GetTopCard().Visible = true;
                Console.WriteLine("Drawing new cards to talon: " + Talon.GetTopCard().ToString());
                return true;
            }

            // This accounts for algorithm rule ST-2 (Stock minimum rule)
            if (CardsInStock() < 3 && Talon.GetCards().Count + CardsInStock() >= 3)
            {
                // Take the cards from talon and put under stock
                RefillStock();
                DrawNewCardsToTalon();
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
            return cards + Talon.GetNumberOfCards() + Stock.GetNumberOfCards();
        }
        public void PrintTable()
        {
            Console.WriteLine("Table currently consists of:\n");
            Console.WriteLine("Talon:");
            if (Talon.GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Talon.GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nF1:");
            if (Foundations[0].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Foundations[0].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nF2:");
            if (Foundations[1].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Foundations[1].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nF3:");
            if (Foundations[2].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Foundations[2].GetCards())
            {
                Console.WriteLine(card.ToString());
            }

            Console.WriteLine("\nF4:");
            if (Foundations[3].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Foundations[3].GetCards())
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
        public int GetPileTypeFromString(string pile)
        {
            switch (pile)
            {
                case "Stock": return 0;
                case "T1": return 1;
                case "T2": return 2;
                case "T3": return 3;
                case "T4": return 4;
                case "T5": return 5;
                case "T6": return 6;
                case "T7": return 7;
                case "F1": return 8;
                case "F2": return 9;
                case "F3": return 10;
                case "F4": return 11;
                case "Talon": return 12;
                default: return -1;
            }
        }
    }
}
