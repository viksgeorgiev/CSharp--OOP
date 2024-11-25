using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories;

public class Topping
{
    public Topping(string toppingType, int grams)
    {
        if (!ToppingModifiers.ContainsKey(toppingType)) { throw new ArgumentException($"Cannot place {toppingType} on top of your pizza."); }
        if (grams < 1 || grams > 50) { throw new ArgumentException($"{toppingType} weight should be in the range [1..50]."); }
        this.ToppingType = toppingType;
        this.Grams = grams;
    }

    public string ToppingType { get; }
    public int Grams { get; }

    private static readonly Dictionary<string, double> ToppingModifiers = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase)
    {
        ["Meat"] = 1.2,
        ["Veggies"] = 0.8,
        ["Cheese"] = 1.1,
        ["Sauce"] = 0.9
    };

    public double ToppingCalorieserGram => (2 * Grams) * ToppingModifiers[ToppingType];
}
