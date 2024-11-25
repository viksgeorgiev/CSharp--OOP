namespace MoneyTransactions;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(",");
        Dictionary<long, double> bank = new Dictionary<long, double>();

        foreach (string element in input)
        {
            string[] bankInfo = element.Split("-");

            long accountNumber = long.Parse(bankInfo[0]);
            double accountBalance = double.Parse(bankInfo[1]);

            bank.Add(accountNumber, accountBalance);
        }

        string data = string.Empty;

        while (data != "End")
        {
            data = Console.ReadLine().TrimEnd();
            if (data == "End")
            { break;}
            try
            {
                string[] commands = data.Split(" ");

                if (commands[0] == "Deposit")
                {
                    if (!bank.ContainsKey(long.Parse(commands[1])))
                    {
                        throw new InvalidDataException("Invalid account!");
                    }

                    bank[long.Parse(commands[1])] += double.Parse(commands[2]);
                    Console.WriteLine($"Account {long.Parse(commands[1])} has new balance: {bank[long.Parse(commands[1])]:F2}");
                }
                else if (commands[0] == "Withdraw")
                {
                    if (!bank.ContainsKey(long.Parse(commands[1])))
                    {
                        throw new InvalidDataException("Invalid account!");
                    }
                    if (double.Parse(commands[2]) > bank[long.Parse(commands[1])])
                    {
                        throw new ArgumentOutOfRangeException("","Insufficient balance!");
                    }
                    bank[long.Parse(commands[1])] -= double.Parse(commands[2]);
                    Console.WriteLine($"Account {long.Parse(commands[1])} has new balance: {bank[long.Parse(commands[1])]:F2}");
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Enter another command");
            }
        }
    }
}
