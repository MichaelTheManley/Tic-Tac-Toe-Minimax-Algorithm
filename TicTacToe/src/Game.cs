using System;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using TicTacToe.Utils;

/// <summary>
/// TODO
/// </summary>
class Game
{
    /// <summary>
    /// TODO
    /// </summary>
    private readonly Logger _logger = new Logger();

    public Logger logger
    {
        get { return _logger; }
    }

    private int[] _game_moves = new int[9];
    public int[] game_moves
    {
        get { return _game_moves; }
        set { _game_moves = value; }
    }
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

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    public Game(Player p1, Player p2)
    {
        _player1 = p1;
        _player2 = p2;
    }

    public Game(Player p1, Player p2, int test_case)
    {
        _player1 = p1;
        _player2 = p2;
        _logger = new Logger(test_case);
    }

    /// <summary>
    /// TODO
    /// </summary>
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

    /// <summary>
    /// TODO
    /// </summary>
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
                game_moves[p1_move - 1] = 1;
                print_board();
            }
            else
            {
                p2_move = get_player2_move();
                game_moves[p2_move - 1] = 2;
                print_board();
            }
            player1.isTurn = !player1.isTurn;
            player2.isTurn = !player2.isTurn;
            if (check_win())
            {
                winner = true;
            }
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// TODO
    /// </summary>
    /// <returns></returns>
    public int get_player2_move()
    {
        int chosen_move_value = 0;
        int best_move_value = -100000;
        int best_move = 0;

        Console.Write("SYSTEM: ");
        slow_type("Player 2, which tile do you choose? [1-9]", 100);

        for (int i = 1; i < 10; i++)
        {
            if (check_available(i)) //First check if a move can be played at the position
            {
                game_moves[i - 1] = 2; //Temporarily set the AI on board
                chosen_move_value = minimax(i, 3, false); //Since we are doing an iteration initially within this code block, we must set the
                                                          //maximizing player to false as the AI is initially making a move here. Thus, it will
                                                          //be the minimizing player to play next and so we pass through false (since player
                                                          //1 is the minimizing player and player 2 is the AI [maximizing player]).
                if (chosen_move_value > best_move_value)
                {
                    best_move_value = chosen_move_value;
                    best_move = i;
                }
                game_moves[i - 1] = 0; //Revert move back
            }
        }

        return best_move;
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="depth"></param>
    /// <param name="maximizing_player"></param>
    /// <returns></returns>
    int minimax(int pos, int depth, bool maximizing_player)
    {
        int value;
        int maxEval;
        int minEval;

        if (depth == 0)
        {
            return evaluate();
        }
        else if (maximizing_player)
        {
            maxEval = -100000;
            if (check_win())
            {
                return evaluate();
            }
            else if (depth == 1) //This removes unnecessary recursion
            {
                value = minimax(1, depth - 1, false);
                maxEval = value > maxEval ? value : maxEval;
                _logger.PrintBoard(game_moves);
                _logger.PrintLine();
            }
            else
            {
                for (int i = 1; i < 10; i++)
                {
                    if (check_available(i)) //First check if a move can be played at the position
                    {
                        game_moves[pos - 1] = 1; //Temporarily set the AI on board
                        value = minimax(i, depth - 1, false);
                        maxEval = value > maxEval ? value : maxEval;
                        game_moves[pos - 1] = 0; //Temporarily set the AI on board
                    }
                }
                _logger.LogBestMove(2, pos, maxEval);
            }
            return maxEval;
        }
        else
        {
            minEval = 100000;
            if (check_win())
            {
                return evaluate();
            }
            else if (depth == 1) //This removes unnecessary recursion
            {
                value = minimax(1, depth - 1, true);
                minEval = value < minEval ? value : minEval;
                _logger.PrintBoard(game_moves);
                _logger.PrintLine();
            }
            else
            {
                for (int i = 1; i < 10; i++)
                {
                    if (check_available(i)) //First check if a move can be played at the position
                    {
                        game_moves[pos - 1] = 2; //Temporarily set their move on board
                        value = minimax(i, depth - 1, true);
                        minEval = value < minEval ? value : minEval;
                        game_moves[pos - 1] = 0; //Temporarily set their move on board
                    }
                }
                _logger.LogBestMove(1, pos, minEval);
            }
            return minEval;
        }
    }

    /// <summary>
    /// Method <c>evaluate</c> evaluates the value of the board.
    /// </summary>
    /// <returns>The value of the board, where a high number favours p2, and a low number favours p1.</returns>
    public int evaluate()
    {
        //Credit to https://www3.ntu.edu.sg/home/ehchua/programming/java/JavaGame_TicTacToe_AI.html

        int value = 0;

        value += check_all(false) - check_all(true); //Subtract p1's as p1 is minimizing.

        return value;
    }

    /// <summary>
    /// Method <c>check_all</c> checks all rows, columns and diagonals for the given player and returns the value of their board
    /// by assigning 100 points for any 3 in a row, column or diagonal, 10 points for any 2, and 1 point for any 1.
    /// </summary>
    /// <param name="player1">The player the method is checking and evaluating for.</param>
    /// <returns>The value of the player's board.</returns>
    public int check_all(bool player1)
    {
        int value = 0;
        int[,] count = new int[3, 3];
        int match = player1 ? 1 : 2;

        // Checking rows
        for (int i = 0; i < 3; i++) //Row
        {
            for (int j = 0; j < 3; j++) //Column
            {
                if (game_moves[i * 3 + j] == match)
                {
                    count[0, i] += 1;
                }
            }
        }

        // Checking columns
        for (int i = 0; i < 3; i++) //Column
        {
            for (int j = 0; j < 3; j++) //Row
            {
                if (game_moves[i + j * 3] == match)
                {
                    count[1, i] += 1;
                }
            }
        }

        // Checking diagonals
        for (int i = 0; i < 3; i++) //Check right diagonal
        {
            if (game_moves[i * 3 + i] == match)
            {
                count[2, 0] += 1;
            }
        }
        for (int i = 0; i < 3; i++) //Check left diagonal
        {
            if (game_moves[6 - i * 2] == match)
            {
                count[2, 1] += 1;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                switch (count[i, j])
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
        }

        return value;
    }

    /// <summary>
    /// Method checks the availability of the given move.
    /// </summary>
    /// <param name="move">The chosen move of the player to be checked.</param>
    /// <returns>true if available; false otherwise.</returns>
    public bool check_available(int move)
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
    /// Method <c>check_win</c> checks if a player has won the game.
    /// </summary>
    /// <returns>True if a player has won; false otherwise.</returns>
    bool check_win()
    {
        Boolean win = false;

        int player1 = check_all(true);
        int player2 = check_all(false);

        if (player1 > 100 || player2 > 100)
        {
            win = true;
        }

        return win;
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
        slow_type("We will begin Tic Tac Toe by seeing who will start. This is decided with Rock, Paper, Scissors.", 50);
        Console.Write("SYSTEM: ");
        slow_type("You may quit at any time by typing 'Q'.", 50);
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
                    slow_type("Please enter either [R] => Rock, [P] => Paper or [S] => Scissors.", 50);
                    slow_type("PLAYER 1: ", 50);
                }
            } while ((p1_input != "R") && (p1_input != "P") && (p1_input != "S") && (p1_input != "Q"));

            if (p1_input == "Q")
            {
                Console.Write("SYSTEM: ");
                slow_type("Goodbye!", 50);
                slow_type("and goodluck...", 400);
                Environment.Exit(0);
            }

            Console.Write("SYSTEM: ");
            slow_type("Player 2, choose your move!", 50);
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

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="sentence"></param>
    /// <param name="time"></param>
    static void slow_type(string sentence, int time)
    {
        foreach (char c in sentence)
        {
            System.Threading.Thread.Sleep(time);
            Console.Write(c);
        }
        Console.WriteLine("");
    }

    /// <summary>
    /// Print the board to the console.
    /// </summary>
    void print_board()
    {
        Console.WriteLine(" " + game_moves[0] + " | " + game_moves[1] + " | " + game_moves[2] + " ");
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + game_moves[3] + " | " + game_moves[4] + " | " + game_moves[5] + " ");
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + game_moves[6] + " | " + game_moves[7] + " | " + game_moves[8] + " ");
        Console.WriteLine("");
    }
}