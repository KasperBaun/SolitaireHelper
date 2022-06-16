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
        public List<Table> PreviousStates { get; set; }
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
            PreviousStates = new List<Table>();
            PreviousStringStates = new List<string>();
            while (!GameIsFinished)
            {
                Move move = FindNextMove(table, 0);
            
                if(move == null)
                {
                    GameIsFinished = true;
                    break;
                }
                
                Console.WriteLine(move.ToString());
                table.MakeMove(move);
                Table stateTable = new Table(table);
                PreviousStates.Add(stateTable);
                PreviousStringStates.Add(stateTable.ToString());
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
        private Move FindNextMove(Table table, int StockRefillCounter)
        {
            List<Move> allPossibleMoves = table.GetAllPossibleMoves();

            if(allPossibleMoves.Count == 0)
            {
                if (StockRefillCounter < 6)
                {
                    StockRefillCounter += table.DrawNewCardsToTalon();
                    FindNextMove(table, StockRefillCounter);
                }
                if(StockRefillCounter == 6)
                {
                    return null;
                }
            }

            List<Move> cleansedMoves = new List<Move>();
            foreach(Move m in allPossibleMoves)
            {
                cleansedMoves.Add(m);
                Table newState = new Table(table);
                newState.MakeMove(m);
                if (PreviousStates.Count > 0)
                {
                    if (PreviousStates.Exists(t => t.IsEqual(newState)))
                    {
                        cleansedMoves.Remove(m);
                    }
                }
            }

            if (cleansedMoves.Count == 0)
            {
                if (StockRefillCounter < 6)
                {
                    StockRefillCounter += table.DrawNewCardsToTalon();
                    FindNextMove(table, StockRefillCounter);
                }
                if (StockRefillCounter == 6)
                {
                    return null;
                }
            }

            Move move = GetBestMove(cleansedMoves);

            return move;
        }
        private Move GetBestMove(List<Move> moves)
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