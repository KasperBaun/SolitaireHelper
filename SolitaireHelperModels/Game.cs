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
            Pile F1 = new Pile();
            Pile F2 = new Pile();
            Pile F3 = new Pile();
            Pile F4 = new Pile();
            Pile T1 = new Pile(); T1.PushCards(CardDeck.Deck.GetRange(0, 1));
            Pile T2 = new Pile(); T2.PushCards(CardDeck.Deck.GetRange(1, 2));
            Pile T3 = new Pile(); T3.PushCards(CardDeck.Deck.GetRange(3, 3));
            Pile T4 = new Pile(); T4.PushCards(CardDeck.Deck.GetRange(6, 4));
            Pile T5 = new Pile(); T5.PushCards(CardDeck.Deck.GetRange(10, 5));
            Pile T6 = new Pile(); T6.PushCards(CardDeck.Deck.GetRange(15, 6));
            Pile T7 = new Pile(); T7.PushCards(CardDeck.Deck.GetRange(21, 7));
            Pile Talon = new Pile(); Talon.PushCards(CardDeck.Deck.GetRange(28, 3));
            Pile Stock = new Pile(); Stock.PushCards(CardDeck.Deck.GetRange(31, 21));
            Table = new Table(Stock, Talon, T1, T2, T3, T4, T5, T6, T7, F1, F2, F3, F4);
            Table.PrintTable();
            AnalyzeTable();
            /*while(!GameIsFinished)
            {
                AnalyzeTable();
            }*/
        }

        private void AnalyzeTable()
        {
            List<Move> possibleMoves = new List<Move>();
            possibleMoves = Table.GetAllPossibleMoves();
            Console.WriteLine("Possible moves: " + possibleMoves.Count);
            possibleMoves.Sort((a, b) => a.GetScore().CompareTo(b.GetScore()));
            if(possibleMoves.Count > 0)
            {
                Move highestMove = possibleMoves[possibleMoves.Count - 1];
                Console.WriteLine(highestMove.ToString());
            }
        }
    }
}