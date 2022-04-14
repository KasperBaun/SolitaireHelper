﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelper.Models
{
    public class Move
    {
        public Pile From { get; set; }
        public Pile To { get; set; }
        public Card Card { get; set; }
        protected int Score { get; set; }

        public Move(Pile from, Pile to, Card card)
        {
            From = from;
            To = to;
            Card = card;
            CalculateScore();
        }

        private void CalculateScore()
        {
            if (Card == null)
            {
                Score = 5;
                return ;
            }

            // Test if ace can move to any of the Foundations
            if (Card.Rank == 1 && IsTableau(From) && IsFoundation(To)) {
                Score = 95 + From.GetCards().Count;
                return;
            }

            // Test if 2 can move to GroundPile
            if (Card.Rank == 2 && IsTableau(From) && IsFoundation(To)) {
                Score = 85 + From.GetCards().Count;
                return;
            }

            // Test if king can move to Empty BuildPile
            if (Card.Rank == 13 && IsTableau(From) && IsTableau(To) && To.IsEmpty() && !From.IsEmpty()) {
                Score = 75 + From.GetCards().Count;
                return;
            }
            // Test if card can move from BuildPile to GroundPile
            if (IsTableau(From) && IsFoundation(To)) {
                Score = From.GetCards().Count + 40;
                return;
            }

            // Test if card can move from BuildPile to BuildPile
            if (Card.Rank != 13 && IsTableau(From) && IsTableau(To)) {
                Score = From.GetCards().Count + 30;
                return;
            }

            // Test if card can move from BasePile to GroundPile
            if (From.Type==0 && IsTableau(To)) {
                Score = From.GetCards().Count + 20;
                return;
            }

            // Test if card can move from BasePile to BuildPile
            if (From.Type==0 && IsFoundation(To)) {
                Score = From.GetCards().Count + 10;
                return;
            }

            Score = -1;
            Card = null;
        }
        private bool IsFoundation(Pile pile)
        {
            switch (pile.Type)
            {
                case 8:
                    return true;
                case 9:
                    return true;
                case 10:
                    return true;
                case 11:
                    return true;
                default:
                    return false;
            }
        }
        private bool IsTableau(Pile pile)
        {
            switch (pile.Type)
            {
                case 1:
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                case 4:
                    return true;
                case 5:
                    return true;
                case 6:
                    return true;
                case 7:
                    return true;
                default:
                    return false;
            }
        }
        public void MoveCard()
        {
            List<Card> CardsToMove = new List<Card>();
            foreach(Card card in From.GetCards())
            {
                if(card == Card)
                {
                    CardsToMove.Add(card);
                }
            }
            From.PopCard(CardsToMove);
            To.PushCards(CardsToMove);
        }
        public int GetScore()
        {
            return Score;
        }
        // Test if this move has been done recently (a way to avoid infinite-loops between 2 legal moves)
        public bool IsReverseMove(Move oldMove)
        {
            if(oldMove == null) { return false; }

            Card to = To.GetTopCard();
            Card from = From.GetTopCard();
            if(oldMove.From.IsEqual(to) && oldMove.To.IsEqual(from)  && oldMove.Card == Card)
            {
                return true;
            }
            return false;
        }

    }
}
