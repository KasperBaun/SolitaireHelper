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
                Move move = table.FindNextMove();
            
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
    }
}