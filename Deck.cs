namespace Blackjack;

public static class Deck
{
  private static List<Card> _cards = [];
  private static readonly List<string> _names = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
  private static readonly List<string> _suits = ["Spades", "Hearts", "Diamonds", "Clubs"];


  public static void Shuffle()
  {
    Card[] cards = _cards.ToArray();
    new Random().Shuffle(cards);
    _cards = cards.ToList();
  }
  public static Card Draw()
  {
    Card cardDrawn = _cards[0];
    _cards.RemoveAt(0);
    return cardDrawn;
  }
  public static void GenerateDeck()
  {
    for (int i = 0; i < 4; i++)
    {
      foreach (string name in _names)
      {
        _cards.Add(new Card(name, _suits[i]));
      }
    }
  }
}
