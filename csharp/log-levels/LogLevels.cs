static class LogLine
{
    private static readonly string[] _logLevels = { "INFO", "WARNING", "ERROR" };
    public static string Message(string logLine)
    {
        for (var i = 0; i < _logLevels.Length; i++)
        {
            var logLevel = $"[{_logLevels[i]}]:";
            if (logLine.StartsWith(logLevel)) return logLine.Replace(logLevel, string.Empty).Trim();
        }

        return logLine;
    }

    public static string LogLevel(string logLine)
    {
        for (var i = 0; i < _logLevels.Length; i++)
        {
            var logLevel = $"[{_logLevels[i]}]:";
            if (logLine.StartsWith(logLevel)) return _logLevels[i].ToLower();
        }

        return _logLevels[0].ToLower();
    }

    public static string Reformat(string logLine)
    {
        for (var i = 0; i < _logLevels.Length; i++)
        {
            var logLevel = $"[{_logLevels[i]}]:";
            if (logLine.StartsWith(logLevel)) return $"{logLine.Replace(logLevel, string.Empty).Trim()} ({_logLevels[i].ToLower()})";
        }

        return logLine;
    }
}
