using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelperModels
{
    public class GameTest
    {
        public Table Table { get; set; }
        private int Won { get; set; }

        public void TestGame(int AmountOfTests)
        {
            for(int i = 0; i < AmountOfTests; i++)
            {
                Won += RunGame();
            }
            Console.WriteLine("Test finished! \nGames played: {0}\nGames won: {1}\nWin ratio: {2}%\n", AmountOfTests, Won, (Won / AmountOfTests)*100);
        }

        public int RunGame()
        {
            Game game = new Game();
            return game.TestGame();
        }
    }
}
 