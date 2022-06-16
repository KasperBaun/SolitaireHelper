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
        public bool GameIsFinished { get; set; }
        public List<string> PreviousStringStates { get; set; }

        public Game(){ }

        public int TestGame()
        {
            Console.WriteLine("### New Test Game ###");
            GameIsFinished = false;
            Table Table = new Table();
            return PlayGame(Table);
        }
        public int PlayGame(Table table)
        {
            PreviousStringStates = new List<string>();
            while (!GameIsFinished)
            {
                List<Move> allPossibleMoves = table.GetAllPossibleMoves();
                Move move = FindNextMove(allPossibleMoves, table, 0);
            
                if(move == null)
                {
                    GameIsFinished = true;
                    break;
                }
                
                Console.WriteLine(move.ToString());
                table.MakeMove(move);
                PreviousStringStates.Add(table.ToString());
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
        }
        private Move FindNextMove(List<Move> allPossibleMoves, Table table,  int StockRefillCounter)
        {
            Move move = GetBestMove(allPossibleMoves);

            if(allPossibleMoves.Count == 0 && StockRefillCounter != 3)
            {
                StockRefillCounter =  StockRefillCounter + table.DrawNewCardsToTalon();
                allPossibleMoves = table.GetAllPossibleMoves();
                return FindNextMove(allPossibleMoves, table, StockRefillCounter);

                if(StockRefillCounter == 3)
                {
                    return move;
                }
            }

            Table newState = new Table(table);
            newState.MakeMove(move);
            if (PreviousStringStates.Contains(newState.ToString()))
            {
                allPossibleMoves.Remove(move);
                FindNextMove(allPossibleMoves,table,  StockRefillCounter);
                if (PreviousStringStates.Contains(newState.ToString()))
                {
                    GameIsFinished = true;
                }
            }

            return move;
        }
        public Move GetBestMove(List<Move> moves)
        {
            if(moves.Count == 0)
            {
                return null;
            }
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
    }
}