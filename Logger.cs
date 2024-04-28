using System;
using System.IO;

/// <summary>
/// Logger class for handling all logging operations within the game.
/// </summary>
public static class Logger
{
    private static readonly string logFilePath = "game_log.txt";

    /// <summary>
    /// Initializes the Logger by ensuring the log file exists.
    /// </summary>
    static Logger()
    {
        if (!File.Exists(logFilePath))
        {
            using (File.Create(logFilePath)) { }
        }
    }

    /// <summary>
    /// Logs a message with a timestamp.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public static void Log(string message)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to log message: {ex.Message}");
        }
    }

    /// <summary>
    /// Logs an error message with a timestamp.
    /// </summary>
    /// <param name="message">The error message to log.</param>
    public static void LogError(string message)
    {
        Log($"ERROR: {message}");
    }

    /// <summary>
    /// Logs a debug message with a timestamp, only if DEBUG is defined.
    /// </summary>
    /// <param name="message">The debug message to log.</param>
    public static void LogDebug(string message)
    {
        #if DEBUG
        Log($"DEBUG: {message}");
        #endif
    }
}
