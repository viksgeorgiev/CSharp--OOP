using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories;

public class Dough 
{
    public string FlourType { get; }
    public string BakingTechnique { get; }
    public int Grams { get; }



    private static readonly Dictionary<string, double> FlourTypeModifiers = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase)
    {
        ["White"] = 1.5,
        ["Wholegrain"] = 1.0
    };
    private static readonly Dictionary<string, double> BakingTechniqueModifiers = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase)
    {
        ["Crispy"] = 0.9,
        ["Chewy"] = 1.1,
        ["Homemade"] = 1.0
    };

    public Dough(string flourType, string bakingTechnique, int grams)
    {
        if (!FlourTypeModifiers.ContainsKey(flourType)) { throw new ArgumentException("Invalid type of dough."); }
        if (!BakingTechniqueModifiers.ContainsKey(bakingTechnique)) { throw new ArgumentException("Invalid type of dough."); }
        if (grams < 1 || grams > 200) { throw new ArgumentException("Dough weight should be in the range [1..200]."); }

        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Grams = grams;
    }

    public double CaloriesPerGram => (2 * this.Grams)
                * FlourTypeModifiers[this.FlourType]
                * BakingTechniqueModifiers[BakingTechnique];
}
