using NUnit.Framework;
using SolitaireHelperModels;
using System;
using System.Collections.Generic;

namespace SolitaireHelper.nUnitTests
{
    public class GameTests
    {
        Table table;
        [SetUp]
        public void Setup()
        {
            table = TestTable();
        }

        [Test]
        public void CardDeckTest()
        {
            /* Test that a deck consist of the correct cards (52 different cards) */

            // 1. The deck should have 26 black cards and 26 red cards
            // 2. The deck should have card ranks A-K in each of the 4 suits
            // 3. Total amount of cards should be 52

            // Arrange
            CardDeck cardDeck = new();

            // Act
            int black = 0;
            int red = 0;
            int totalCards = 0;

            /* Count black, red and total cards */
            foreach (Card card in cardDeck.Deck)
            {
                totalCards++;
                if (card.IsRed())
                {
                    red++;
                }
                if (card.IsBlack())
                {
                    black++;
                }
            }

            table.PrintTable();

            /* Test if the set of cards have one of each rank in all 4 suits */
            for (int j = 1; j <= 4; j++)
            {
                for (int i = 1; i <= 13; i++)
                {
                    cardDeck.Deck.Remove(cardDeck.Deck.Find(c => c.Rank == i && c.Suit == j));
                }
            }

            // Assert
            Assert.IsTrue(black == 26);
            Assert.IsTrue(red == 26);
            Assert.IsTrue(totalCards == 52);
            Assert.IsTrue(cardDeck.Deck.Count == 0);

        }
        [Test]
        public void TableSetupTest()
        {
            /* Test id's fulfilled: ST1 - Stock placement 
             * Tests the table as a whole.
             * Test that each tableau in set up gets the correct amount of cards with correct visibility 
             * Test that the stock holds 24 cards without visibility
             * Test that foundations are empty and talon is empty     
             */

            // Arrange
            Table table = new();

            // Act
            table.PrintTable();
            List<Card> stockCards = table.GetPileFromType(0).GetCards();
            List<Card> t1Cards = table.GetPileFromType(1).GetCards();
            List<Card> t2Cards = table.GetPileFromType(2).GetCards();
            List<Card> t3Cards = table.GetPileFromType(3).GetCards();
            List<Card> t4Cards = table.GetPileFromType(4).GetCards();
            List<Card> t5Cards = table.GetPileFromType(5).GetCards();
            List<Card> t6Cards = table.GetPileFromType(6).GetCards();
            List<Card> t7Cards = table.GetPileFromType(7).GetCards();
            List<Card> f1Cards = table.GetPileFromType(8).GetCards();
            List<Card> f2Cards = table.GetPileFromType(9).GetCards();
            List<Card> f3Cards = table.GetPileFromType(10).GetCards();
            List<Card> f4Cards = table.GetPileFromType(11).GetCards();
            List<Card> talonCards = table.GetPileFromType(12).GetCards();


            // Assert

            // All piles have the correct amount of cards in them
            Assert.IsTrue(stockCards.Count == 24);
            Assert.IsTrue(t1Cards.Count == 1);
            Assert.IsTrue(t2Cards.Count == 2);
            Assert.IsTrue(t3Cards.Count == 3);
            Assert.IsTrue(t4Cards.Count == 4);
            Assert.IsTrue(t5Cards.Count == 5);
            Assert.IsTrue(t6Cards.Count == 6);
            Assert.IsTrue(t7Cards.Count == 7);
            Assert.IsTrue(f1Cards.Count == 0);
            Assert.IsTrue(f2Cards.Count == 0);
            Assert.IsTrue(f3Cards.Count == 0);
            Assert.IsTrue(f4Cards.Count == 0);
            Assert.IsTrue(talonCards.Count == 0);

            // All piles only have the top card visible
            int n = 0;
            foreach (Card card in stockCards)
            {
                if (card.Visible)
                    n++;
            }
            Assert.IsTrue(n == 0);

            foreach (Card card in t1Cards)
            {
                if (card.Visible && card == t1Cards[0])
                    n++;
            }
            Assert.IsTrue(n == 1);

            foreach (Card card in t2Cards)
            {
                if (card.Visible && card == t2Cards[1])
                    n++;
            }
            Assert.IsTrue(n == 2);

            foreach (Card card in t3Cards)
            {
                if (card.Visible && card == t3Cards[2])
                    n++;
            }
            Assert.IsTrue(n == 3);

            foreach (Card card in t4Cards)
            {
                if (card.Visible && card == t4Cards[3])
                    n++;
            }
            Assert.IsTrue(n == 4);

            foreach (Card card in t5Cards)
            {
                if (card.Visible && card == t5Cards[4])
                    n++;
            }
            Assert.IsTrue(n == 5);

            foreach (Card card in t6Cards)
            {
                if (card.Visible && card == t6Cards[5])
                    n++;
            }
            Assert.IsTrue(n == 6);

            foreach (Card card in t7Cards)
            {
                if (card.Visible && card == t7Cards[6])
                    n++;
            }
            Assert.IsTrue(n == 7);


            // No cards are visible in stock

            int visibleInStock = 0;
            foreach (Card card in stockCards)
            {
                if (card.Visible)
                    visibleInStock++;
            }

            Assert.IsTrue(visibleInStock == 0);
        }
        [Test]
        public void AddCardsToTalonTest()
        {
            /* Test that cards are moved from Stock to Talon and only top one is visible */

            // Arrange
            Table table = new();

            // Act
            table.PrintTable();
            table.DrawNewCardsToTalon();
            table.PrintTable();
            int numberOfCardsInTalon = table.GetPileFromType(12).GetNumberOfCards();
            bool firstCard = table.GetPileFromType(12).GetCards()[0].Visible;
            bool secondCard = table.GetPileFromType(12).GetCards()[1].Visible;
            bool thirdCard = table.GetPileFromType(12).GetCards()[2].Visible;

            // Assert
            Assert.IsFalse(firstCard);
            Assert.IsFalse(secondCard);
            Assert.IsTrue(thirdCard);
            Assert.IsTrue(numberOfCardsInTalon == 3);

        }
        [Test]
        public void AddMoreCardsToTalonTest()
        {
            /* Test that cards are moved from Stock to Talon and only top one is visible */

            // Arrange
            Table table = new();

            // Act
            table.PrintTable();
            table.DrawNewCardsToTalon();
            table.PrintTable();
            table.DrawNewCardsToTalon();
            table.PrintTable();
            int numberOfCardsInTalon = table.GetPileFromType(12).GetNumberOfCards();
            bool firstCard = table.GetPileFromType(12).GetCards()[0].Visible;
            bool secondCard = table.GetPileFromType(12).GetCards()[1].Visible;
            bool thirdCard = table.GetPileFromType(12).GetCards()[2].Visible;
            bool fourthCard = table.GetPileFromType(12).GetCards()[3].Visible;
            bool fifthCard = table.GetPileFromType(12).GetCards()[4].Visible;
            bool sixthCard = table.GetPileFromType(12).GetCards()[5].Visible;

            // Assert
            Assert.IsFalse(firstCard);
            Assert.IsFalse(secondCard);
            Assert.IsFalse(thirdCard);
            Assert.IsFalse(fourthCard);
            Assert.IsFalse(fifthCard);
            Assert.IsTrue(sixthCard);
            Assert.IsTrue(numberOfCardsInTalon == 6);

        }
        [Test]
        public void StockLessThanThreeCardsTest()
        {
            /* Test that cards are not moved from Stock to Talon if stock has less than 3 cards in it */

            // Arrange
            Table table = new();

            // Act
            Console.WriteLine("Before doing anything");
            table.PrintTable();
            table.DrawNewCardsToTalon();
            table.DrawNewCardsToTalon();
            table.DrawNewCardsToTalon();
            table.DrawNewCardsToTalon();
            table.DrawNewCardsToTalon();
            table.DrawNewCardsToTalon();
            table.DrawNewCardsToTalon();
            // This should cause stock to have 2 cards only
            table.GetPileFromType(0).GetCards().RemoveAt(0);
            // This method should handle the edge case where stock only has 2 cards by taking 1 card from Talon,
            // and putting under stock then taking the cards from stock and putting it in talon.
            table.DrawNewCardsToTalon();
            Console.WriteLine("After emptying all the cards in stock");
            table.PrintTable();

            int numberOfCardsInTalon = table.GetPileFromType(12).GetNumberOfCards();
            int numberOfCardsInStock = table.GetPileFromType(0).GetCards().Count;

            // Assert
            Assert.IsTrue(numberOfCardsInStock == 23);
            Assert.IsTrue(numberOfCardsInTalon == 0);

        }
        [Test]
        public void GetAllPossibleMovesTest()
        {
            /* Test that the function correctly extracts all the possible moves in the current table */

            // Arrange

            // Act
            table.PrintTable();
            table.GetPileFromType(0).PrintPile();
            List<Move> moves = table.GetAllPossibleMoves();

            // Moves that are possible in the current state of the table if all talon is checked (got these moves from doing the solitaire on my table):
            // AD from T1 -> F3
            // D7 from Talon -> T5
            // H4 from Talon -> T2
            // D10 from Talon -> T6
            // D4 from Talon -> T2
            // SA from Talon -> F4

            Console.WriteLine("# of moves in allPossibleMoves list:" + moves.Count);
            Console.WriteLine("Moves in allPossibleMoves list:");
            foreach (Move move in moves)
            {
                Console.WriteLine(move.ToString());
            }

            // Assert
            Assert.IsTrue(moves.Count == 1);
        }
        [Test]
        public void MakeMoveTest()
        {
            /* Tests that the move is made correctly on the table */
            Game game = new();

            // Arrange
            List<Move> moves = table.GetAllPossibleMoves();
            Move bestMove = game.GetBestMove(moves);
            Console.WriteLine(bestMove.ToString());

            // Act
            table.MakeMove(bestMove);
            table.PrintTable();
            // Ace of Spades from Talon -> F4 has a score of 119



            // Assert - What do we expect?
            // 1. The move score is 119
            Assert.IsTrue(bestMove.GetScore() == 95);

            // 2. The card is moved from fromPile to toPile and the state of the piles is correct (hidden topCards set to visible etc.)
            Assert.IsFalse(table.GetPileFromType(0).GetCards().Contains(bestMove.GetCard()));
            Assert.IsTrue(table.GetPileFromType(10).GetCards().Contains(bestMove.GetCard()));

            // 3. Stock is refilled and Talon is empty
            Assert.IsTrue(table.GetPileFromType(0).IsEmpty() != true);
            Assert.IsTrue(table.GetPileFromType(12).IsEmpty() == true);
            Assert.IsTrue(table.CardsInStock() == 24);

        }
        [Test]
        public void PlaySolvableGameTest()
        {
            Table solvableTable = new(TestTableSolvable());

            /* 1st move expected: Move 5C from T2 --> T6 - Score: [32]  */
            Game game = new();
            int won = game.PlayGame(solvableTable);

            /* 2nd move expected: Move 6D from T6 --> T2 - Score: [37] */




            Assert.IsTrue(won == 1);


            //Move bestMove = table.FindNextMove();
            //Console.WriteLine("1st move:"); 
            //Console.WriteLine(bestMove.ToString() + "\n");
            //table.MakeMove(bestMove);

            //// Assert - What do we expect?
            //// The first move to be: Move AD from T1 --> F3 - Score: [96]
            //Assert.IsTrue(bestMove.GetCard().Rank == 1 && bestMove.GetCard().Suit == 3);
            //Assert.IsTrue(table.GetPileFromType(10).GetCards().Contains(bestMove.GetCard()));



        }
        [Test]
        public void TableIsEqualTest()
        {
            Table testTable = new(table);
            //table.PrintTable();
            //testTable.PrintTable();

            //Assert.IsTrue(table.IsEqual(testTable));
            Console.WriteLine(table.CardsInStock());
            testTable.GetPileFromType(0).GetCards().RemoveAt(0);
            Console.WriteLine(testTable.CardsInStock());

            Assert.IsFalse(table.IsEqual(testTable));
        }
        [Test]
        public void TableToStringTest()
        {
            Console.WriteLine(table.ToString());
        }
        public Table TestTable()
        {
            // Constructor for a table with a specific set of cards
            Pile Stock = new() { Type = 0 };
            Pile T1 = new() { Type = 1 };
            Pile T2 = new() { Type = 2 };
            Pile T3 = new() { Type = 3 };
            Pile T4 = new() { Type = 4 };
            Pile T5 = new() { Type = 5 };
            Pile T6 = new() { Type = 6 };
            Pile T7 = new() { Type = 7 };
            Pile F1 = new() { Type = 8 };
            Pile F2 = new() { Type = 9 };
            Pile F3 = new() { Type = 10 };
            Pile F4 = new() { Type = 11 };
            Pile Talon = new() { Type = 12 };

            Card D1 = new(3, 1, true);
            T1.GetCards().Add(D1);

            Card H7 = new(1, 7, false);
            Card S5 = new(4, 5, true);
            T2.GetCards().Add(H7);
            T2.GetCards().Add(S5);

            Card H8 = new(1, 8, false);
            Card HJ = new(1, 11, false);
            Card HK = new(1, 13, true);
            T3.GetCards().Add(H8);
            T3.GetCards().Add(HJ);
            T3.GetCards().Add(HK);

            Card H9 = new(1, 9, false);
            Card H6 = new(1, 6, false);
            Card DQ = new(3, 12, false);
            Card S7 = new(4, 7, true);
            T4.GetCards().Add(H9);
            T4.GetCards().Add(H6);
            T4.GetCards().Add(DQ);
            T4.GetCards().Add(S7);

            Card S9 = new(4, 9, false);
            Card HQ = new(1, 12, false);
            Card DK = new(3, 13, false);
            Card H10 = new(1, 10, false);
            Card C8 = new(2, 8, true);
            T5.GetCards().Add(S9);
            T5.GetCards().Add(HQ);
            T5.GetCards().Add(DK);
            T5.GetCards().Add(H10);
            T5.GetCards().Add(C8);

            Card S10 = new(4, 10, false);
            Card H2 = new(1, 2, false);
            Card SK = new(4, 13, false);
            Card CA = new(2, 1, false);
            Card C9 = new(2, 9, false);
            Card CJ = new(2, 11, true);
            T6.GetCards().Add(S10);
            T6.GetCards().Add(H2);
            T6.GetCards().Add(SK);
            T6.GetCards().Add(CA);
            T6.GetCards().Add(C9);
            T6.GetCards().Add(CJ);

            Card D5 = new(3, 5, false);
            Card DJ = new(3, 11, false);
            Card SJ = new(4, 11, false);
            Card SQ = new(4, 12, false);
            Card C10 = new(2, 10, false);
            Card CQ = new(2, 12, false);
            Card CK = new(2, 13, true);
            T7.GetCards().Add(D5);
            T7.GetCards().Add(DJ);
            T7.GetCards().Add(SJ);
            T7.GetCards().Add(SQ);
            T7.GetCards().Add(C10);
            T7.GetCards().Add(CQ);
            T7.GetCards().Add(CK);

            Card SA = new(4, 1, false);
            Stock.GetCards().Add(SA);
            Card S2 = new(4, 2, false);
            Stock.GetCards().Add(S2);
            Card S4 = new(4, 4, false);
            Stock.GetCards().Add(S4);
            Card D4 = new(3, 4, false);
            Stock.GetCards().Add(D4);
            Card D6 = new(3, 6, false);
            Stock.GetCards().Add(D6);
            Card D8 = new(3, 8, false);
            Stock.GetCards().Add(D8);
            Card D10 = new(3, 10, false);
            Stock.GetCards().Add(D10);
            Card C2 = new(2, 2, false);
            Stock.GetCards().Add(C2);
            Card C4 = new(2, 4, false);
            Stock.GetCards().Add(C4);
            Card C6 = new(2, 6, false);
            Stock.GetCards().Add(C6);
            Card HA = new(1, 1, false);
            Stock.GetCards().Add(HA);
            Card H3 = new(1, 3, false);
            Stock.GetCards().Add(H3);
            Card H4 = new(1, 4, false);
            Stock.GetCards().Add(H4);
            Card H5 = new(1, 5, false);
            Stock.GetCards().Add(H5);
            Card C7 = new(2, 7, false);
            Stock.GetCards().Add(C7);
            Card S3 = new(4, 3, false);
            Stock.GetCards().Add(S3);
            Card S6 = new(4, 6, false);
            Stock.GetCards().Add(S6);
            Card S8 = new(4, 8, false);
            Stock.GetCards().Add(S8);
            Card D7 = new(3, 7, false);
            Stock.GetCards().Add(D7);
            Card D9 = new(3, 9, false);
            Stock.GetCards().Add(D9);
            Card D3 = new(3, 3, false);
            Stock.GetCards().Add(D3);
            Card C3 = new(2, 3, false);
            Stock.GetCards().Add(C3);
            Card C5 = new(2, 5, false);
            Stock.GetCards().Add(C5);
            Card D2 = new(3, 2, false);
            Stock.GetCards().Add(D2);
            // Vender Stock pga fejl i manuel indtastning.
            Stock.GetCards().Reverse();


            return table = new Table(Stock, Talon, T1, T2, T3, T4, T5, T6, T7, F1, F2, F3, F4);
        }
        public Table TestTableSolvable()
        {
            // Constructor for a table with a specific set of cards
            Pile Stock = new() { Type = 0 };
            Pile T1 = new() { Type = 1 };
            Pile T2 = new() { Type = 2 };
            Pile T3 = new() { Type = 3 };
            Pile T4 = new() { Type = 4 };
            Pile T5 = new() { Type = 5 };
            Pile T6 = new() { Type = 6 };
            Pile T7 = new() { Type = 7 };
            Pile F1 = new() { Type = 8 };
            Pile F2 = new() { Type = 9 };
            Pile F3 = new() { Type = 10 };
            Pile F4 = new() { Type = 11 };
            Pile Talon = new() { Type = 12 };

            Card S3 = new(4, 3, true);
            T1.GetCards().Add(S3);

            Card S7 = new(4, 7, false);
            Card C5 = new(2, 5, true);
            T2.GetCards().Add(S7);
            T2.GetCards().Add(C5);

            Card C8 = new(2, 8, false);
            Card DQ = new(3, 12, false);
            Card D8 = new(3, 8, true);
            T3.GetCards().Add(C8);
            T3.GetCards().Add(DQ);
            T3.GetCards().Add(D8);

            Card CK = new(2, 13, false);
            Card H10 = new(1, 10, false);
            Card SJ = new(4, 11, false);
            Card H9 = new(1, 9, true);
            T4.GetCards().Add(CK);
            T4.GetCards().Add(H10);
            T4.GetCards().Add(SJ);
            T4.GetCards().Add(H9);

            Card D9 = new(3, 9, false);
            Card C9 = new(2, 9, false);
            Card H7 = new(1, 7, false);
            Card S6 = new(4, 6, false);
            Card HJ = new(1, 11, true);
            T5.GetCards().Add(D9);
            T5.GetCards().Add(C9);
            T5.GetCards().Add(H7);
            T5.GetCards().Add(S6);
            T5.GetCards().Add(HJ);

            Card H5 = new(1, 5, false);
            Card S9 = new(4, 9, false);
            Card D4 = new(3, 4, false);
            Card S8 = new(4, 8, false);
            Card S10 = new(4, 10, false);
            Card D6 = new(3, 6, true);
            T6.GetCards().Add(H5);
            T6.GetCards().Add(S9);
            T6.GetCards().Add(D4);
            T6.GetCards().Add(S8);
            T6.GetCards().Add(S10);
            T6.GetCards().Add(D6);

            Card C6 = new(2, 6, false);
            Card S2 = new(4, 2, false);
            Card H2 = new(1, 2, false);
            Card SK = new(4, 13, false);
            Card DA = new(3, 1, false);
            Card C3 = new(2, 3, false);
            Card D7 = new(3, 7, true);
            T7.GetCards().Add(C6);
            T7.GetCards().Add(S2);
            T7.GetCards().Add(H2);
            T7.GetCards().Add(SK);
            T7.GetCards().Add(DA);
            T7.GetCards().Add(C3);
            T7.GetCards().Add(D7);

            Card CA = new(2, 1, false);
            Stock.GetCards().Add(CA);
            Card DK = new(3, 13, false);
            Stock.GetCards().Add(DK);
            Card HK = new(1, 13, false);
            Stock.GetCards().Add(HK);
            Card CJ = new(2, 11, false);
            Stock.GetCards().Add(CJ);
            Card H8 = new(1, 8, false);
            Stock.GetCards().Add(H8);
            Card HQ = new(1, 12, false);
            Stock.GetCards().Add(HQ);
            Card D2 = new(3, 2, false);
            Stock.GetCards().Add(D2);
            Card H6 = new(1, 6, false);
            Stock.GetCards().Add(H6);
            Card DJ = new(3, 11, false);
            Stock.GetCards().Add(DJ);
            Card H4 = new(1, 4, false);
            Stock.GetCards().Add(H4);
            Card S4 = new(4, 4, false);
            Stock.GetCards().Add(S4);
            Card C7 = new(2, 7, false);
            Stock.GetCards().Add(C7);
            Card S5 = new(4, 5, false);
            Stock.GetCards().Add(S5);
            Card D5 = new(3, 5, false);
            Stock.GetCards().Add(D5);
            Card D3 = new(3, 3, false);
            Stock.GetCards().Add(D3);
            Card H3 = new(1, 3, false);
            Stock.GetCards().Add(H3);
            Card CQ = new(2, 12, false);
            Stock.GetCards().Add(CQ);
            Card HA = new(1, 1, false);
            Stock.GetCards().Add(HA);
            Card D10 = new(3, 10, false);
            Stock.GetCards().Add(D10);
            Card C4 = new(2, 4, false);
            Stock.GetCards().Add(C4);
            Card SQ = new(4, 12, false);
            Stock.GetCards().Add(SQ);
            Card C2 = new(2, 2, false);
            Stock.GetCards().Add(C2);
            Card SA = new(4, 1, false);
            Stock.GetCards().Add(SA);
            Card C10 = new(2, 10, false);
            Stock.GetCards().Add(C10);

            return table = new Table(Stock, Talon, T1, T2, T3, T4, T5, T6, T7, F1, F2, F3, F4);
        }


    }
}