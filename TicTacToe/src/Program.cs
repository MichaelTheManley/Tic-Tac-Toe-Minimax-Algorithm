// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.Run();


namespace TicTacToe
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Program
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Game game = new Game(player1, player2);

            game.start();
        }
    }
}