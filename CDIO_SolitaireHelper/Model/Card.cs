public class Card
{
 
    private FaceValue faceValue;
    private Suit suit;
    private bool visible;

    public Card(Suit suit, FaceValue value)
    {
        this.visible = true;
        this.suit = suit;
        this.faceValue = value;
    }

    public bool isRed() { return suit == Suit.HEARTS || suit == Suit.DIAMONDS; }

    public bool isBlack() { return suit == Suit.SPADES || suit == Suit.CLUBS; }

    public string toString()
    {
        return suit.ToString()+" "+faceValue.ToString();
    }

    
}

public enum Suit
{
    HEARTS = 1,
    CLUBS = 2,
    DIAMONDS = 3,
    SPADES = 4
}
public enum FaceValue
{
    NULL = 0,
    ONE = 1,
    TWO = 2,
    THREE = 3,
    FOUR = 4,
    FIVE = 5,
    SIX = 6,
    SEVEN = 7,
    EIGHT = 8,
    NINE = 9,
    TEN = 10,
    KNIGHT = 11,
    QUEEN = 12,
    KING = 13
}