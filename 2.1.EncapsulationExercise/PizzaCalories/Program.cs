namespace PizzaCalories
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                string input = Console.ReadLine();
                string[] ingredients = input.Split();


                string pizzaName = ingredients[1];

                input = Console.ReadLine();
                ingredients = input.Split();

                string typeOfDough = ingredients[1];
                string bakingTechnique = ingredients[2];
                int grams = int.Parse(ingredients[3]);

                Dough dough = new Dough(typeOfDough, bakingTechnique, grams);
                Pizza pizza = new Pizza(pizzaName, dough);

                input = Console.ReadLine();
                
                while (input != "END")
                {
                    ingredients = input.Split();
                    pizza.AddTopping(ingredients);
                   
                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
