// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.Run();


namespace TicTacToe 
{

    class Program 
    {
        
        static void Main(string[] args) 
        {
            bool result = false;
            
            Player player1 = new Player(1, false);
            Player player2 = new Player(2, true);
            Game game = new Game(player1, player2);
            Game.start();
        }
    }
}