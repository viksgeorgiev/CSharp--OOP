using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ShoppingSpree;

public class Person
{
    public Person(string name, decimal money)
    {
        if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentException($"Name cannot be empty"); }
        if (money < 0) { throw new ArgumentException($"Money cannot be negative"); }

        this.Name = name;
        this.Money = money;
        this.BagOfProducts = new List<Product>();
    }

    public string Name { get; }
    public decimal Money { get; private set; }
    public List<Product> BagOfProducts { get; private set; }

    public override string ToString()
    {
        if (BagOfProducts.Count > 0)
        {
            return $"{this.Name} - {string.Join(", ", BagOfProducts)}";
        }
        else
        {
            return $"{this.Name} - Nothing bought";
        }
    }

    public static void TryBuyProduct(Person person,Product product)
    {
        if (person.Money - product.Cost >= 0)
        {
            person.Money -= product.Cost;
            person.BagOfProducts.Add(product);
            Console.WriteLine($"{person.Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{person.Name} can't afford {product.Name.ToString()}");
        }
    }
}
