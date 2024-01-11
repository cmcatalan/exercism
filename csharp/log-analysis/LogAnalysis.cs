public static class LogAnalysis
{
    private static readonly string[] _logLevels = { "INFO", "WARNING", "ERROR" };

    public static string SubstringAfter(this string word, string toSubstitute)
    {
        var index = word.IndexOf(toSubstitute);

        if (index != -1) return word[(index + toSubstitute.Length)..];

        return word;
    }

    public static string SubstringBetween(this string word, string firstOcurrence, string secondOcurrence)
    {
        var start = word.IndexOf(firstOcurrence);
        var end = word.IndexOf(secondOcurrence);

        if (start > -1 && end > -1) return word[(start + firstOcurrence.Length)..end];

        return string.Empty;
    }

    public static string Message(this string word)
    {
        for (var i = 0; i < _logLevels.Length; i++)
        {
            var logLevel = $"[{_logLevels[i]}]: ";
            if (word.StartsWith(logLevel)) return word.SubstringAfter(logLevel);
        }

        return word;
    }

    public static string LogLevel(this string word) => word.SubstringBetween("[", "]");
}