using NewCalculator.Core.Interfaces;

namespace NewCalculator.Infrastructure.Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly IEnumerable<ILoggerService> _loggers; // Using IEnumerable rather than List to avoid tying the code to a specific collection type.

        public LoggerService(IEnumerable<ILoggerService> loggers)
        {
            _loggers = loggers;
        }

        public void LogError(string message, Exception? exception = null)
        {
            PerformLogging(message, exception);
        }

        public void LogInfo(string message)
        {
            PerformLogging(message);

        }

        public void LogWarning(string message)
        {
            PerformLogging(message);
        }

        private void PerformLogging(string message, Exception? exception = null)
        {
            foreach (var logger in _loggers)
            {
                logger.LogError(message, exception);
            }
        }
    }
}
