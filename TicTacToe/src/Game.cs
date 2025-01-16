using System;
using System.Text.RegularExpressions;
using System.Windows.Markup;

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
        int chosen_move_value = 0;
        int best_move_value = -100000;
        int best_move = 0;

        do
        {
            Console.Write("SYSTEM: ");
            slow_type("Player 2, which tile do you choose? [1-9]", 100);

            for (int i = 1; i < 10; i++)
            {
                if (check_available(i)) //First check if a move can be played at the position
                {
                    chosen_move_value = minimax(i, 2, true);
                    if (chosen_move_value > best_move_value)
                    {
                        best_move_value = chosen_move_value;
                        best_move = i;
                    }
                }
            }

        } while (invalid);

        return best_move;
    }

    int minimax(int pos, int depth, bool maximizing_player)
    {
        int value;
        int maxEval;
        int minEval;

        if (depth == 0)
        {
            return evaluate(); //Maximizing player is player 2, thus pass through the NOT of it for player1.
        }
        else if (maximizing_player)
        {
            maxEval = -100000;
            game_moves[pos - 1] = 1; //Temporarily set their move on board
            for (int i = 1; i < 10; i++)
            {
                if (check_available(i)) //First check if a move can be played at the position
                {
                    value = minimax(i, depth - 1, false);
                    maxEval = value > maxEval ? value : maxEval;
                }
            }
            game_moves[pos - 1] = 0; //Revert move back
            return maxEval;
        }
        else
        {
            minEval = 100000;
            game_moves[pos - 1] = 2; //Temporarily set their move on board
            for (int i = 1; i < 10; i++)
            {
                if (check_available(i)) //First check if a move can be played at the position
                {
                    value = minimax(i, depth - 1, true);
                    minEval = value < minEval ? value : minEval;
                }
            }
            game_moves[pos - 1] = 0; //Revert move back
            return minEval;
        }
    }

    /// <summary>
    /// Method <c>evaluate</c> evaluates the value of the board.
    /// </summary>
    /// <returns>The value of the board, where a high number favours p2, and a low number favours p1.</returns>
    int evaluate()
    {
        //Credit to https://www3.ntu.edu.sg/home/ehchua/programming/java/JavaGame_TicTacToe_AI.html

        int value = 0;

        value += check_columns(false) - check_columns(true); //Subtract p1's as p1 is minimizing.
        

        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player1"></param>
    /// <returns></returns>
    int check_columns(bool player1)
    {
        int value = 0;
        int[] count = new int[3];
        int match = player1 ? 1 : 2;

        for (int j = 0; j < 3; j++)
        {
            for (int i = 1; i < 4; i++)
            {
                if (game_moves[i + (j * 3) - 1] == match)
                {
                    count[j] += 1;
                }
            }
        }

        for (int i = 0; i < 3; i++)
        {
            switch (count[i])
            {
                case 0:
                    value += 0;
                    break;

                case 1:
                    value += 1;
                    break;

                case 2:
                    value += 10;
                    break;

                case 3:
                    value += 100;
                    break;
            }
        }

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