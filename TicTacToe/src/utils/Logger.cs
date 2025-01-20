using System;
using System.IO;
using System.Reflection;

namespace TicTacToe.Utils
{
    public class Logger
    {
        private readonly string logPath;

        public Logger()
        {
            try
            {
                // Get executable path
                string exePath = Assembly.GetExecutingAssembly().Location;
                // Navigate up to project root (3 levels up from bin/Debug/net8.0)
                string exeDir = Path.GetDirectoryName(exePath) ?? throw new InvalidOperationException("Executable directory not found");
                string projectRoot = Path.GetFullPath(Path.Combine(exeDir, "..", "..", ".."));
                string logDir = Path.Combine(projectRoot, "logs");
                logPath = Path.Combine(logDir, "ai_moves.log");

                Console.WriteLine($"Project root: {projectRoot}");
                Console.WriteLine($"Log directory: {logDir}");
                Console.WriteLine($"Log file path: {logPath}");

                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                    Console.WriteLine("Created log directory");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logger initialization error: {ex}");
                throw;
            }
        }

        public void LogPotentialMove(int position, int score)
        {
            try
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Potential Position: {position}, Score: {score}";
                File.AppendAllText(logPath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging error: {ex}");
                throw;
            }
        }

        public void LogBestMove(int player_num, int position, int score)
        {
            try
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Best score for player {player_num} after position {position} played => Score: {score}";
                File.AppendAllText(logPath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging error: {ex}");
                throw;
            }
        }

        public void PrintBoard(int[] game_moves)
        {
            try
            {
                string board = $" {game_moves[0]} | {game_moves[1]} | {game_moves[2]} \n" +
                            $"---|---|---\n" +
                            $" {game_moves[3]} | {game_moves[4]} | {game_moves[5]} \n" +
                            $"---|---|---\n" +
                            $" {game_moves[6]} | {game_moves[7]} | {game_moves[8]} ";
                File.AppendAllText(logPath, board + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging error: {ex}");
                throw;
            }
        }

        public void PrintLine()
        {
            try
            {
                File.AppendAllText(logPath, "-----------------------------------" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging error: {ex}");
                throw;
            }
        }
    }
}