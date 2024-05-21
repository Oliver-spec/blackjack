namespace Blackjack;

public static class Program
{
  private static void Main()
  {
    // main loop
    while (true)
    {
      Console.WriteLine("*-*-*-*-*  Welcome to BlackJack! *-*-*-*-*");

      Deck.GenerateDeck();
      Deck.Shuffle();

      Player player = new();
      player.Hit();
      player.Hit();
      player.ShowHands();
      player.CheckVictory();

      if (player.HasBusted)
      {
        Console.WriteLine("You lost X_X");
        continue;
      }

      Dealer dealer = new();
      dealer.Hit();
      dealer.Hit();
      dealer.ShowHands();
      dealer.CheckVictory();

      if (dealer.HasBusted)
      {
        Console.WriteLine("You won OwO");
        dealer.ShowTrueHands();
        continue;
      }
      else if (player.HasWon && dealer.HasWon)
      {
        Console.WriteLine("Draw -_-");
        dealer.ShowTrueHands();
        continue;
      }
      else if (dealer.HasWon)
      {
        Console.WriteLine("You lost X_X");
        dealer.ShowTrueHands();
        continue;
      }
      else if (player.HasWon)
      {
        Console.WriteLine("You won OwO");
        dealer.ShowTrueHands();
        continue;
      }

      // player's loop
      while (true)
      {
        Console.WriteLine("Press h to hit.\nPress s to stand.");
        string input = Console.ReadLine() ?? "";
        switch (input)
        {
          case "h":
            player.Hit();
            player.ShowHands();
            player.CheckVictory();
            break;
          case "s":
            player.Stand();
            break;
          default:
            Console.WriteLine("Please press valid keys!");
            continue;
        }

        if (player.IsStanding)
        {
          break;
        }
        else if (player.HasWon)
        {
          break;
        }
        else if (player.HasBusted)
        {
          break;
        }
      }

      if (player.HasBusted)
      {
        Console.WriteLine("You lost X_X");
        continue;
      }

      // dealer's loop
      while (true)
      {
        if (dealer.Total <= 16)
        {
          dealer.Hit();
          dealer.ShowTrueHands();
          dealer.CheckVictory();

          if (dealer.HasBusted)
          {
            Console.WriteLine("You won OwO");
            dealer.ShowTrueHands();
            break;
          }
          else if (dealer.HasWon && player.HasWon)
          {
            Console.WriteLine("Draw -_-");
            dealer.ShowTrueHands();
            break;
          }

          continue;
        }
        else if (dealer.Total == 17 && dealer.HasAce())
        {
          dealer.Hit();
          dealer.ShowHands();
          dealer.CheckVictory();

          if (dealer.HasBusted)
          {
            Console.WriteLine("You won OwO");
            dealer.ShowTrueHands();
            break;
          }
          else if (dealer.HasWon && player.HasWon)
          {
            Console.WriteLine("Draw -_-");
            dealer.ShowTrueHands();
            break;
          }

          continue;
        }

        if (player.HasWon)
        {
          Console.WriteLine("You Won OwO");
          dealer.ShowTrueHands();
          break;
        }
        else if (dealer.Total > player.Total)
        {
          Console.WriteLine("You Lost X_X");
          dealer.ShowTrueHands();
          break;
        }
        else if (dealer.Total < player.Total)
        {
          Console.WriteLine("You Won OwO");
          dealer.ShowTrueHands();
          break;
        }
        else if (dealer.Total == player.Total)
        {
          Console.WriteLine("Draw -_-");
          dealer.ShowTrueHands();
          break;
        }
      }
    }
  }
}
