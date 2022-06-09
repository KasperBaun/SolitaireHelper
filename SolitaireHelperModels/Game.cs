using System;
using System.Collections.Generic;

namespace SolitaireHelperModels
{
    [Serializable]
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
            Console.WriteLine("### New Test Game ###");
            GameIsFinished = false;
            Table = new Table();
            return PlayGame(Table);
        }
        public int PlayGame(Table currentTable)
        {
            while (!GameIsFinished)
            {
                Move moveFound = FindNextMove(currentTable);
            
                if(moveFound == null && !currentTable.IsTableEmpty())
                {
                    Console.WriteLine("No possible moves. Solitaire cannot be solved\n");
                    GameIsFinished = true;
                    break;
                }
                
                Console.WriteLine(moveFound.ToString());
                currentTable.MakeMove(moveFound);
                continue;
            }
            if(GameIsFinished && currentTable.IsTableEmpty())
            {
                Console.WriteLine("Solitaire complete!\n");
                return 1;
            }
            else
            {
                return 0;
            }
            throw new Exception("Error @Game.cs -> PlayGame() - table.IsTableEmpty() == false and GameIsFinished == false");
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
            else if(possibleMoves.Count == 0)
            {
                if (table.NewCardsInTalon())
                {
                    FindNextMove(table);
                }
            }
            
            return null;
        }
    }
}