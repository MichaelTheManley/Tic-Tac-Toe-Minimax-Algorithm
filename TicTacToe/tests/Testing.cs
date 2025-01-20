using Xunit;
using TicTacToe;

namespace TicTacToe.Tests
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Testing
    {
        /// <summary>
        /// Method <c>Test1</c> tests the <c>check_all</c> method for player 1.
        /// </summary>
        [Fact]
        public void Test1()
        {
            Player player1 = new Player();
            player1.isTurn = true;
            Player player2 = new Player();
            Game game = new Game(player1, player2);
            int total = 0;
            game.game_moves[0] = 1;
            game.game_moves[1] = 1;
            game.game_moves[2] = 1;
            game.game_moves[3] = 2;
            game.game_moves[4] = 2;
            game.game_moves[5] = 2;
            game.game_moves[6] = 1;
            game.game_moves[7] = 2;
            game.game_moves[8] = 1;
            total = game.check_all(true);

            Assert.Equal(151, total);
        }

        /// <summary>
        /// Method <c>Test2</c> tests the <c>check_all</c> method for player 2.
        /// </summary>
        [Fact]
        public void Test2()
        {
            Player player1 = new Player();
            player1.isTurn = true;
            Player player2 = new Player();
            Game game = new Game(player1, player2);
            int total = 0;
            game.game_moves[0] = 1;
            game.game_moves[1] = 1;
            game.game_moves[2] = 1;
            game.game_moves[3] = 2;
            game.game_moves[4] = 2;
            game.game_moves[5] = 2;
            game.game_moves[6] = 1;
            game.game_moves[7] = 2;
            game.game_moves[8] = 1;
            total = game.check_all(false);

            Assert.Equal(115, total);
        }

        /// <summary>
        /// Method <c>Test3</c> tests the <c>evaluate</c> method.
        /// </summary>
        [Fact]
        public void Test3()
        {
            int total = 0;
            Player player1 = new Player();
            player1.isTurn = true;
            Player player2 = new Player();
            Game game = new Game(player1, player2);

            game.game_moves[0] = 1;
            game.game_moves[1] = 0;
            game.game_moves[2] = 1;
            game.game_moves[3] = 2;
            total = game.evaluate();

            Assert.Equal(-12, total);
        }

        /// <summary>
        /// Method <c>Test4</c> tests the <c>check_available</c> method.
        /// </summary>
        [Fact]
        public void Test4()
        {
            Boolean taken = false;
            Player player1 = new Player();
            player1.isTurn = true;
            Player player2 = new Player();
            Game game = new Game(player1, player2);

            game.game_moves[5] = 1;
            taken = game.check_available(6);

            Assert.False(taken);
        }

        /// <summary>
        /// Method <c>Test5</c> tests the <c>minimax</c> method.
        /// </summary>
        [Fact]
        public void Test5()
        {
            int bestMove = 0;
            Player player1 = new Player();
            player1.isTurn = true;
            Player player2 = new Player();
            Game game = new Game(player1, player2);

            game.game_moves[0] = 1;
            game.game_moves[1] = 0;
            game.game_moves[2] = 1;
            game.game_moves[3] = 2;
            bestMove = game.get_player2_move();

            Assert.Equal(2, bestMove);
        }
    }
}