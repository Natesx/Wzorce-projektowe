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
    void Update(Dictionary<string, int> scores);
}

// Klasa reprezentująca grę i tablicę wyników
public class Game : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private Dictionary<string, int> _scores = new Dictionary<string, int>();

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
            observer.Update(_scores);
        }
    }

    public void UpdateScore(string player, int score)
    {
        _scores[player] = score;
        Notify();
    }
}

// Klasa reprezentująca gracza
public class Player : IObserver
{
    private string _name;
    private int _score;

    public Player(string name)
    {
        _name = name;
        _score = 0;
    }

    public void Update(Dictionary<string, int> scores)
    {
        _score = scores.ContainsKey(_name) ? scores[_name] : 0;
        Console.WriteLine($"{_name}: Nowy wynik: {_score}");
    }
}

// Program testowy
class Program
{
    static void Main()
    {
        // Tworzenie gry i graczy
        Game game = new Game();
        IObserver player1 = new Player("Alice");
        IObserver player2 = new Player("Bob");
        IObserver player3 = new Player("Charlie");

        // Dodawanie graczy do obserwacji
        game.Attach(player1);
        game.Attach(player2);
        game.Attach(player3);

        // Aktualizacja wyników
        Console.WriteLine("=== Aktualizacja wyników ===");
        game.UpdateScore("Alice", 10);
        game.UpdateScore("Bob", 15);
        game.UpdateScore("Charlie", 20);
    }
}
