namespace Blackjack;

public class Card
{
  private readonly string _name;
  private readonly string _suit;
  private readonly int _value;


  public Card(string name, string suit)
  {
    _name = name;
    _suit = suit;
    bool cardIsNormal = int.TryParse(name, out _value);

    if (cardIsNormal)
    {
      return;
    }
    else if (name != "A")
    {
      _value = 10;
    }
    else
    {
      _value = 11;
    }
  }


  public string Name
  {
    get { return _name; }
  }
  public string Suit
  {
    get
    {
      switch (_suit)
      {
        case "Spades":
          return "\u2660";
        case "Clubs":
          return "\u2663";
        case "Hearts":
          return "\u2665";
        case "Diamonds":
          return "\u2666";
        default:
          return _suit;
      }
    }
  }
  public int Value
  {
    get { return _value; }
  }
}
