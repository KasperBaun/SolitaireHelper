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
            int stockRefillCounter = 0;
            int totalMovesMade = 0;
            while (!GameIsFinished)
            {
                List<Move> currentPossibleMoves = table.GetAllPossibleMoves();
                currentPossibleMoves.RemoveAll(mv => mv.GetScore() == 0);
                List<Move> cleansedMoves = new List<Move>();
                foreach (Move m in currentPossibleMoves)
                {
                    cleansedMoves.Add(m);
                    Table mState = new Table(table);
                    mState.MakeMove(m);
                    if (PreviousStates.Exists(t => t.IsEqual(mState)))
                    {
                        // We have been in this state before - discard this move
                        cleansedMoves.Remove(m);
                    }
                }

                foreach (Move m in currentPossibleMoves)
                {
                    Table mState = new Table(table);
                    mState.MakeMove(m);
                    if (PreviousStringStates.Exists(t => t == mState.ToString()))
                    {
                        // We have been in this state before - discard this move
                        cleansedMoves.Remove(m);
                    }
                }
                Move move = GetBestMove(cleansedMoves);
            
                if(move == null && stockRefillCounter == 3 || totalMovesMade == 500)
                {
                    Console.WriteLine("Total moves made: {0}", totalMovesMade);
                    GameIsFinished = true;
                    break;
                }

                if(move == null)
                {
                    stockRefillCounter += table.DrawNewCardsToTalon();
                    continue;
                }
                
                Console.WriteLine(move.ToString());
                table.MakeMove(move);
                totalMovesMade++;
                PreviousStates.Add(new Table(table));
                PreviousStringStates.Add(table.ToString());
            }

            if(GameIsFinished && table.IsTableEmpty())
            {
                Console.WriteLine("Solitaire succesfully solved!\n");
                return 1;
            }
            else
            {
                Console.WriteLine("No possible moves. Solitaire cannot be solved\n");
                table.PrintTable();
                return 0;
            }
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