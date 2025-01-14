using System;

class Game
{
    Player _player1;
    Player _player2;
    Player player1
    {
        get { return _player1; }
    }
    Player player2
    {
        get { return _player2; }
    }

    public Game(Player p1, Player p2)
    {
        _player1 = p1;
        _player2 = p2;
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
        int randInt;
        Random rand = new Random();
        bool retry;
        bool player_1_wins = false;
        var p1_input = "";

        Console.Write("SYSTEM: ");
        slow_type("We will begin Tic Tac Toe by seeing who will start. This is decided with Rock, Paper, Scissors.", 100);
        Console.Write("SYSTEM: ");
        slow_type("You may quit at any time by typing 'Q'.", 100);
        do
        {
            retry = false;
            Console.Write("SYSTEM: ");
            slow_type("Player 1, choose your move!", 10);
            Console.WriteLine("PLAYER 1: ");

            do
            {
                p1_input = Console.ReadLine();
                if (p1_input == null) { p1_input = ""; }

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
            randInt = rand.Next(3);

            switch (randInt)
            {
                case 0:     slow_type("Rock!", 150);
                            break;

                case 1:     slow_type("Paper!", 150);
                            break;
                            
                case 2:     slow_type("Scissors!", 150);
                            break;

                default:    Console.Write("ERROR!");
                            Environment.Exit(0);
                            break;
            }

            // Check for retry
            if ((p1_input == "R" && randInt == 0) || (p1_input == "P" && randInt == 1) || (p1_input == "S" && randInt == 2))
            {
                retry = true;
            } 
            else if (p1_input == "R")
            {
                if (randInt == 1)
                {
                    player_1_wins = false;
                } 
                else if (randInt == 2) 
                {
                    player_1_wins = true;
                }
            }
            else if (p1_input == "P")
            {
                if (randInt == 0)
                {
                    player_1_wins = true;
                } 
                else if (randInt == 2) 
                {
                    player_1_wins = false;
                }
            }
            else if (p1_input == "S")
            {
                if (randInt == 0)
                {
                    player_1_wins = false;
                } 
                else if (randInt == 1) 
                {
                    player_1_wins = true;
                }
            }
            
        } while (retry);

        Console.Write("SYSTEM: ");
        if (player_1_wins) 
        {
            slow_type("Player 1 wins! They will start.", 100);
        } 
        else
        {
            slow_type("Player 2 wins! They will start.", 100);
        }

        return player_1_wins;
    }

    static void slow_type(string sentence, int time)
    {
        foreach (char c in sentence)
        {
            System.Threading.Thread.Sleep(time);
            Console.Write(c);
        }
        Console.WriteLine("");
    }
}