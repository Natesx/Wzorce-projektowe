using System;
using System.Collections.Generic;

public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();
    private List<string> _logs;

    // Prywatny konstruktor, aby zapobiec tworzeniu instancji z zewnątrz
    private Logger()
    {
        _logs = new List<string>();
    }

    // Metoda dostępu do jedynej instancji klasy
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock) // Zapewnia bezpieczeństwo wątkowe
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }

    // Metoda do logowania komunikatów
    public void LogMessage(string message)
    {
        _logs.Add(message);
    }

    // Metoda do wyświetlania zapisanych logów
    public void ShowLogs()
    {
        foreach (var log in _logs)
        {
            Console.WriteLine(log);
        }
    }
}

// Testowanie klasy Singleton
class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        logger1.LogMessage("Pierwszy komunikat");

        Logger logger2 = Logger.GetInstance();
        logger2.LogMessage("Drugi komunikat");

        logger1.ShowLogs(); // Powinny zostać wyświetlone oba komunikaty

        // Sprawdzenie, czy obie zmienne wskazują na tę samą instancję
        Console.WriteLine(ReferenceEquals(logger1, logger2)); // Powinno zwrócić True
    }
}
