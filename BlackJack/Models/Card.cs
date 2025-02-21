namespace BlackJack.Models;
public class Card(int value, SuitType suit)
{
    public int Value { get; set; } = value;
    public SuitType Suit { get; set; } = suit;

    public int BlackJackValue => Value switch {
        1 => 11,
        > 9 => 10,
        _ => Value
    };
        
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
