namespace Blackjack;

public class Dealer
{
  private readonly List<Card> _cards = [];
  private int _total = 0;


  public int Total
  {
    get { return _total; }
  }
  public List<Card> Cards
  {
    get { return _cards; }
  }


  public void Hit()
  {
    _cards.Add(Deck.Draw());
    ShowHands();
    CalculateTotal();
  }
  public void ShowTrueHands()
  {
    Console.Write("Dealer's cards: ");
    foreach (Card card in _cards)
    {
      Console.Write($"{card.Name} ");
    }
    Console.Write("\n");
  }
  private void ShowHands()
  {
    Console.Write("Dealer's cards: ");
    for (int i = 0; i < _cards.Count; i++)
    {
      if (i == 0)
      {
        Console.Write("X ");
      }
      else
      {
        Console.Write(_cards[i].Name + " ");
      }
    }
    Console.Write("\n");
  }
  private void CalculateTotal()
  {
    int total = 0;
    foreach (Card card in _cards)
    {
      total += card.Value;
    }

    if (total > 21)
    {
      int aceCount = 0;
      foreach (Card cardElement in _cards)
      {
        if (cardElement.Name == "A")
        {
          aceCount++;
        }
      }

      while (total > 21 && aceCount > 0)
      {
        total -= 10;
        aceCount--;
      }
    }

    if (total > 21)
    {
      Console.WriteLine("Dealer have busted!");
      ShowTrueHands();
      Environment.Exit(0);
    }
    else if (total == 21)
    {
      Console.WriteLine("Dealer have won!");
      ShowTrueHands();
      Environment.Exit(0);
    }

    _total = total;
  }
}
