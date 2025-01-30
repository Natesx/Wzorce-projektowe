using System;

// Interfejs kawy
public interface ICoffee
{
    double GetCost();
    string GetDescription();
}

// Podstawowa kawa (komponent bazowy)
public class BasicCoffee : ICoffee
{
    public double GetCost()
    {
        return 5;
    }

    public string GetDescription()
    {
        return "Basic Coffee";
    }
}

// Klasa bazowa dla dekoratorów (dekorator abstrakcyjny)
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual double GetCost()
    {
        return _coffee.GetCost();
    }

    public virtual string GetDescription()
    {
        return _coffee.GetDescription();
    }
}

// Dekorator dodający mleko
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override double GetCost()
    {
        return _coffee.GetCost() + 2;
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Milk";
    }
}

// Dekorator dodający cukier
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override double GetCost()
    {
        return _coffee.GetCost() + 1;
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Sugar";
    }
}

// Testowanie wzorca Dekorator
class Program
{
    static void Main()
    {
        ICoffee coffee = new BasicCoffee();
        Console.WriteLine($"Order: {coffee.GetDescription()}, Cost: {coffee.GetCost()}$");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"Order: {coffee.GetDescription()}, Cost: {coffee.GetCost()}$");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"Order: {coffee.GetDescription()}, Cost: {coffee.GetCost()}$");
    }
}
