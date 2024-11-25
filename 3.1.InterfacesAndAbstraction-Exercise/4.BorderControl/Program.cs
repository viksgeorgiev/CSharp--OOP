namespace _4.BorderControl;

public class Program
{
    public static void Main()
    {
        List<Rebel> rebels = new List<Rebel>();
        List<Citizen> citizens = new List<Citizen>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Split();

            if (data.Length == 4)
            {
                string name = data[0];
                int age = int.Parse(data[1]);
                string id = data[2];
                string birthdate = data[3];

                Citizen citizen = new Citizen(name, age, id, birthdate);

                citizens.Add(citizen);
            }
            else if (data.Length == 3)
            {
                string name = data[0];
                int age = int.Parse(data[1]);
                string group = data[2];


                Rebel rebel = new Rebel(name, age, group);

                rebels.Add(rebel);
            }
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            if (rebels.Any(r => r.Name == input))
            {
                Rebel rebel = rebels.First(r => r.Name == input);
                rebel.BuyFood();
            }
            else if (citizens.Any(c => c.Name == input))
            {
                Citizen citizen = citizens.First(r => r.Name == input);
                citizen.BuyFood();
            }
        }

        Console.WriteLine((rebels.Sum(p=> p.Food) + (citizens.Sum(p=> p.Food))));
    }
}
