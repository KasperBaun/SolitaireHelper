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
        public bool GameIsFinished { get; set; }
        public List<Table> PreviousStates { get; set; }

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
            while (!GameIsFinished)
            {
                List<Move> allPossibleMoves = table.GetAllPossibleMoves();
                Move move = FindNextMove(allPossibleMoves, table);

            
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
        }
        private Move FindNextMove(List<Move> allPossibleMoves,Table table)
        {
            // Find det bedste træk
            // Check om det bedste træk er lavet før (kig i PreviousStates) - hvis ikke, udfør det og gem Table-state i PreviousStates
            // Hvis trækket er lavet før, find et nyt bedste træk.
            Move move = GetBestMove(allPossibleMoves);
            Table newState = table.MakeMove(move);
            Console.WriteLine("Nyt table");
            newState.PrintTable();
            Console.WriteLine("Gammelt table");
            table.PrintTable();

            if (PreviousStates.Exists(t => newState.IsEqual(t)))
            {
                allPossibleMoves.Remove(move);
                FindNextMove(allPossibleMoves, table);
            }

            return move;
        }
        private Move GetBestMove(List<Move> moves)
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
    }
}