using System;
using System.Collections.Generic;

namespace SolitaireHelperModels
{
    public class Table
    {
        private readonly List<Pile> Tableaus;
        private readonly List<Pile> Foundations;
        private readonly Pile Talon;
        private readonly Pile Stock;
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
        }
        public Table(Table table)
        {
            // Copy constructor that deep-clones the object
            Tableaus = new List<Pile>();
            Foundations = new List<Pile>();
            Stock = new Pile() { Type = 0 };
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
            foreach(Card c in table.GetPileFromType(0).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                Stock.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(1).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                T1.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(2).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                T2.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(3).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                T3.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(4).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                T4.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(5).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                T5.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(6).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                T6.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(7).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                T7.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(8).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                F1.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(9).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                F2.GetCards().Add(card);
            }
            foreach (Card c in table.GetPileFromType(10).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                F3.GetCards().Add(card);
            }
            foreach (Card c in table.GetPileFromType(11).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                F4.GetCards().Add(card);
            }

            foreach (Card c in table.GetPileFromType(12).GetCards())
            {
                Card card = new Card(c.Suit, c.Rank, c.Visible);
                Talon.GetCards().Add(card);
            }
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
        private List<Move> GetPossibleMovesInPile(Pile fromPile)
        {
            List<Move> moves = new List<Move>();

            //Checks if the fromPile is empty
            if (fromPile.IsEmpty())
            {
                return moves;
            }

            Card topCard = fromPile.GetTopCard();
            // If the fromPile is a foundation, we can only move the topCard
            if(fromPile.IsFoundation())
            {
                // Can the visible card be moved to a tableau?
                foreach (Pile pile in Tableaus)
                {
                    if (pile.IsMovePossible(topCard))
                    {
                        int score = CalculateScore(topCard, fromPile, pile);
                        Move move = new Move(fromPile.PileToString(), pile.PileToString(), topCard, score);
                        moves.Add(move);
                    }
                }
                return moves;
            }
            
            // Can the top-card be moved to a foundation?
            foreach (Pile pile in Foundations)
            {
                if (pile.IsMovePossible(topCard))
                {
                    //Console.WriteLine("topCard = " + topCard.FullToString());
                    int score = CalculateScore(topCard, fromPile, pile);
                    Move move = new Move(fromPile.PileToString(), pile.PileToString(), topCard, score);
                    moves.Add(move);
                    //Console.WriteLine("Fra tableau til foundation score: " + move.GetScore());
                }
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
                            moves.Add(move);
                        }
                    }                    
                }
            }

            return moves;
        }
        public List<Move> GetAllPossibleMoves()
        {
            List<Move> moves = new List<Move>();

            // Find moves in Talon
            if(!(CardsInStock()+CardsInTalon() == 3 && CardsInStock() < 3))
            {
                moves.AddRange(GetPossibleMovesInPile(Talon));
            }

            // Find moves in Foundations (only top-cards)
            foreach (Pile pile in Foundations)
            {
                moves.AddRange(GetPossibleMovesInPile(pile));
            }

            // Find moves in Tableaus
            foreach (Pile pile in Tableaus)
            {
                moves.AddRange(GetPossibleMovesInPile(pile));
            }
            
            return moves;
        }
        public Table MakeMove(Move move)
        {
            List<Card> CardsToMove = new List<Card>();
            // Find the correct pile in the table to make the move from and remove the cards
            Pile fromPile = GetPileFromType(GetPileTypeFromString(move.GetFrom()));
            // We make sure that if there are cards beneath the card to be moved,
            // that these cards move with

            int cardIndex = fromPile.GetCards().FindIndex(c => c.Rank == move.GetCard().Rank && c.Suit == move.GetCard().Suit && c.Visible == move.GetCard().Visible);
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

            return this;
        }
        private int CalculateScore(Card card, Pile fromPile, Pile toPile)
        {
            int score = 0;
            if (card.Visible == false || card == null)
            {
                return 0;
            }
            int facedownCards = 0;
            foreach(Card c in fromPile.GetCards())
            {
                if (!c.Visible)
                {
                    facedownCards++;
                }
            }

            if (fromPile.GetCards().Count > 1)
            {
                int cardIndex = fromPile.GetCards().FindIndex(c => c.Rank == card.Rank && c.Suit == card.Suit && c.Visible == card.Visible);
                if (cardIndex >= 1)
                {
                    if (fromPile.GetCards()[cardIndex - 1].Visible == false)
                    {
                        score += 30;
                    }
                }
            }

          
            // Test if ace can move to any of the Foundations
            if (card.Rank == 1 && toPile.IsFoundation())
            {
                return score += 95 + facedownCards;
            }

            // Test if card can move to any of the Foundations
            if (toPile.IsFoundation())
            {
                return score += 85 + facedownCards;
            }

            // Test if king can move to an empty Tableau
            if (card.Rank == 13 && toPile.IsTableau() && toPile.IsEmpty())
            {
                if (fromPile.GetCards().Count > 1)
                {
                    int cardIndex = fromPile.GetCards().FindIndex(c => c.Rank == card.Rank && c.Suit == card.Suit && c.Visible == card.Visible);
                    if (cardIndex >= 1)
                    {
                        if (fromPile.GetCards()[cardIndex - 1].Visible == true)
                        {
                            if (fromPile.IsFoundation())
                            {
                                return score = 5;
                            }
                            return score = 20;
                        }

                        if (fromPile.GetCards()[cardIndex - 1].Visible == false)
                        {
                            return score += 75 + facedownCards;
                        }
                    }
                }
                return 0;
            }


            // Test if card can move from Tableau to Tableau
            if (card.Rank != 13 && fromPile.IsTableau() && toPile.IsTableau())
            {
                return score += facedownCards + 20;
            }

            // Test if card can move from Talon to Foundation
            if (fromPile.Type == 12 && toPile.IsFoundation())
            {
                return score += facedownCards + 20;
            }


            // Test if card can move from Talon to Tableau
            if (fromPile.Type == 12 && toPile.IsTableau())
            {
                return score += facedownCards + 15;
            }

            // Test if card can move from Foundation to Tableau
            if(fromPile.IsFoundation() && toPile.IsTableau())
            {
                if(CardsInFoundations() > 30)
                {
                    return 50;
                }
                if(CardsInStock() == 0)
                {
                    return score += 15;
                }

                return 15;
            }

            return score;
        }
        public int DrawNewCardsToTalon()
        {
            if (CardsInStock() >= 3)
            {
                // Take 3 cards from stock, reverse them (flip) and put in talon
                List<Card> newCards = Stock.GetCards().GetRange(0, 3);
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
                return 0;
            }

            // This accounts for algorithm rule ST-2 (Stock minimum rule)
            if (CardsInStock() < 3 && Talon.GetCards().Count + CardsInStock() >= 3)
            {
                // Take the cards from talon and put under stock
                if(CardsInStock() == 0 && CardsInTalon() == 3)
                {
                return 1;
                }
                RefillStock();
            }
            return 1;
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
        private int CardsInFoundations()
        {
            int sum = 0;
            foreach(Card card in Foundations[0].GetCards())
            {
                sum++;
            }
            foreach (Card card in Foundations[1].GetCards())
            {
                sum++;
            }
            foreach (Card card in Foundations[2].GetCards())
            {
                sum++;
            }
            foreach (Card card in Foundations[3].GetCards())
            {
                sum++;
            }
            return sum;
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
        public bool IsEqual(Table otherTable)
        {
            //Console.WriteLine("Checking if equal");
            
            // Check Stock is the same
            if(CardsInStock() != otherTable.CardsInStock())
            {
                //Console.WriteLine("CardsInStock not the same");
                return false;
            }

            // Check if Talon is the same
            
            //Pile talonCardsToCompare = otherTable.GetPileFromType(12);
            
            if(CardsInTalon() != otherTable.CardsInTalon())
            {
                //Console.WriteLine("CardsInTalon not the same");
                return false;
            }
            if(CardsInTalon() > 0)
            {
                if(!GetPileFromType(12).GetTopCard().IsEqual(otherTable.GetPileFromType(12).GetTopCard()))
                {
                    //Console.WriteLine("Topcard in Talon not the same");
                    return false;
                }
            }

            // Check T1
           
            //Pile t1ToCompare = otherTable.GetPileFromType(1);
            
            if(GetPileFromType(1).GetCards().Count != otherTable.GetPileFromType(1).GetCards().Count)
            {
                //Console.WriteLine("T1 count not the same");
                return false;
            }
            if(GetPileFromType(1).GetCards().Count > 0)
            {
                foreach(Card card in GetPileFromType(1).GetCards())
                {
                    if(!otherTable.GetPileFromType(1).GetCards().Exists(c => c.IsEqual(card)))
                    {
                        //Console.WriteLine("T1 cards not the same");
                        return false;
                    }
                }
            }

            // Check T2

            //Pile t2ToCompare = otherTable.GetPileFromType(2);
            
            if (GetPileFromType(2).GetCards().Count != otherTable.GetPileFromType(2).GetCards().Count)
            {
                //Console.WriteLine("T2 count not the same");
                return false;
            }
            if (GetPileFromType(2).GetCards().Count > 0)
            {
                foreach (Card card in GetPileFromType(2).GetCards())
                {
                    if (!otherTable.GetPileFromType(2).GetCards().Exists(c => c.IsEqual(card)))
                    {
                        //Console.WriteLine("T2 cards not the same");
                        return false;
                    }
                }
            }

            // Check T3
            
            //Pile t3ToCompare = otherTable.GetPileFromType(3);
            
            if (GetPileFromType(3).GetCards().Count != otherTable.GetPileFromType(3).GetCards().Count)
            {
                //Console.WriteLine("T3 count not the same");
                return false;
            }
            if (GetPileFromType(3).GetCards().Count > 0)
            {
                foreach (Card card in GetPileFromType(3).GetCards())
                {
                    if (!otherTable.GetPileFromType(3).GetCards().Exists(c => c.IsEqual(card)))
                    {
                        //Console.WriteLine("T3 cards not the same");
                        return false;
                    }
                }
            }

            // Check T4

            //Pile t4ToCompare = otherTable.GetPileFromType(4);
            
            if (GetPileFromType(4).GetCards().Count != otherTable.GetPileFromType(4).GetCards().Count)
            {
                //Console.WriteLine("T4 count not the same");
                return false;
            }
            if (GetPileFromType(4).GetCards().Count > 0)
            {
                foreach (Card card in GetPileFromType(4).GetCards())
                {
                    if (!otherTable.GetPileFromType(4).GetCards().Exists(c => c.IsEqual(card)))
                    {
                        //Console.WriteLine("T4 cards not the same");
                        return false;
                    }
                }
            }

            // Check T5
            
            
            //Pile t5ToCompare = otherTable.GetPileFromType(5);
            
            if (!(GetPileFromType(5).GetCards().Count == otherTable.GetPileFromType(5).GetCards().Count))
            {
                //Console.WriteLine("T5 count not the same");
                return false;
            }
            if (GetPileFromType(5).GetCards().Count > 0)
            {
                foreach (Card card in GetPileFromType(5).GetCards())
                {
                    if (!otherTable.GetPileFromType(5).GetCards().Exists(c => c.IsEqual(card)))
                    {

                        //Console.WriteLine("T5 cards not the same");
                        return false;
                    }
                }
            }

            // Check T6
            
            //Pile t6ToCompare = otherTable.GetPileFromType(6);
            
            if (!(GetPileFromType(6).GetCards().Count == otherTable.GetPileFromType(6).GetCards().Count))
            {
                //Console.WriteLine("T6 count not the same");
                return false;
            }
            if (GetPileFromType(6).GetCards().Count > 0)
            {
                foreach (Card card in GetPileFromType(6).GetCards())
                {
                    if (!otherTable.GetPileFromType(6).GetCards().Exists(c => c.IsEqual(card)))
                    {
                        //Console.WriteLine("T6 cards not the same");
                        return false;
                    }
                }
            }

            // Check T7
            
            //Pile t7ToCompare = otherTable.GetPileFromType(7);
            
            
            if (!(GetPileFromType(7).GetCards().Count == otherTable.GetPileFromType(7).GetCards().Count))
            {
                //Console.WriteLine("T7 count not the same");
                return false;
            }
            if (GetPileFromType(7).GetCards().Count > 0)
            {
                foreach (Card card in GetPileFromType(7).GetCards())
                {
                    if (!otherTable.GetPileFromType(7).GetCards().Exists(c => c.IsEqual(card)))
                    {
                        //Console.WriteLine("T7 cards not the same");
                        return false;
                    }
                }
            }

            // Check F1
            //Pile f1ToCompare = otherTable.GetPileFromType(8);
            if (!GetPileFromType(8).IsEmpty())
            {
                if (!otherTable.GetPileFromType(8).IsEmpty())
                {
                    if (!GetPileFromType(8).GetTopCard().IsEqual(otherTable.GetPileFromType(8).GetTopCard()))
                    {
                        //Console.WriteLine("F1 topcard not the same");
                        return false;
                    }
                }
            }

            // Check F2
            //Pile f2ToCompare = otherTable.GetPileFromType(9);
            if (!GetPileFromType(9).IsEmpty())
            {
                if (!otherTable.GetPileFromType(9).IsEmpty())
                {
                    if (!GetPileFromType(9).GetTopCard().IsEqual(otherTable.GetPileFromType(9).GetTopCard()))
                    {
                        //Console.WriteLine("F2 topcard not the same");
                        return false;
                    }
                }
            }

            // Check F3
            //Pile f3ToCompare = otherTable.GetPileFromType(10);
            if (!GetPileFromType(10).IsEmpty())
            {
                if (!otherTable.GetPileFromType(10).IsEmpty())
                {
                    if (!GetPileFromType(10).GetTopCard().IsEqual(otherTable.GetPileFromType(10).GetTopCard()))
                    {
                        //Console.WriteLine("F3 topcard not the same");
                        return false;
                    }
                }
            }

            // Check F4
            // Pile f4ToCompare = otherTable.GetPileFromType(11);
            if (!GetPileFromType(11).IsEmpty())
            {
                if (!otherTable.GetPileFromType(11).IsEmpty())
                {
                    if (!GetPileFromType(11).GetTopCard().IsEqual(otherTable.GetPileFromType(11).GetTopCard()))
                    {
                        //Console.WriteLine("F4 topcard not the same");
                        return false;
                    }
                }
            }

            return true;
        }
        public void PrintTable()
        {
            Console.WriteLine("Table currently consists of:\n");
          
            Console.WriteLine("\nF1:");
            if (Foundations[0].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Foundations[0].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nF2:");
            if (Foundations[1].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Foundations[1].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nF3:");
            if (Foundations[2].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Foundations[2].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nF4:");
            if (Foundations[3].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Foundations[3].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nT1:");
            if (Tableaus[0].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[0].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nT2:");
            if (Tableaus[1].GetCards().Count == 0)
                Console.WriteLine("Empty");
            if (Tableaus[1].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[1].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nT3:");
            if (Tableaus[2].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[2].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nT4:");
            if (Tableaus[3].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[3].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nT5:");
            if (Tableaus[4].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[4].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nT6:");
            if (Tableaus[5].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[5].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nT7:");
            if (Tableaus[6].GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Tableaus[6].GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nTalon:");
            if (Talon.GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Talon.GetCards())
            {
                Console.WriteLine(card.FullToString());
            }

            Console.WriteLine("\nStock");
            if (Stock.GetCards().Count == 0)
                Console.WriteLine("Empty");
            foreach (Card card in Stock.GetCards())
            {
                Console.WriteLine(card.FullToString());
            }
            Console.WriteLine("\n\n");
        }
        public override string ToString()
        {
            string tableString = "";
            if ((Talon.GetCards().Count == 0))
            {
                tableString += "T-E,";
            }
            if (!(Talon.GetCards().Count == 0))
            {
                foreach (Card card in Talon.GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Foundations[0].GetCards().Count == 0)
            {
                tableString += "F1-E,";
            }
            if (!(Foundations[0].GetCards().Count == 0))
            {
                foreach (Card card in Foundations[0].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Foundations[1].GetCards().Count == 0)
            {
                tableString += "F2-E,";
            }

            if (!(Foundations[1].GetCards().Count == 0))
            {
                foreach (Card card in Foundations[1].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Foundations[2].GetCards().Count == 0)
            {
                tableString += "F3-E,";
            }

            if (!(Foundations[2].GetCards().Count == 0))
            {
                foreach (Card card in Foundations[2].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Foundations[3].GetCards().Count == 0)
            {
                tableString += "F3-E,";
            }

            if (!(Foundations[3].GetCards().Count == 0))
            {
                foreach (Card card in Foundations[3].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Tableaus[0].GetCards().Count == 0)
            {
                tableString += "T1-E,";
            }

            if (!(Tableaus[0].GetCards().Count == 0))
            {
                foreach (Card card in Tableaus[0].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Tableaus[1].GetCards().Count == 0)
            {
                tableString += "T2-E,";
            }

            if (!(Tableaus[1].GetCards().Count == 0))
            {
                foreach (Card card in Tableaus[1].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Tableaus[2].GetCards().Count == 0)
            {
                tableString += "T3-E,";
            }

            if (!(Tableaus[2].GetCards().Count == 0))
            {
                foreach (Card card in Tableaus[2].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Tableaus[3].GetCards().Count == 0)
            {
                tableString += "T4-E,";
            }

            if (!(Tableaus[3].GetCards().Count == 0))
            {
                foreach (Card card in Tableaus[3].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Tableaus[4].GetCards().Count == 0)
            {
                tableString += "T5-E,";
            }

            if (!(Tableaus[4].GetCards().Count == 0))
            {
                foreach (Card card in Tableaus[4].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Tableaus[5].GetCards().Count == 0)
            {
                tableString += "T6-E,";
            }

            if (!(Tableaus[5].GetCards().Count == 0))
            {
                foreach (Card card in Tableaus[5].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Tableaus[6].GetCards().Count == 0)
            {
                tableString += "T7-E,";
            }

            if (!(Tableaus[6].GetCards().Count == 0))
            {
                foreach (Card card in Tableaus[6].GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }

            if (Stock.GetCards().Count == 0)
            {
                tableString += "S-E,";
            }

            if (!(Stock.GetCards().Count == 0))
            {
                foreach (Card card in Stock.GetCards())
                {
                    tableString += card.ToString() + ",";
                }
            }
            return tableString;
        }
    }
}
