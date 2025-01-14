using System;

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

    public void start() 
    {
        System.Threading.Thread.Sleep(1000);

        Console.WriteLine("+--------------------------------+");
        Console.WriteLine("|-----WELCOME TO THE ULTIMATE----|");
        Console.WriteLine("|-----------TIC TAC TOE----------|");
        Console.WriteLine("+--------------------------------+");

        System.Threading.Thread.Sleep(1000);

        player1.isTurn = rock_paper_scissors();
        player2.isTurn = !player1.isTurn;
    }

    public bool rock_paper_scissors()
    {
        bool player_1_wins = false;
        var p1_input = "";
        Console.Write("SYSTEM: ");
        slow_type("We will begin the game by seeing who starts with Rock, Paper, Scissors.", 100);
        Console.Write("SYSTEM: ");
        slow_type("You may quit at any time by typing 'Q'.", 100);
        Console.Write("SYSTEM: ");
        slow_type("Player 1, choose your move!", 10);
        Console.WriteLine("PLAYER 1: ");

        do {
            p1_input = Console.ReadLine();
            if (p1_input == null) {p1_input = "";}
            
            if ((p1_input != "R") && (p1_input != "P") && (p1_input != "S") && (p1_input != "Q")) 
            {
                Console.Write("SYSTEM: ");
                slow_type("Please enter either [R] => Rock, [P] => Paper or [S] => Scissors.", 100);
                slow_type("PLAYER 1: ", 100);
            }
        } while ((p1_input != "R") && (p1_input != "P") && (p1_input != "S") && (p1_input != "Q"));

        if (p1_input == "Q")
        {
            Console.Write("SYSTEM: ");
            slow_type("Goodbye!", 100);
            slow_type("and goodluck...", 400);
            Environment.Exit(0);
        }

        Console.Write("SYSTEM: ");
        slow_type("Player 2, choose your move!", 100);
        Console.WriteLine("PLAYER 2: ");
        

        
        return player_1_wins;
    }

    public static void slow_type(string sentence, int time)
    {
        foreach (char c in sentence)
        {
            System.Threading.Thread.Sleep(time);
            Console.Write(c);
        }
        Console.WriteLine("");
    }
}