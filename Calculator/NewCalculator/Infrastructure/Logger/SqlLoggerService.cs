using NewCalculator.Core.Interfaces;

namespace NewCalculator.Infrastructure.Logger
{
    public class SqlLoggerService : ILoggerService
    {
        private readonly string _connectionString;

        public SqlLoggerService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void LogError(string message, Exception? exception)
        {
            WriteToDatabase("Error", $"{message}, Exception: {exception?.Message}");
        }

        public void LogInfo(string message)
        {
            WriteToDatabase("Information", message);
        }

        public void LogWarning(string message)
        {
            WriteToDatabase("Warning", message);
        }

        private static void WriteToDatabase(string level, string message)
        {
            // Code removed for clearity
        }
    }
}
