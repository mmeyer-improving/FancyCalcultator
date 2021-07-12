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

            Console.WriteLine("A Console Calculator");

            Console.WriteLine("Enter what you would like to see added");
            string input = Console.ReadLine();
            List<string> inputPieces = input.Split(' ').ToList();

            //Validating first input
            if (!validateNumber(inputPieces.ElementAt(0), "first"))
            {
                return;
            } 
            else
            {
                x = Decimal.Parse(inputPieces.ElementAt(0));
            }

            //validating second input
            if (!validateNumber(inputPieces.ElementAt(2), "second"))
            {
                return;
            }
            else
            {
                y = Decimal.Parse(inputPieces.ElementAt(2));
            }

            decimal result = x + y;
            Console.WriteLine($"Result: {result}");
        }

        //Validates whether the strng input passed in is a number or not.
        //If not, writes out that it is not a number and specifies the place in sequence, i.e. "the *second* value, ___, is not a number".
        static bool validateNumber(string input, string placeInSequence)
        {
            decimal number;

            if (!(Decimal.TryParse(input, out number)))
            {
                Console.WriteLine($"The {placeInSequence} value, {input}, was not a valid number.");
                return false;
            }
            return true;
        }
    }
}
