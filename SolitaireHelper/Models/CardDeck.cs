using System;
using System.Collections.Generic;
using System.Text;
using SolitaireHelper.Models;

namespace SolitaireHelper.Models
{
    internal enum SuitEnum { C, D, H, S};

    public class CardDeck
    {
        private Card[] Deck { get; set; }

        public CardDeck()
        {
            Deck = NewUnshuffledDeck();
        }

        private Card[] NewUnshuffledDeck()
        {
            Card[] cardDeck = new Card[52];
            char[] suits = { 'C', 'D', 'H', 'S' };
            Card newCard = new Card();
            newCard.Visible = false;
            for (int i = (int)SuitEnum.C; i < (int)SuitEnum.S; i++)
            {
                newCard.Suit = suits[i];
                newCard.Rank = 'A';
                cardDeck[i * 13] = newCard;
                for (int j = 2; j <=9; j++)
                {
                    newCard.Rank = (char)j;
                    cardDeck[(i * 13) + j-1] = newCard;
                }
                newCard.Rank = 'T';
                cardDeck[i * 13 + 9] = newCard;
                newCard.Rank = 'J';
                cardDeck[i * 13 + 10] = newCard;
                newCard.Rank = 'Q';
                cardDeck[i * 13 + 11] = newCard;
                newCard.Rank = 'K';
                cardDeck[i * 13 + 12] = newCard;
            }

            return cardDeck;
        }

        public void PrintDeck()
        {
            // TODO
        }

        public void ShuffleDeck()
        {
            // TODO
        }
    }

}
