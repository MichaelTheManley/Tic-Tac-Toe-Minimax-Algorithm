
class Game
{
    Player player1
    {
        get;
    }
    Player player2
    {
        get;
    }

    public Game(Player p1, Player p2) 
    {
        player1 = p1;
        player2 = p2;
    }

    public static void start() 
    {
        System.Threading.Thread.Sleep(1000);

        Console.WriteLine("+--------------------------------+");
        Console.WriteLine("|-----WELCOME TO THE ULTIMATE----|");
        Console.WriteLine("|-----------TIC TAC TOE----------|");
        Console.WriteLine("+--------------------------------+");

        System.Threading.Thread.Sleep(1000);

        //Lambda expression for the slow typing
        //Is Action type as it doesn't return anything
        //Func returns of type specified by out
        Action<string, int> slow_type = (sentence, time) => 
        {
            foreach (char c in sentence)
            {
                System.Threading.Thread.Sleep(time);
                Console.Write(c);
            }
        };

        slow_type("Let the games begin...", 400);
        slow_type("Player 1, do you choose Rock (R), Paper (P), or Scissors (S)?", 200);
    }
}