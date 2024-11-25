namespace ShoppingSpree;

public class Program
{
    public static void Main()
    {
        try
        {
            string name = Console.ReadLine();
            Dictionary<string, Person> people = InitialisePersonDict();
            Dictionary<string, Product> products = InitialiseProductDict();
            
           
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] purchaseInfo = input.Split(" ").ToArray();
                string buyer = purchaseInfo[0];
                string product = purchaseInfo[1];

                Person.TryBuyProduct(people[buyer], products[product]);

                input = Console.ReadLine();
            }
            foreach (var person in people.Values)
            {
                Console.WriteLine(person.ToString());
            }
        }
        catch (ArgumentException e)
        {

            Console.WriteLine(e.Message);
        }
        
    }
    private static Dictionary<string, Person> InitialisePersonDict()
    {
        List<string> input = Console.ReadLine()
            .Split(";", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        List<Person> personList = new List<Person>();

        foreach (string inputItem in input)
        {
            personList.Add(new Person(inputItem.Split("=")[0], decimal.Parse(inputItem.Split("=")[1])));
        }

        Dictionary<string, Person> personDictionary = personList.ToDictionary(p => p.Name);

        return personDictionary;
    }
    private static Dictionary<string, Product> InitialiseProductDict()
    {
        List<string> input = Console.ReadLine()
            .Split(";", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        List<Product> productList = new List<Product>();

        foreach (string inputItem in input)
        {
            productList.Add(new Product(inputItem.Split("=")[0], decimal.Parse(inputItem.Split("=")[1])));
        }

        Dictionary<string, Product> productDictionary = productList.ToDictionary(p => p.Name);

        return productDictionary;
    }
}
