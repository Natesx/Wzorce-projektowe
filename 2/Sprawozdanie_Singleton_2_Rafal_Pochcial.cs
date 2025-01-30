using System;
using System.Collections.Generic;

public class PrintBuffer
{
    private static PrintBuffer _instance;
    private static readonly object _lock = new object();
    private Queue<string> _jobQueue;

    // Prywatny konstruktor, aby zapobiec tworzeniu instancji z zewnątrz
    private PrintBuffer()
    {
        _jobQueue = new Queue<string>();
    }

    // Metoda dostępu do jedynej instancji klasy (Singleton)
    public static PrintBuffer GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock) // Zapewnia bezpieczeństwo wątkowe
            {
                if (_instance == null)
                {
                    _instance = new PrintBuffer();
                }
            }
        }
        return _instance;
    }

    // Metoda dodawania zadania do kolejki
    public void AddJob(string job)
    {
        _jobQueue.Enqueue(job);
        Console.WriteLine($"Added job: {job}");
    }

    // Metoda przetwarzania zadania z kolejki
    public void ProcessJob()
    {
        if (_jobQueue.Count > 0)
        {
            string job = _jobQueue.Dequeue();
            Console.WriteLine($"Processing job: {job}");
        }
        else
        {
            Console.WriteLine("No jobs to process.");
        }
    }
}

// Testowanie bufora wydruku (Singleton)
class Program
{
    static void Main()
    {
        PrintBuffer buffer1 = PrintBuffer.GetInstance();
        buffer1.AddJob("Drukowanie raportu");
        buffer1.AddJob("Drukowanie faktury");

        PrintBuffer buffer2 = PrintBuffer.GetInstance();
        buffer2.ProcessJob();
        buffer2.ProcessJob();
        buffer2.ProcessJob();  // Nie ma więcej zadań

        // Sprawdzenie, czy obie zmienne wskazują na tę samą instancję
        Console.WriteLine(ReferenceEquals(buffer1, buffer2)); // Powinno zwrócić True
    }
}
