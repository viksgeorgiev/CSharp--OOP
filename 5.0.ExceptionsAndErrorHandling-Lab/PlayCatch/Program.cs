namespace PlayCatch;

public class Program
{
    public static void Main()
    {
        int[] array = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        int errorsCounter = 0;

        string input = string.Empty;

        while (errorsCounter < 3)
        {
            input = Console.ReadLine()!;

            string[] commands = input.Split(" ");

            try
            {
                string action = commands[0];
                int index = int.Parse(commands[1]);
                if (action == "Replace")
                {
                    int element = int.Parse(commands[2]);
                    array[index] = element;
                }
                if (action == "Print")
                {
                    int endIndex = int.Parse(commands[2]);
                    int luckyTry = array[endIndex];
                    for (int i = index; i <= endIndex; i++)
                    {
                        if (i != endIndex)
                        {
                            Console.Write($"{array[i]}, ");
                        }
                        else
                        {
                            Console.Write(array[i]);
                        }
                    }
                    Console.WriteLine();
                }
                if(action == "Show")
                {
                    Console.WriteLine(array[index]);
                }
            }
            catch (System.IndexOutOfRangeException e)
            {

                Console.WriteLine("The index does not exist!");
                errorsCounter++;
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("The variable is not in the correct format!");
                errorsCounter++;
            }
        }
        Console.WriteLine(string.Join(", ",array));
    }
}
