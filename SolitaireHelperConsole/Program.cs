using SolitaireHelperModels;

int Won = 0;

void TestGame(int AmountOfTests)
{
    for (int i = 0; i < AmountOfTests; i++)
    {
        Won += RunGame();
    }
    int winRatio = Won / AmountOfTests * 100;
    Console.WriteLine("Test finished! \nGames played: {0}\nGames won: {1}\nWin ratio: {2}%\n", AmountOfTests, Won, winRatio);
}

int RunGame()
{
    Game game = new Game();
    return game.TestGame();
}

int i;
Console.WriteLine("How many tests would you like the program to run?");
i = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Starting {0} tests:\n",i);
TestGame(i);
