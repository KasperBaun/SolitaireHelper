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
            CardDeck CardDeck = new CardDeck();
            CardDeck.ShuffleDeck();
            Pile F1 = new Pile();
            Pile F2 = new Pile();
            Pile F3 = new Pile();
            Pile F4 = new Pile();
            Pile T1 = new Pile(); T1.PushCards(CardDeck.Deck.GetRange(0, 1));
            Pile T2 = new Pile(); T2.PushCards(CardDeck.Deck.GetRange(1, 2));
            Pile T3 = new Pile(); T3.PushCards(CardDeck.Deck.GetRange(3, 3));
            Pile T4 = new Pile(); T4.PushCards(CardDeck.Deck.GetRange(6, 4));
            Pile T5 = new Pile(); T5.PushCards(CardDeck.Deck.GetRange(10, 5));
            Pile T6 = new Pile(); T6.PushCards(CardDeck.Deck.GetRange(15, 6));
            Pile T7 = new Pile(); T7.PushCards(CardDeck.Deck.GetRange(21, 7));
            Pile Talon = new Pile(); Talon.PushCards(CardDeck.Deck.GetRange(28, 3));
            Pile Stock = new Pile(); Stock.PushCards(CardDeck.Deck.GetRange(31, 21));
            Table = new Table(Stock, Talon, T1, T2, T3, T4, T5, T6, T7, F1, F2, F3, F4);

            Table.PrintTable();
            return 0;
        }
    }
}
 