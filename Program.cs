using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal x;
            decimal y;

            Console.WriteLine("A Console Calculator");
            Console.WriteLine("Enter a number.");
            string firstInput = Console.ReadLine();
            if(!(Decimal.TryParse(firstInput, out x)))
            {
                Console.WriteLine($"The first value, {firstInput}, is not a number.");
                return;
            }
            Console.WriteLine("Enter a second number, and I will add it to the first.");
            string secondInput = Console.ReadLine();
            if(!(Decimal.TryParse(secondInput, out y)))
            {
                Console.WriteLine($"The second value, {secondInput}, is not a number.");
                return;
            }
            decimal result = x + y;
            Console.WriteLine($"Result: {result}");
        }
    }
}
