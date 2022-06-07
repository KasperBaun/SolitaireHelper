using NUnit.Framework;
using SolitaireHelperModels;

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
        public void TableauSetUpTest()
        {
            /* Test that each tableau in set up gets the correct amount of cards with correct visibility */

            // Arrange

            // Act

            // Assert

        }

        [Test]
        public void StockSetUpTest()
        {
            /* Test that the stock holds 24 cards without visibility */

            // Arrange

            // Act

            // Assert

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