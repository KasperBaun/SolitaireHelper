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
            Console.WriteLine("### New Test Game ###");
            GameIsFinished = false;
            Table = new Table();
            return PlayGame(Table);
        }
        public int PlayGame(Table table)
        {
            while (!GameIsFinished)
            {
                Move move = FindNextMove(table);
            
                if(move == null)
                {
                    GameIsFinished = true;
                    break;
                }
                
                Console.WriteLine(move.ToString());
                table.MakeMove(move);
                continue;
            }

            if(GameIsFinished && table.IsTableEmpty())
            {
                Console.WriteLine("Solitaire succesfully solved!\n");
                return 1;
            }
            else
            {
                Console.WriteLine("No possible moves. Solitaire cannot be solved\n");
                return 0;
            }
            throw new Exception("Error @Game.cs -> PlayGame() - table.IsTableEmpty() == false and GameIsFinished == false");
        }
        private Move FindNextMove(Table table)
        {
            /* This function is responsible for the primary logic in the solving of the solitaire game.
             * This is done as so:
             * 1. Check that the soliatire on the table is not solved by counting the cards in the foundations with the method IsTableEmpty().
             * 2. Create a list of all possible moves from the current state of the table
             * 3. If that list contains valid moves, find the move with the highest score (ranked by CalculateScore() method)
             * 4. Return that move
             */

            // This accounts for the case where all the foundations are full and the solitaire is solved
            if(table.IsTableEmpty())
                return null;

            List<Move> possibleMoves = table.GetAllPossibleMoves();

            if (possibleMoves.Count > 0)
            {
                Move bestMove = table.GetBestMove(possibleMoves);
                if (bestMove != null)
                {
                    return bestMove;
                }
                else
                {
                    throw new Exception("ERROR @ Game.cs -> FindNextMove(): Could not find Move bestMove from method GetBestMove(possibleMoves)!");
                }
            }
            return null;
        }
    }
}