using System;
using System.Collections.Generic;

namespace SolitaireHelperModels
{
    public class Game
    {
        public string Id { get; set; }
        public string Player { get; set; }
        public string Date { get; set; }
        public string GameType { get; set; }
        public Table Table { get; set; }
        public bool GameIsFinished { get; set; }

        public Game() {

        }

        public void TestGame()
        {
            GameIsFinished = false;
            CardDeck CardDeck = new CardDeck();
            CardDeck.ShuffleDeck();
            Pile F1 = new Pile(){ Type = 8 };
            Pile F2 = new Pile(){ Type = 9 };
            Pile F3 = new Pile(){ Type = 10 };
            Pile F4 = new Pile(){ Type = 11 };
            Pile T1 = new Pile(){ Type = 1 }; T1.PushCards(CardDeck.Deck.GetRange(0, 1)); T1.GetCards().FindLast(c => c.Rank != 0).Visible = true;
            Pile T2 = new Pile(){ Type = 2 }; T2.PushCards(CardDeck.Deck.GetRange(1, 2)); T2.GetCards().FindLast(c => c.Rank != 0).Visible = true;
            Pile T3 = new Pile(){ Type = 3 }; T3.PushCards(CardDeck.Deck.GetRange(3, 3)); T3.GetCards().FindLast(c => c.Rank != 0).Visible = true;
            Pile T4 = new Pile(){ Type = 4 }; T4.PushCards(CardDeck.Deck.GetRange(6, 4)); T4.GetCards().FindLast(c => c.Rank != 0).Visible = true;
            Pile T5 = new Pile(){ Type = 5 }; T5.PushCards(CardDeck.Deck.GetRange(10, 5)); T5.GetCards().FindLast(c => c.Rank != 0).Visible = true;
            Pile T6 = new Pile(){ Type = 6 }; T6.PushCards(CardDeck.Deck.GetRange(15, 6)); T6.GetCards().FindLast(c => c.Rank != 0).Visible = true;
            Pile T7 = new Pile(){ Type = 7 }; T7.PushCards(CardDeck.Deck.GetRange(21, 7)); T7.GetCards().FindLast(c => c.Rank != 0).Visible = true;
            Pile Talon = new Pile(){ Type = 12 }; Talon.PushCards(CardDeck.Deck.GetRange(28, 3));
            foreach (Card card in Talon.GetCards())
            {
                card.Visible = true;
            }
            Pile Stock = new Pile(){ Type = 0 }; Stock.PushCards(CardDeck.Deck.GetRange(31, 21));
            Table = new Table(Stock, Talon, T1, T2, T3, T4, T5, T6, T7, F1, F2, F3, F4);
            //Table.PrintTable();
            for(int i = 0; i < 10; i++)
            {
                FindNextMove();
            }
            /*while(!GameIsFinished)
            {
                AnalyzeTable();
            }*/
        }

        private void FindNextMove()
        {
            List<Move> possibleMoves;
            possibleMoves = Table.GetAllPossibleMoves();
            if(possibleMoves.Count > 0)
            {
                Move highestMove = Table.GetBestMove(possibleMoves);
                if(highestMove != null)
                {
                    Console.WriteLine("Best move\n" + highestMove.ToString());
                }
                else
                {
                    Console.WriteLine("ERROR!");
                }
            }
            else
            {
                Console.WriteLine("No possible moves!!!");
            }
        }
    }
}