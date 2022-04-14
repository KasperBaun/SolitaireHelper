using NUnit.Framework;
using SolitaireHelperModels;
using System.Collections.Generic;

namespace SolitaireHelper.nUnitTests
{
    public class GameTests
    {
        private CardDeck CardDeck = new();
        private List<Card> NewCardDeck = new();
        [SetUp]
        public void Setup()
        {
            NewCardDeck = FullCardSet();
        }

        [Test]
        public void CardDeckTest()
        {
            // Assign
            //CardDeck.PrintDeck();

            // Act

            // Assert
            foreach(Card card in CardDeck.Deck)
            {
                Assert.True(NewCardDeck.Contains(card));
            }
        }

        private List<Card> FullCardSet()
        {
            List<Card> cards = new List<Card>();
            for(int j = 1; j <= 4; j++)
            {
                for(int i = 1; i <= 13; i++)
                {
                    Card card = new Card()
                    {
                        Rank = i,
                        Suit = j,
                        Visible = false
                    };
                    cards.Add(card);
                }
            }

            return cards;
        }
    }
}