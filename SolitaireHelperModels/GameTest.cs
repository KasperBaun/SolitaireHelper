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
            Console.WriteLine("Test finished! \n", "Games played: {0}\n", AmountOfTests, "Games won: {1}\n", Won, "Win ratio: {2}\n", (Won / AmountOfTests));
        }

        public int RunGame()
        {
            Game game = new Game();
            game.TestGame();
            return 0;
        }
    }
}
 