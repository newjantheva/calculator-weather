using NewCalculator.Core.Interfaces;

namespace NewCalculator.Infrastructure.Logger
{
    public class FileLoggerService : ILoggerService
    {
        private readonly string _filePath;

        public FileLoggerService(string filePath)
        {
            _filePath = filePath;
        }

        public void LogError(string message, Exception? exception)
        {
            WriteToFile($"[Error]: {message}, Exception: {exception?.Message}");
        }

        public void LogInfo(string message)
        {
            WriteToFile($"[Info]: {message}");
        }

        public void LogWarning(string message)
        {
            WriteToFile($"[Warning]: {message}");
        }

        private void WriteToFile(string logMessage)
        {
            File.AppendAllText(_filePath, $"{DateTime.Now}: {logMessage}{Environment.NewLine}");
        }
    }
}
