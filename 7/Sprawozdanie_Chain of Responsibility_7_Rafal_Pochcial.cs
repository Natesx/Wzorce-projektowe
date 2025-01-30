using System;
using System.Collections.Generic;

// Abstrakcyjna klasa obsługi zgłoszeń (Handler)
public abstract class Handler
{
    protected Handler _nextHandler;

    public void SetNext(Handler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void HandleRequest(string requestType);
}

// Obsługa problemów technicznych
public class TechnicalSupportHandler : Handler
{
    public override void HandleRequest(string requestType)
    {
        if (requestType == "Technical")
        {
            Console.WriteLine("Obsługa problemu technicznego.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(requestType);
        }
    }
}

// Obsługa zapytań rozliczeniowych
public class BillingSupportHandler : Handler
{
    public override void HandleRequest(string requestType)
    {
        if (requestType == "Billing")
        {
            Console.WriteLine("Obsługa zapytania rozliczeniowego.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(requestType);
        }
    }
}

// Obsługa ogólnych zapytań
public class GeneralSupportHandler : Handler
{
    public override void HandleRequest(string requestType)
    {
        if (requestType == "General")
        {
            Console.WriteLine("Obsługa zapytania ogólnego.");
        }
        else
        {
            Console.WriteLine("Brak odpowiedniego handlera dla zgłoszenia.");
        }
    }
}

// Testowanie wzorca Chain of Responsibility
class Program
{
    static void Main()
    {
        // Tworzenie łańcucha odpowiedzialności
        Handler technical = new TechnicalSupportHandler();
        Handler billing = new BillingSupportHandler();
        Handler general = new GeneralSupportHandler();

        technical.SetNext(billing);
        billing.SetNext(general);

        // Testowanie
        List<string> requests = new List<string> { "Technical", "Billing", "General", "Unknown" };
        foreach (var req in requests)
        {
            Console.WriteLine($"Przetwarzanie zgłoszenia: {req}");
            technical.HandleRequest(req);
            Console.WriteLine();
        }
    }
}
