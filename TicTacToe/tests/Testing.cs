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
        /// Method <c>Test2</c> tests the <c>test_values_player2</c> method.
        /// </summary>
        [Fact]
        public void Test1()
        {
            int player1_total = 0;
            Player player1 = new Player();
            player1.isTurn = true;
            Player player2 = new Player();
            Game game = new Game(player1, player2);

            player1_total = game.test_values_player1();

            Assert.Equal(151, player1_total);
        }

        /// <summary>
        /// Method <c>Test2</c> tests the <c>test_values_player2</c> method.
        /// </summary>
        [Fact]
        public void Test2()
        {
            int player2_total = 0;
            Player player1 = new Player();
            player1.isTurn = true;
            Player player2 = new Player();
            Game game = new Game(player1, player2);

            player2_total = game.test_values_player2();

            Assert.Equal(115, player2_total);
        }

        /// <summary>
        /// Method <c>Test3</c> tests the <c>simulate_player1_winning</c> method.
        /// </summary>
        [Fact]
        public void Test3()
        {
            int player1_total = 0;
            Player player1 = new Player();
            player1.isTurn = true;
            Player player2 = new Player();
            Game game = new Game(player1, player2);

            player1_total = game.simulate_player1_winning();

            Assert.Equal(-12, player1_total);
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

            taken = game.test_position();

            Assert.False(taken);
        }
    }
}