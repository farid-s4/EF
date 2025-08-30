using System.IO;

namespace AutoService.Services;

using Microsoft.Extensions.Logging;
public class MyLoggerProvider : ILoggerProvider
{
    private readonly string _filePath;
    private readonly object _lock = new object();

    public MyLoggerProvider(string filePath)
    {
        _filePath = filePath;

        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }
    
    public ILogger CreateLogger(string categoryName)
    {
        return new MyLogger(_filePath, _lock, categoryName);
    }

    public void Dispose() { }

    private class MyLogger : ILogger
    {
        private readonly string _filePath;
        private readonly object _lock;
        private readonly string _category;

        public MyLogger(string filePath, object @lock, string category)
        {
            _filePath = filePath;
            _lock = @lock;
            _category = category;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>
            (
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception, string>? formatter)
        {
            if (formatter == null) return;

            var message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | " +
                          $"{logLevel,-11} | " +
                          $"EventId: {eventId.Id} | " +
                          $"Category: {_category} | " +
                          $"{formatter(state, exception)}";

            if (exception != null)
            {
                message += Environment.NewLine + $"Exception: {exception}";
            }

            lock (_lock)
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}