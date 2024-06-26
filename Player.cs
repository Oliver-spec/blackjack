﻿namespace Blackjack;

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
  public bool HasWon { get; private set; } = false;
  public bool HasBusted { get; private set; } = false;


  public void Hit()
  {
    _cards.Add(Deck.Draw());
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
      Console.Write($"{card.Name}{card.Suit} ");
    }
    Console.Write("\n");
  }
  public void CheckVictory()
  {
    if (_total > 21)
    {
      // Console.WriteLine("You have busted!");
      HasBusted = true;
    }
    else if (_total == 21)
    {
      // Console.WriteLine("You have won!");
      HasWon = true;
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

    _total = total;
  }
}
