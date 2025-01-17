using System;
using System.IO;

namespace TicTacToe.Utils
{
    public class Logger
    {
        private readonly string logPath;
        
        public Logger()
        {
            logPath = Path.Combine(Directory.GetCurrentDirectory(), "logs", "ai_moves.log");
            Directory.CreateDirectory(Path.GetDirectoryName(logPath));
        }

        public void LogMove(int position, int score)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Position: {position}, Score: {score}";
            File.AppendAllText(logPath, logMessage + Environment.NewLine);
        }
    }
}