using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");
            Console.WriteLine("Enter a number.");
            decimal x = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter a second number, and I will add it to the first.");
            decimal y = Decimal.Parse((Console.ReadLine()));
            decimal result = x + y;
            Console.WriteLine($"Result: {result}");
        }
    }
}
