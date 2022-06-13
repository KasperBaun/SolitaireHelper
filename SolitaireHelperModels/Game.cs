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

        public Game(){ }

        public int TestGame()
        {
            Console.WriteLine("New Test Game \n");
            GameIsFinished = false;
            Table = NewTable();
            return PlayGame(Table);
        }

        public int PlayGame(Table currentTable)
        {
            while (!GameIsFinished)
            {
                Move moveFound = FindNextMove(currentTable);
                if(moveFound.GetCard() == null || moveFound.GetFrom() == null || moveFound.GetTo() == null && !currentTable.IsTableEmpty())
                {
                    Console.WriteLine("No possible moves. Solitaire cannot be solved\n");
                    GameIsFinished = true;
                    break;
                }
                // TODO: Find better name for this method.
                //if (currentTable.MoveIsInfiniteLoop(moveFound)) 
                //    continue;
                Console.WriteLine(moveFound.ToString());
                currentTable.MakeMove(moveFound);
                //Table table = currentTable.MakeMove(moveFound);
                //Console.WriteLine("Cards in table: {0}\n", currentTable.CardsInTable());  
                //PlayGame(currentTable);
                continue;
            }
            if(GameIsFinished && currentTable.IsTableEmpty())
                return 1;
            else
            {
                return 0;
            }
            throw new Exception("Error @Game.cs -> PlayGame() - table.IsTableEmpty() == false with no GameIsFinished == true");
        }
        private Move FindNextMove(Table table)
        {
            List<Move> possibleMoves = table.GetAllPossibleMoves();
            if (possibleMoves.Count > 0)
            {
                Move highestMove = table.GetBestMove(possibleMoves);
                if (highestMove != null)
                {
                    return highestMove;
                }
                else
                {
                    throw new Exception("ERROR @ Game.cs -> FindNextMove(): possibleMoves.Count <= 0!");
                }
            }
            // TODO: Check that talon flips the cards correctly.
            table.ChangeCardsInTalon();
            FindNextMove(table);
            return null;
        }
        private Table NewTable()
        {
            CardDeck CardDeck = new CardDeck();
            CardDeck.ShuffleDeck();
            Pile F1 = new Pile() { Type = 8 };
            Pile F2 = new Pile() { Type = 9 };
            Pile F3 = new Pile() { Type = 10 };
            Pile F4 = new Pile() { Type = 11 };
            Pile T1 = new Pile() { Type = 1 }; 
            Pile T2 = new Pile() { Type = 2 }; 
            Pile T3 = new Pile() { Type = 3 }; 
            Pile T4 = new Pile() { Type = 4 }; 
            Pile T5 = new Pile() { Type = 5 }; 
            Pile T6 = new Pile() { Type = 6 }; 
            Pile T7 = new Pile() { Type = 7 }; 
            Pile Talon = new Pile() { Type = 12 }; 
            T1.PushCards(CardDeck.Deck.GetRange(0, 1)); 
            T1.GetTopCard().Visible = true;
            T2.PushCards(CardDeck.Deck.GetRange(1, 2)); 
            T2.GetTopCard().Visible = true;
            T3.PushCards(CardDeck.Deck.GetRange(3, 3)); 
            T3.GetTopCard().Visible = true;
            T4.PushCards(CardDeck.Deck.GetRange(6, 4)); 
            T4.GetTopCard().Visible = true;
            T5.PushCards(CardDeck.Deck.GetRange(10, 5)); 
            T5.GetTopCard().Visible = true;
            T6.PushCards(CardDeck.Deck.GetRange(15, 6)); 
            T6.GetTopCard().Visible = true;
            T7.PushCards(CardDeck.Deck.GetRange(21, 7)); 
            T7.GetTopCard().Visible = true;
            Talon.PushCards(CardDeck.Deck.GetRange(28, 3));
            foreach (Card card in Talon.GetCards())
            {
                card.Visible = true;
            }
            Pile Stock = new Pile() { Type = 0 }; 
            Stock.PushCards(CardDeck.Deck.GetRange(31, 21));
            Table Table = new Table(Stock, Talon, T1, T2, T3, T4, T5, T6, T7, F1, F2, F3, F4);
            return Table;
        } 
    }
}