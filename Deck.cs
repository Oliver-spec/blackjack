namespace Blackjack;

public static class Deck
{
  private static Card[] _cards = [
    new("2"), new("3"), new("4"),
    new("5"), new("6"), new("7"),
    new("8"), new("9"), new("10"),
    new("J"), new("Q"), new("K"),
    new("A"),
    new("2"), new("3"), new("4"),
    new("5"), new("6"), new("7"),
    new("8"), new("9"), new("10"),
    new("J"), new("Q"), new("K"),
    new("A"),
    new("2"), new("3"), new("4"),
    new("5"), new("6"), new("7"),
    new("8"), new("9"), new("10"),
    new("J"), new("Q"), new("K"),
    new("A"),
    new("2"), new("3"), new("4"),
    new("5"), new("6"), new("7"),
    new("8"), new("9"), new("10"),
    new("J"), new("Q"), new("K"),
    new("A")
  ];


  public static void Shuffle()
  {
    new Random().Shuffle(_cards);
  }
  public static Card Draw()
  {
    Card cardDrawn = _cards[0];
    _cards = _cards.Skip(1).ToArray();
    return cardDrawn;
  }
}
