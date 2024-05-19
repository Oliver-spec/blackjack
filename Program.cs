namespace Blackjack;

public static class Program
{
  private static void Main()
  {
    Console.WriteLine("Welcome to BlackJack!");

    Deck.Shuffle();

    Dealer dealer = new();
    dealer.Hit();
    dealer.Hit();
    dealer.ShowHands();
    dealer.CheckVictory();

    Player player = new();
    player.Hit();
    player.Hit();
    player.ShowHands();
    player.CheckVictory();

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
    }

    while (true)
    {
      // bool hasAce = false;
      // foreach (Card card in dealer.Cards)
      // {
      //   if (card.Name == "A")
      //   {
      //     hasAce = true;
      //   }
      // }

      if (dealer.Total <= 16)
      {
        dealer.Hit();
        dealer.ShowHands();
        dealer.CheckVictory();
      }
      else if (dealer.Total == 17 && dealer.HasAce())
      {
        dealer.Hit();
        dealer.ShowHands();
        dealer.CheckVictory();
      }

      if (dealer.Total > player.Total)
      {
        Console.WriteLine("The dealer have won!");
        dealer.ShowTrueHands();
        break;
      }
      else if (dealer.Total < player.Total)
      {
        Console.WriteLine("The player have won!");
        dealer.ShowTrueHands();
        break;
      }
      else if (dealer.Total == player.Total)
      {
        Console.WriteLine("Draw!");
        dealer.ShowTrueHands();
        break;
      }
    }
  }
}
