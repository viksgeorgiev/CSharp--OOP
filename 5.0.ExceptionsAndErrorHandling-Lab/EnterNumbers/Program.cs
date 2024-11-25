using System.Reflection.Metadata;

namespace EnterNumbers;

public class Program
{
    private const int startNum = 1;
    private const int endNum = 100;
    static void Main()
    {
        string input = string.Empty;
        List<int> list = new List<int>();

        while (list.Count < 10)
        {
            try
            {
                input = Console.ReadLine();
                if (list.Count == 0)
                {
                    ReadNumber(input, startNum, endNum, list);
                }
                else
                {
                    ReadNumber(input, list.Last(), endNum, list);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine(string.Join(", ", list));
    }

    private static void ReadNumber(string input, int start, int end, List<int> list)
    {
        if (int.TryParse(input, out int result))
        {
            if(result <= start || result >= end)
            {
                throw new ArgumentOutOfRangeException("", $"Your number is not in range {start} - 100!");
            }
            else
            {
                list.Add(result);
            }
        }
        else
        {
            throw new ArgumentException($"Invalid Number!");
        }
    }

}

