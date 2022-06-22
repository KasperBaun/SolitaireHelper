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
        private bool ShowConsoleText { get; set; }
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
            int stockRefillCounter = 0;
            int totalMovesMade = 0;
            ShowConsoleText = true;
            while (!GameIsFinished)
            {
                List<Move> currentPossibleMoves = table.GetAllPossibleMoves();
               
                currentPossibleMoves.RemoveAll(mv => mv.GetScore() == 0);
                List<Move> cleansedMoves = new List<Move>();
             
                foreach (Move m in currentPossibleMoves)
                {
                    Table newState = new Table(table);
                    newState.MakeMove(m);
                    cleansedMoves.Add(m);
                    if (PreviousStringStates.Exists(t => t == newState.ToString()))
                    {
                        // We have been in this state before - discard this move
                        cleansedMoves.Remove(m);
                    }
                }
                cleansedMoves.RemoveAll(m => m.GetScore() == -1);

                Move move = GetBestMove(cleansedMoves);
                
            
                if(move == null && stockRefillCounter == 3 || totalMovesMade == 500 || table.IsTableEmpty())
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

                
                if (move.GetScore() < 11 && stockRefillCounter < 3)
                {
                    stockRefillCounter += table.DrawNewCardsToTalon();
                    continue;
                }
                
                if (ShowConsoleText)
                {
                    Console.WriteLine(move.ToString());
                }
                table.MakeMove(move);
                totalMovesMade++;
                stockRefillCounter = 0;
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
        public Table TestTableSolvable()
        {
            // Constructor for a table with a specific set of cards
            Pile Stock = new Pile() { Type = 0 };
            Pile T1 = new Pile() { Type = 1 };
            Pile T2 = new Pile() { Type = 2 };
            Pile T3 = new Pile() { Type = 3 };
            Pile T4 = new Pile() { Type = 4 };
            Pile T5 = new Pile() { Type = 5 };
            Pile T6 = new Pile() { Type = 6 };
            Pile T7 = new Pile() { Type = 7 };
            Pile F1 = new Pile() { Type = 8 };
            Pile F2 = new Pile() { Type = 9 };
            Pile F3 = new Pile() { Type = 10 };
            Pile F4 = new Pile() { Type = 11 };
            Pile Talon = new Pile() { Type = 12 };

            Card S3 = new Card(4, 3, true);
            T1.GetCards().Add(S3);

            Card S7 = new Card(4, 7, false);
            Card C5 = new Card(2, 5, true);
            T2.GetCards().Add(S7);
            T2.GetCards().Add(C5);

            Card C8 = new Card(2, 8, false);
            Card DQ = new Card(3, 12, false);
            Card D8 = new Card(3, 8, true);
            T3.GetCards().Add(C8);
            T3.GetCards().Add(DQ);
            T3.GetCards().Add(D8);

            Card CK = new Card(2, 13, false);
            Card H10 = new Card(1, 10, false);
            Card SJ = new Card(4, 11, false);
            Card H9 = new Card(1, 9, true);
            T4.GetCards().Add(CK);
            T4.GetCards().Add(H10);
            T4.GetCards().Add(SJ);
            T4.GetCards().Add(H9);

            Card D9 = new Card(3, 9, false);
            Card C9 = new Card(2, 9, false);
            Card H7 = new Card(1, 7, false);
            Card S6 = new Card(4, 6, false);
            Card HJ = new Card(1, 11, true);
            T5.GetCards().Add(D9);
            T5.GetCards().Add(C9);
            T5.GetCards().Add(H7);
            T5.GetCards().Add(S6);
            T5.GetCards().Add(HJ);

            Card H5 = new Card(1, 5, false);
            Card S9 = new Card(4, 9, false);
            Card D4 = new Card(3, 4, false);
            Card S8 = new Card(4, 8, false);
            Card S10 = new Card(4, 10, false);
            Card D6 = new Card(3, 6, true);
            T6.GetCards().Add(H5);
            T6.GetCards().Add(S9);
            T6.GetCards().Add(D4);
            T6.GetCards().Add(S8);
            T6.GetCards().Add(S10);
            T6.GetCards().Add(D6);

            Card C6 = new Card(2, 6, false);
            Card S2 = new Card(4, 2, false);
            Card H2 = new Card(1, 2, false);
            Card SK = new Card(4, 13, false);
            Card DA = new Card(3, 1, false);
            Card C3 = new Card(2, 3, false);
            Card D7 = new Card(3, 7, true);
            T7.GetCards().Add(C6);
            T7.GetCards().Add(S2);
            T7.GetCards().Add(H2);
            T7.GetCards().Add(SK);
            T7.GetCards().Add(DA);
            T7.GetCards().Add(C3);
            T7.GetCards().Add(D7);

            Card CA = new Card(2, 1, false);
            Stock.GetCards().Add(CA);
            Card DK = new Card(3, 13, false);
            Stock.GetCards().Add(DK);
            Card HK = new Card(1, 13, false);
            Stock.GetCards().Add(HK);
            Card CJ = new Card(2, 11, false);
            Stock.GetCards().Add(CJ);
            Card H8 = new Card(1, 8, false);
            Stock.GetCards().Add(H8);
            Card HQ = new Card(1, 12, false);
            Stock.GetCards().Add(HQ);
            Card D2 = new Card(3, 2, false);
            Stock.GetCards().Add(D2);
            Card H6 = new Card(1, 6, false);
            Stock.GetCards().Add(H6);
            Card DJ = new Card(3, 11, false);
            Stock.GetCards().Add(DJ);
            Card H4 = new Card(1, 4, false);
            Stock.GetCards().Add(H4);
            Card S4 = new Card(4, 4, false);
            Stock.GetCards().Add(S4);
            Card C7 = new Card(2, 7, false);
            Stock.GetCards().Add(C7);
            Card S5 = new Card(4, 5, false);
            Stock.GetCards().Add(S5);
            Card D5 = new Card(3, 5, false);
            Stock.GetCards().Add(D5);
            Card D3 = new Card(3, 3, false);
            Stock.GetCards().Add(D3);
            Card H3 = new Card(1, 3, false);
            Stock.GetCards().Add(H3);
            Card CQ = new Card(2, 12, false);
            Stock.GetCards().Add(CQ);
            Card HA = new Card(1, 1, false);
            Stock.GetCards().Add(HA);
            Card D10 = new Card(3, 10, false);
            Stock.GetCards().Add(D10);
            Card C4 = new Card(2, 4, false);
            Stock.GetCards().Add(C4);
            Card SQ = new Card(4, 12, false);
            Stock.GetCards().Add(SQ);
            Card C2 = new Card(2, 2, false);
            Stock.GetCards().Add(C2);
            Card SA = new Card(4, 1, false);
            Stock.GetCards().Add(SA);
            Card C10 = new Card(2, 10, false);
            Stock.GetCards().Add(C10);

            return new Table(Stock, Talon, T1, T2, T3, T4, T5, T6, T7, F1, F2, F3, F4);
        }

    }
}