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
            int i = 0;
            while (!GameIsFinished)
            {
                Console.WriteLine(table.ToString());
                List<Move> allPossibleMoves = table.GetAllPossibleMoves();
                Move move = FindNextMove(allPossibleMoves, table);
            
                if(move == null)
                {
                    GameIsFinished = true;
                    break;
                }
                
                Console.WriteLine(move.ToString());
                table.MakeMove(move);
                if(PreviousStates.Count > i){
                    Table stateTable = new Table(table);
                    PreviousStates.Add(stateTable);
                }
                i--;
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
            if(allPossibleMoves.Count == 0)
            {
                if (table.DrawNewCardsToTalon())
                {
                    allPossibleMoves = table.GetAllPossibleMoves();
                    FindNextMove(allPossibleMoves, table);
                }
            }
            Move move = GetBestMove(allPossibleMoves);
            if(move == null)
            {
                GameIsFinished = true;
                return null;
            }
            // Copy-constructor bliver brugt her og laver en kopi af det nuværende table.
            // Derefter udfører den trækket fra GetBestMove på kopien af vores Table
            Table newState = new Table(table);
            newState.MakeMove(move);

            if (PreviousStates.Count > 0)
            {
                if(PreviousStates.Exists(t => t.IsEqual(newState)))
                {
                    allPossibleMoves.Remove(move);
                    FindNextMove(allPossibleMoves, table);
                }
            }

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