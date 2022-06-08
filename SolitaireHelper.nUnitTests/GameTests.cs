using NUnit.Framework;
using SolitaireHelperModels;
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
            /* Tests the table as whole.
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
                if (card.Visible && card == t2Cards[0])
                    n++;
            }
            Assert.IsTrue(n == 2);

            foreach (Card card in t3Cards)
            {
                if (card.Visible && card == t3Cards[0])
                    n++;
            }
            Assert.IsTrue(n == 3);

            foreach (Card card in t4Cards)
            {
                if (card.Visible && card == t4Cards[0])
                    n++;
            }
            Assert.IsTrue(n == 4);

            foreach (Card card in t5Cards)
            {
                if (card.Visible && card == t5Cards[0])
                    n++;
            }
            Assert.IsTrue(n == 5);

            foreach (Card card in t6Cards)
            {
                if (card.Visible && card == t6Cards[0])
                    n++;
            }
            Assert.IsTrue(n == 6);

            foreach (Card card in t7Cards)
            {
                if (card.Visible && card == t7Cards[0])
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

            // Act

            // Assert

        }

        [Test]
        public void MoveTest()
        {
            /* Test that the move is correctly done and behaves as expected */

            // Arrange

            // Act

            // Assert

        }



    }
}