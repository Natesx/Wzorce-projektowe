using System;

// Klasa reprezentująca kwadrat
public class Square
{
    private double _side;

    public Square(double side)
    {
        _side = side;
    }

    public double GetSide()
    {
        return _side;
    }
}

// Interfejs dla figur geometrycznych
public interface IShape
{
    double GetArea();
}

// Adapter, który dostosowuje Square do interfejsu IShape
public class SquareAdapter : IShape
{
    private readonly Square _square;

    public SquareAdapter(Square square)
    {
        _square = square;
    }

    public double GetArea()
    {
        return Math.Pow(_square.GetSide(), 2);
    }
}

// Testowanie adaptera
class Program
{
    static void Main()
    {
        Square square = new Square(5);
        IShape adapter = new SquareAdapter(square);

        Console.WriteLine($"Obszar kwadratu: {adapter.GetArea()}");  // Powinno zwrócić 25
    }
}
