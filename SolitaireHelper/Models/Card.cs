using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelper.Models
{
    public class Card
    {
        public int Id { get; set; }
        public char Suit { get; set; }
        public char Rank { get; set; }
        public bool Visible { get; set; }
    }
}
