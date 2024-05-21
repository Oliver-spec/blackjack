namespace Blackjack;

public static class Program
{
  private static void Main()
  {
    // main loop
    while (true)
    {
      Console.WriteLine("**************************");
      Console.WriteLine("*                        *");
      Console.WriteLine("*  Welcome to BlackJack! *");
      Console.WriteLine("*                        *");
      Console.WriteLine("**************************");

      Deck.GenerateDeck();
      Deck.Shuffle();

      Player player = new();
      player.Hit();
      player.Hit();
      // player.ShowHands();
      // StatusDisplay.Init(player, null);
      player.CheckVictory();

      if (player.HasBusted)
      {
        // Console.WriteLine("You lost X_X");
        StatusDisplay.Lost(player, null);
        continue;
      }

      Dealer dealer = new();
      dealer.Hit();
      dealer.Hit();
      // dealer.ShowHands();
      StatusDisplay.Init(player, dealer);
      dealer.CheckVictory();

      if (dealer.HasBusted)
      {
        // Console.WriteLine("You won OwO");
        // dealer.ShowTrueHands();
        StatusDisplay.Won(player, dealer);
        continue;
      }
      else if (player.HasWon && dealer.HasWon)
      {
        // Console.WriteLine("Draw -_-");
        // dealer.ShowTrueHands();
        StatusDisplay.Draw(player, dealer);
        continue;
      }
      else if (dealer.HasWon)
      {
        // Console.WriteLine("You lost X_X");
        // dealer.ShowTrueHands();
        StatusDisplay.Lost(player, dealer);
        continue;
      }
      else if (player.HasWon)
      {
        // Console.WriteLine("You won OwO");
        // dealer.ShowTrueHands();
        StatusDisplay.Won(player, dealer);
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
            // player.ShowHands();
            StatusDisplay.PlayerHit(player, dealer);
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
        // Console.WriteLine("You lost X_X");
        StatusDisplay.Lost(player, dealer);
        continue;
      }

      // dealer's loop
      while (true)
      {
        if (dealer.Total <= 16)
        {
          dealer.Hit();
          // dealer.ShowTrueHands();
          StatusDisplay.DealerHit(player, dealer);
          dealer.CheckVictory();

          if (dealer.HasBusted)
          {
            // Console.WriteLine("You won OwO");
            // dealer.ShowTrueHands();
            StatusDisplay.Won(player, dealer);
            break;
          }
          else if (dealer.HasWon && player.HasWon)
          {
            // Console.WriteLine("Draw -_-");
            // dealer.ShowTrueHands();
            StatusDisplay.Draw(player, dealer);
            break;
          }

          continue;
        }
        else if (dealer.Total == 17 && dealer.HasAce())
        {
          dealer.Hit();
          // dealer.ShowHands();
          StatusDisplay.DealerHit(player, dealer);
          dealer.CheckVictory();

          if (dealer.HasBusted)
          {
            // Console.WriteLine("You won OwO");
            // dealer.ShowTrueHands();
            StatusDisplay.Won(player, dealer);
            break;
          }
          else if (dealer.HasWon && player.HasWon)
          {
            // Console.WriteLine("Draw -_-");
            // dealer.ShowTrueHands();
            StatusDisplay.Draw(player, dealer);
            break;
          }

          continue;
        }

        if (player.HasWon)
        {
          // Console.WriteLine("You Won OwO");
          // dealer.ShowTrueHands();
          StatusDisplay.Won(player, dealer);
          break;
        }
        else if (dealer.Total > player.Total)
        {
          // Console.WriteLine("You Lost X_X");
          // dealer.ShowTrueHands();
          StatusDisplay.Lost(player, dealer);
          break;
        }
        else if (dealer.Total < player.Total)
        {
          // Console.WriteLine("You Won OwO");
          // dealer.ShowTrueHands();
          StatusDisplay.Won(player, dealer);
          break;
        }
        else if (dealer.Total == player.Total)
        {
          // Console.WriteLine("Draw -_-");
          // dealer.ShowTrueHands();
          StatusDisplay.Draw(player, dealer);
          break;
        }
      }
    }
  }
}
