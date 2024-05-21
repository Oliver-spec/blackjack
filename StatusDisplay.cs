namespace Blackjack;

public static class StatusDisplay
{
  private const string _perimeter = "\n************\n";

  public static void Won(Player player, Dealer dealer)
  {
    Console.WriteLine(_perimeter);
    Console.WriteLine("You won OwO");
    player.ShowHands();
    dealer.ShowTrueHands();
    Console.WriteLine(_perimeter);
    Exit();
  }
  public static void Lost(Player player, Dealer? dealer)
  {
    Console.WriteLine(_perimeter);
    Console.WriteLine("You Lost X_X");
    player.ShowHands();
    dealer?.ShowTrueHands();
    Console.WriteLine(_perimeter);
    Exit();
  }
  public static void Draw(Player player, Dealer dealer)
  {
    Console.WriteLine(_perimeter);
    Console.WriteLine("Draw -_-");
    player.ShowHands();
    dealer.ShowTrueHands();
    Console.WriteLine(_perimeter);
    Exit();
  }
  public static void Init(Player player, Dealer dealer)
  {
    Console.WriteLine(_perimeter);
    Console.WriteLine("Starting Cards: ");
    player.ShowHands();
    dealer.ShowHands();
    Console.WriteLine(_perimeter);
  }
  public static void PlayerHit(Player player, Dealer dealer)
  {
    Console.WriteLine(_perimeter);
    Console.WriteLine("Player Hit!");
    player.ShowHands();
    dealer.ShowHands();
    Console.WriteLine(_perimeter);
  }
  public static void DealerHit(Player player, Dealer dealer)
  {
    Console.WriteLine(_perimeter);
    Console.WriteLine("Dealer Hit!");
    player.ShowHands();
    dealer.ShowHands();
    Console.WriteLine(_perimeter);
  }
  private static void Exit()
  {
    Console.WriteLine("Press n for another round. Press any other button to quit.");
    string input = Console.ReadLine() ?? "";

    if (input != "n")
    {
      Environment.Exit(0);
    }
    else
    {
      Console.Clear();
    }
  }
}
