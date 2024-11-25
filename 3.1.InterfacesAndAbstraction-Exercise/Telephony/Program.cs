namespace Telephony;

public class Program
{
    public static void Main()
    {
        StationaryPhone homePhone = new StationaryPhone();
        Smartphone phone = new Smartphone();

        string[] phoneNumbers = Console.ReadLine()!.Split();
        string[] sites = Console.ReadLine()!.Split();

        Call(phoneNumbers, homePhone, phone);
        Browse(sites, phone);

    }

    private static void Call(string[] phoneNumbers, StationaryPhone homePhone, Smartphone phone)
    {
        foreach (string phoneNumber in phoneNumbers)
        {
            if (phoneNumber.Any(c => !char.IsDigit(c)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                if (phoneNumber.Length == 7)
                {
                    Console.WriteLine($"{homePhone.Call(phoneNumber)}");
                }
                else if (phoneNumber.Length == 10)
                {
                    Console.WriteLine($"{phone.Call(phoneNumber)}");
                }
            }
        }
    }
    private static void Browse(string[] sites, Smartphone phone)
    {
        foreach (string site in sites)
        {
            if (site.Any(c => char.IsDigit(c)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"{phone.Browse(site)}");
            }
        }
    }
}
