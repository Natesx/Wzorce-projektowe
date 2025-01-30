using System;
using System.Collections.Generic;

// Interfejs podmiotu (Subject)
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Interfejs obserwatora (Observer)
public interface IObserver
{
    void Update(int temperature, int humidity);
}

// Klasa reprezentująca stację pogodową
public class WeatherStation : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private int _temperature;
    private int _humidity;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature, _humidity);
        }
    }

    public void SetWeather(int temperature, int humidity)
    {
        _temperature = temperature;
        _humidity = humidity;
        Notify();
    }
}

// Klasa wyświetlająca aktualne warunki pogodowe
public class CurrentConditionsDisplay : IObserver
{
    public void Update(int temperature, int humidity)
    {
        Console.WriteLine($"Aktualne warunki: {temperature}°C, {humidity}% wilgotności");
    }
}

// Klasa prognozy pogody
public class ForecastDisplay : IObserver
{
    public void Update(int temperature, int humidity)
    {
        string forecast = humidity > 70 ? "Deszczowo" : "Słonecznie";
        Console.WriteLine($"Prognoza pogody: {forecast}");
    }
}

// Program testowy
class Program
{
    static void Main()
    {
        // Tworzenie stacji pogodowej
        WeatherStation station = new WeatherStation();
        IObserver currentDisplay = new CurrentConditionsDisplay();
        IObserver forecastDisplay = new ForecastDisplay();

        // Dodawanie obserwatorów
        station.Attach(currentDisplay);
        station.Attach(forecastDisplay);

        // Aktualizacja pogody
        Console.WriteLine("=== Aktualizacja 1 ===");
        station.SetWeather(22, 65);

        Console.WriteLine("\n=== Aktualizacja 2 ===");
        station.SetWeather(18, 80);
    }
}
