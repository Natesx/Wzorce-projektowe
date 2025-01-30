using System;
using System.Collections.Generic;

// Abstrakcyjna klasa Logger (Handler)
public abstract class Logger
{
    protected Logger _nextLogger;

    public void SetNext(Logger nextLogger)
    {
        _nextLogger = nextLogger;
    }

    public abstract void LogMessage(string level, string message);
}

// Obsługa logów informacyjnych
public class InfoLogger : Logger
{
    public override void LogMessage(string level, string message)
    {
        if (level == "INFO")
        {
            Console.WriteLine("INFO: " + message);
        }
        else if (_nextLogger != null)
        {
            _nextLogger.LogMessage(level, message);
        }
    }
}

// Obsługa logów ostrzeżeń
public class WarningLogger : Logger
{
    public override void LogMessage(string level, string message)
    {
        if (level == "OSTRZEŻENIE")
        {
            Console.WriteLine("OSTRZEŻENIE: " + message);
        }
        else if (_nextLogger != null)
        {
            _nextLogger.LogMessage(level, message);
        }
    }
}

// Obsługa logów błędów
public class ErrorLogger : Logger
{
    public override void LogMessage(string level, string message)
    {
        if (level == "BŁĄD")
        {
            Console.WriteLine("BŁĄD: " + message);
        }
        else
        {
            Console.WriteLine("Nieobsłużony poziom logowania: " + level);
        }
    }
}

// Testowanie wzorca Chain of Responsibility (Logger)
class Program
{
    static void Main()
    {
        // Tworzenie łańcucha loggerów
        Logger infoLogger = new InfoLogger();
        Logger warningLogger = new WarningLogger();
        Logger errorLogger = new ErrorLogger();

        infoLogger.SetNext(warningLogger);
        warningLogger.SetNext(errorLogger);

        // Testowanie logowania
        List<(string, string)> messages = new List<(string, string)>
        {
            ("INFO", "System uruchomiony."),
            ("OSTRZEŻENIE", "Niskie zasoby pamięci."),
            ("BŁĄD", "Błąd krytyczny!"),
            ("DEBUG", "Szczegółowe logowanie debug.")
        };

        foreach (var (level, message) in messages)
        {
            Console.WriteLine($"Logowanie komunikatu: {level}");
            infoLogger.LogMessage(level, message);
            Console.WriteLine();
        }
    }
}
