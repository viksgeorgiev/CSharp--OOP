using System.Numerics;
using System.Reflection.Metadata;

namespace SumOfIntegers;

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ");
        int sum = 0;
        foreach (string element in input)
        {
            try
            {
                if (int.TryParse(element, out int result))
                {
                    sum += result;                  
                }
                else
                {
                    if (BigInteger.TryParse(element, out BigInteger bigIntResult))
                    {
                        throw new OverflowException($"The element '{element}' is out of range!");
                    }
                    else
                    {
                        throw new FormatException($"The element '{element}' is in wrong format!");
                    }
                }
            }
            catch (OverflowException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }
        }
        Console.WriteLine($"The total sum of all integers is: {sum}");
    }
}
