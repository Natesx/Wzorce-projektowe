using System;
using System.Collections.Generic;

// Klasa reprezentująca pizzę
public class Pizza
{
    public string Dough { get; set; } = "";
    public string Meat { get; set; } = "";
    public string Cheese { get; set; } = "";
    public List<string> Veggies { get; set; } = new List<string>();
    public List<string> Spices { get; set; } = new List<string>();

    // Metoda do wyświetlania informacji o pizzy
    public void Show()
    {
        Console.WriteLine($"Pizza z: {Dough}, {Meat}, {Cheese}, {string.Join(", ", Veggies)}, {string.Join(", ", Spices)}");
    }
}

// Interfejs budowniczego
public interface IPizzaBuilder
{
    void SetDough(string dough);
    void SetMeat(string meat);
    void SetCheese(string cheese);
    void SetVeggies(List<string> veggies);
    void SetSpices(List<string> spices);
    Pizza GetPizza();
}

// Konkretna implementacja budowniczego
public class ConcretePizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void SetDough(string dough) => _pizza.Dough = dough;
    public void SetMeat(string meat) => _pizza.Meat = meat;
    public void SetCheese(string cheese) => _pizza.Cheese = cheese;
    public void SetVeggies(List<string> veggies) => _pizza.Veggies = veggies;
    public void SetSpices(List<string> spices) => _pizza.Spices = spices;
    public Pizza GetPizza() => _pizza;
}

// Klasa Director – zarządza procesem budowy pizzy
public class Director
{
    public void Construct(IPizzaBuilder builder)
    {
        builder.SetDough("Cienkie ciasto");
        builder.SetMeat("Pepperoni");
        builder.SetCheese("Mozzarella");
        builder.SetVeggies(new List<string> { "Pomidory", "Oliwki" });
        builder.SetSpices(new List<string> { "Oregano", "Bazylia" });
    }
}

// Klasa obsługująca proces zamówienia pizzy
public class PizzaOrder
{
    private readonly IPizzaBuilder _builder;
    private readonly Director _director;

    public PizzaOrder()
    {
        _builder = new ConcretePizzaBuilder();
        _director = new Director();
    }

    public Pizza CreatePizza()
    {
        _director.Construct(_builder);
        return _builder.GetPizza();
    }
}

// Testowanie procesu budowy pizzy
class Program
{
    static void Main()
    {
        PizzaOrder pizzaOrder = new PizzaOrder();
        Pizza pizza = pizzaOrder.CreatePizza();
        pizza.Show();  // Powinna wyświetlić informacje o pizzy
    }
}
