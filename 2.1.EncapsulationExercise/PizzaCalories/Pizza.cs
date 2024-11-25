using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories;

public class Pizza 
{
    private readonly List<Topping> _toppings;

    public Pizza(string name, Dough dough)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Count() > 15) { throw new ArgumentException($"Pizza name should be between 1 and 15 symbols."); }
        
        this.Name = name;
        this.Dough = dough;

        this._toppings = new List<Topping>();
        this.Toppings = this._toppings.AsReadOnly();
    }

    public string Name { get; }
    private IReadOnlyCollection<Topping> Toppings { get; }
    private Dough Dough { get; }

    public double Calories => Dough.CaloriesPerGram + _toppings.Sum(t => t.ToppingCalorieserGram);

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories:F2} Calories.";
    }

    public void AddTopping(string[] ingredients)
    {
        string toppingName = ingredients[1];
        int grams = int.Parse(ingredients[2]);

        Topping topping = new Topping(toppingName, grams);

        if (Toppings.Count == 10) { throw new InvalidOperationException($"Number of toppings should be in range [0..10]."); } 
        _toppings.Add(topping);
    }
}
