using SolitaireHelperModels;
int i;
Console.WriteLine("How many tests would you like the program to run?");
i = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Starting {0} tests:\n",i);
GameTest gameTest = new();
gameTest.TestGame(i);