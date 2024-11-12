namespace BlackJack.Models;
public class Card
{
    public int Value { get; set; }
    public SuitType Suit { get; set; }
    public int BlackJackValue
    {
        get
        {
            if (Value == 1)
            {
                return 11;
            }
            else if (Value > 9)
            {
                return 10;
            }
            return Value;
        }
    }

    public Card(int value, SuitType suit)
    {
        Value = value;
        Suit = suit;
    }

    public override string ToString()
    {
        string value = Value switch
        {
            1 => "Ess",
            < 11 => Value.ToString(),
            11 => "Knekt",
            12 => "Dam",
            13 => "Kung",
            _ => throw new ApplicationException("Value of card is to high")
        };

        string suit = Suit switch
        {
            SuitType.Club => "Klöver",
            SuitType.Diamond => "Ruter",
            SuitType.Heart => "Hjärter",
            SuitType.Spades => "Spader",
            _ => throw new ApplicationException()
        };

        return $"{suit} {value}";
    }

}
