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
    CalculateTotal();
  }
  public void ShowTrueHands()
  {
    Console.Write("Dealer's cards: ");
    foreach (Card card in _cards)
    {
      Console.Write($"{card.Name}{card.Suit} ");
    }
    Console.Write("\n");
  }
  public void ShowHands()
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
        Console.Write(_cards[i].Name + _cards[i].Suit + " ");
      }
    }
    Console.Write("\n");
  }
  public void CheckVictory()
  {
    if (_total > 21)
    {
      Console.WriteLine("Dealer has busted!");
      ShowTrueHands();
      Environment.Exit(0);
    }
    else if (_total == 21)
    {
      Console.WriteLine("Dealer has won!");
      ShowTrueHands();
      Environment.Exit(0);
    }
  }
  public bool HasAce()
  {
    foreach (Card card in _cards)
    {
      if (card.Name == "A")
      {
        return true;
      }
    }

    return false;
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

    _total = total;
  }
}
