using NUnit.Framework;
using SolitaireHelperModels;
using System;
using System.Collections.Generic;

namespace SolitaireHelper.nUnitTests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
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
            foreach(Card card in cardDeck.Deck)
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
            foreach(Card card in stockCards)
            {
                if(card.Visible)
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
            foreach(Card card in stockCards)
            {
                if(card.Visible)
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
            table.NewCardsInTalon();
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
            table.NewCardsInTalon();
            table.PrintTable();
            table.NewCardsInTalon();
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
            table.NewCardsInTalon();
            table.NewCardsInTalon();
            table.NewCardsInTalon();
            table.NewCardsInTalon();
            table.NewCardsInTalon();
            table.NewCardsInTalon();
            table.NewCardsInTalon();
            // This should cause stock to have 2 cards only
            table.GetPileFromType(0).GetCards().RemoveAt(0);
            // This method should handle the edge case where stock only has 2 cards by taking 1 card from Talon,
            // and putting under stock then taking the cards from stock and putting it in talon.
            table.NewCardsInTalon();
            Console.WriteLine("After emptying all the cards in stock");
            table.PrintTable();

            int numberOfCardsInTalon = table.GetPileFromType(12).GetNumberOfCards();
            int numberOfCardsInStock = table.GetPileFromType(0).GetCards().Count;

            // Assert
            Assert.IsTrue(numberOfCardsInStock == 0);
            Assert.IsTrue(numberOfCardsInTalon == 23);

        }
        [Test]
        public void GetAllPossibleMovesTest()
        {
            /* Test that the function correctly extracts all the possible moves in the current table */

            // Arrange

            // Act

            // Assert

        }

    }
}