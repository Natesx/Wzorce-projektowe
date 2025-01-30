using System;

// Interfejs loggera, który był używany przez starą bibliotekę logowania
public interface ILoggerInterface
{
    void Log(string message);
}

// Nowa biblioteka rejestrowania, która ma inny interfejs
public class NewLogger
{
    public void WriteLog(string msg)
    {
        Console.WriteLine("NewLogger: " + msg);
    }
}

// Adapter, który pozwala nowej bibliotece działać jak stara
public class LoggerAdapter : ILoggerInterface
{
    private readonly NewLogger _newLogger;

    public LoggerAdapter()
    {
        _newLogger = new NewLogger();
    }

    public void Log(string message)
    {
        _newLogger.WriteLog(message);
    }
}

// Testowanie adaptera
class Program
{
    static void Main()
    {
        ILoggerInterface adapter = new LoggerAdapter();
        adapter.Log("To jest testowa wiadomość"); // Powinno użyć nowego loggera
    }
}
