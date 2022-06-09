using System;
using System.Collections.Generic;

namespace SolitaireHelperModels
{
    public class CardDeck
    {
        public List<Card> Deck { get; set; }
        public CardDeck()
        {
            Deck = NewUnshuffledDeck();
        }
        public List<Card> NewUnshuffledDeck()
        {
            List<Card> cardDeck = new List<Card>();
            for (int j = 1; j <= 4; j++)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Card card = new Card(suit: j, rank: i, visible: false);
                    cardDeck.Add(card);
                }
            }
            
            return cardDeck;
        }
        public void ShuffleDeck()
        {
            Random rng = new Random();
            int n = Deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Deck[k];
                Deck[k] = Deck[n];
                Deck[n] = value;
            }
        }
        public void PrintDeck()
        {
            foreach(Card card in Deck)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
