using NewCalculator.Core.Interfaces;

namespace NewCalculator.Infrastructure.Logger
{
    public class ConsoleLoggerService : ILoggerService
    {
        public void LogError(string message, Exception? exception)
        {
            Console.WriteLine($"[Error]: {message}, Exception: {exception?.Message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"[Info]: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"[Warning]: {message}");
        }
    }
}
