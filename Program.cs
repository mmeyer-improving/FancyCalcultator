using System;
using System.Collections.Generic;
using System.Linq;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal x;
            decimal y;
            string input;

            Console.WriteLine("A Console Calculator");

            do
            {
                Console.WriteLine("Enter in the operation you would like to perform.");
                input = Console.ReadLine();

                if (input == "exit") { return; }

                List<string> inputPieces = input.Split(' ').ToList();

                //Validating first input
                if (!ValidateNumber(inputPieces.ElementAt(0), "first"))
                {
                    return;
                }
                else
                {
                    x = Decimal.Parse(inputPieces.ElementAt(0));
                }

                //validating second input
                if (!ValidateNumber(inputPieces.ElementAt(2), "second"))
                {
                    return;
                }
                else
                {
                    y = Decimal.Parse(inputPieces.ElementAt(2));
                }


                //switch statement looks at second part of equation and determines which equation to use.
                switch (inputPieces.ElementAt(1))
                {
                    case "+":
                        Add(x, y);
                        break;
                    case "-":
                        Subtract(x, y);
                        break;
                    case "*":
                        Multiply(x, y);
                        break;
                    case "/":
                        Divide(x, y);
                        break;
                    default:
                        Console.WriteLine($"The operation '{inputPieces.ElementAt(1)}' is invalid. You must use one of the following: + - * /");
                        return;
                }
            } while (input != "exit");

        }

        //Validates whether the strng input passed in is a number or not.
        //If not, writes out that it is not a number and specifies the place in sequence, i.e. "the *second* value, ___, is not a number".
        static bool ValidateNumber(string input, string placeInSequence)
        {
            decimal number;

            if (!(Decimal.TryParse(input, out number)))
            {
                Console.WriteLine($"The {placeInSequence} value, {input}, was not a valid number.");
                return false;
            }
            return true;
        }
        
        //Adds the two decimals together.
        static void Add(decimal x, decimal y)
        {
            var result = x + y;
            Console.WriteLine($"Result: {result}");
        }

        //Subtracts the two decimals.
        static void Subtract(decimal x, decimal y)
        {
            var result = x - y;
            Console.WriteLine($"Result: {result}");
        }

        //Multiplies the two decimals.
        static void Multiply(decimal x, decimal y)
        {
            var result = x * y;
            Console.WriteLine($"Result: {result}");
        }

        //Divides the two decimals.
        static void Divide(decimal x, decimal y)
        {
            var result = x / y;
            Console.WriteLine($"Result: {result}");
        }
    }
}
