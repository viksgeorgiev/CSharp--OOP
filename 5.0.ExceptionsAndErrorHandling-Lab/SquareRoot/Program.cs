using System;

namespace SquareRoot
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                int input = int.Parse(Console.ReadLine()!);
                if (input < 0)
                {
                    throw new Exception("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(input));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
