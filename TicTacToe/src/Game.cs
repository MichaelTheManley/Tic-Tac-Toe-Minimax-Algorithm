using System;
using System.Text.RegularExpressions;

class Game
{
    int[] game_moves;
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
        game_moves = new int[9];
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

        initiate_toe();
    }

    void initiate_toe()
    {
        bool winner = false;
        int p1_move = 0;
        int p2_move = 0;

        while (!winner)
        {
            if (player1.isTurn)
            {
                p1_move = get_player1_move();

            }
            else
            {
                p2_move = get_player2_move();
            }
            player1.isTurn = !player1.isTurn;
            player2.isTurn = !player2.isTurn;
        }
    }

    int get_player1_move()
    {
        var move = "";
        string pattern = @"^[123456789]$";
        Regex regex = new Regex(pattern);
        bool invalid = true;

        do
        {
            Console.Write("SYSTEM: ");
            slow_type("Player 1, which tile do you choose? [1-9]", 100);

            move = Console.ReadLine();
            if (move == null) { move = ""; }

            Match match = regex.Match(move);

            if (match.Success)
            {
                if (check_available(int.Parse(move)))
                {
                    invalid = false;
                }
                else
                {
                    Console.Write("SYSTEM: ");
                    slow_type("Invalid move, position taken. Please select another.", 100);
                }
            }
        } while (invalid);

        return int.Parse(move);
    }

    int get_player2_move()
    {
        string pattern = @"^[123456789]$";
        Regex regex = new Regex(pattern);
        bool invalid = true;
        int chosen_move = 0;

        do
        {
            Console.Write("SYSTEM: ");
            slow_type("Player 2, which tile do you choose? [1-9]", 100);

            for (int i = 1; i < 10; i++)
            {
                if (check_available(i)) //First check if a move can be played at the position
                {
                    chosen_move = minimax(i, 1, true);
                }
            }

        } while (invalid);

        return chosen_move;
    }

    int minimax(int pos, int depth, bool maximizing_player)
    {
        int move = 0;
        int value = 0;
        int maxEval;
        int minEval;

        if (depth == 0)
        {
            return pos;
        }
        else if (maximizing_player)
        {
            maxEval = -100000;
            game_moves[pos-1] = 1; //Temporarily set their move on board
            for (int i = 1; i < 10; i++) 
            {
                if (check_available(i)) //First check if a move can be played at the position
                {
                    
                }
            }

            game_moves[pos-1] = 0; //Revert move back
        }
        else
        {
            minEval = 100000;
            game_moves[pos-1] = 2; //Temporarily set their move on board
            for (int i = 1; i < 10; i++) 
            {
                if (check_available(i)) //First check if a move can be played at the position
                {

                }
            }

            game_moves[pos-1] = 0; //Revert move back
        }

        return move;
    }

    /// <summary>
    /// Method <c>evaluate</c> evaluates the value of making a move at this point, for the given player.
    /// </summary>
    /// <param name="move">The chosen move.</param>
    /// <param name="player1">True if player1, false if player2.</param>
    /// <returns>The value of making a move at this point for the given player.</returns>
    int evaluate(int move, bool player1)
    {
        int value = 0;

        return value;
    }

    /// <summary>
    /// Method checks the availability of the given move.
    /// </summary>
    /// <param name="move">The chosen move of the player to be checked.</param>
    /// <returns>true if available; false otherwise.</returns>
    bool check_available(int move)
    {
        if (game_moves[move - 1] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Method <c>rock_paper_scissors</c> Facilitates a game of rock, paper, scissors between the two players.
    /// </summary>
    /// <returns>True if player1 wins, false if player2 wins.</returns>
    bool rock_paper_scissors()
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
                case 0:
                    slow_type("Rock!", 150);
                    break;

                case 1:
                    slow_type("Paper!", 150);
                    break;

                case 2:
                    slow_type("Scissors!", 150);
                    break;

                default:
                    Console.Write("ERROR!");
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