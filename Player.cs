namespace Blackjack;

public class Player
{
  private readonly List<Card> _cards = [];
  private bool _isStanding = false;
  private int _total = 0;


  public bool IsStanding
  {
    get { return _isStanding; }
  }
  public int Total
  {
    get { return _total; }
  }


  public void Hit()
  {
    _cards.Add(Deck.Draw());
    // ShowHands();
    CalculateTotal();
  }
  public void Stand()
  {
    _isStanding = true;
  }
  public void ShowHands()
  {
    Console.Write("Your cards: ");
    foreach (Card card in _cards)
    {
      Console.Write($"{card.Name} ");
    }
    Console.Write("\n");
  }
  public void CheckVictory()
  {
    if (_total > 21)
    {
      Console.WriteLine("You have busted!");
      Environment.Exit(0);
    }
    else if (_total == 21)
    {
      Console.WriteLine("You have won!");
      Environment.Exit(0);
    }
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

    // if (total > 21)
    // {
    //   Console.WriteLine("You have busted!");
    //   Environment.Exit(0);
    // }
    // else if (total == 21)
    // {
    //   Console.WriteLine("You have won!");
    //   Environment.Exit(0);
    // }

    _total = total;
  }
}
