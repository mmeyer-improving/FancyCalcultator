using System;
using System.Collections.Generic;
using System.Linq;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeMachine timeMachine = new TimeMachine();
            decimal x;
            string operand;
            decimal y;
            string input;
            

            Console.WriteLine("A Console Calculator");

            do
            {
                //Collecting input
                Console.WriteLine("Enter in the operation you would like to perform.");
                input = Console.ReadLine();

                //If they type in exit, stop loop
                if (input == "exit") { return; }
                else if (input == "history") { DisplayHistory(timeMachine); }
                else
                {
                    //TODO could refactor lower stuff out into own method. Check to see if input pieces has 2, if so insert LastResult.ToString into first part.
                    //Then, if it doesn't have 3 pieces, spit out error message and return.
                    //Then, do normal validation for numbers one and two. Number one is essentially being evaluated and parse twice, once the first time and again as history but maybe that's okay.
                    //HOWEVER, if doing this what to return? if bool, need to parse stuff AGAIN anyway. if List<decimal>, no way to show Main they are invalid?

                    //Splitting input into multiple pieces, if there are not 2 or 3 then send an error message.
                    //Then, validate numbers and assign based on how many were provided.
                    List<string> inputPieces = input.Split(' ').ToList();
                    if (inputPieces.Count() == 3)
                    {
                        //Validating first input
                        if (!ValidateNumber(inputPieces.ElementAt(0), "first"))
                        {
                            return;
                        }
                        else
                        {
                            x = Decimal.Parse(inputPieces.ElementAt(0));
                        }

                        operand = inputPieces.ElementAt(1);

                        //Validating second input
                        if (!ValidateNumber(inputPieces.ElementAt(2), "second"))
                        {
                            return;
                        }
                        else
                        {
                            y = Decimal.Parse(inputPieces.ElementAt(2));
                        }
                    }
                    else if (inputPieces.Count == 2)
                    {
                        x = timeMachine.LastResult;

                        operand = inputPieces.ElementAt(0);

                        //Validating second input
                        if (!ValidateNumber(inputPieces.ElementAt(1), "second"))
                        {
                            return;
                        }
                        else
                        {
                            y = Decimal.Parse(inputPieces.ElementAt(1));
                        }
                    }
                    else
                    {
                        Console.WriteLine("An operation must be in the form '5 + 8' or '+ 8' if continuing based on a previous value. Please try again.");
                        return;
                    }


                    //switch statement looks at second part of equation and determines which equation to use.
                    switch (operand)
                    {
                        case "+":
                            Add(x, y, ref timeMachine, input);
                            break;
                        case "-":
                            Subtract(x, y, ref timeMachine, input);
                            break;
                        case "*":
                            Multiply(x, y, ref timeMachine, input);
                            break;
                        case "/":
                            Divide(x, y, ref timeMachine, input);
                            break;
                        default:
                            Console.WriteLine($"The operation '{operand}' is invalid. You must use one of the following: + - * /");
                            return;
                    }
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

        static void DisplayHistory(TimeMachine timeMachine)
        {
            if (!(timeMachine.History.Any()))
            {
                Console.WriteLine("There are no operations to display.");
            } 
            else
            {
                foreach (var equation in timeMachine.History)
                {
                    Console.WriteLine($" {equation}");
                }
            }
            
        }
        
        //Adds the two decimals together.
        static void Add(decimal x, decimal y, ref TimeMachine timeMachine, string input)
        {
            var result = x + y;
            timeMachine.LastResult = result;
            timeMachine.History.Add($"{input} = {result}");
            Console.WriteLine($"Result: {result}");
        }

        //Subtracts the two decimals.
        static void Subtract(decimal x, decimal y, ref TimeMachine timeMachine, string input)
        {
            var result = x - y;
            timeMachine.LastResult = result;
            timeMachine.History.Add($"{input} = {result}");
            Console.WriteLine($"Result: {result}");
        }

        //Multiplies the two decimals.
        static void Multiply(decimal x, decimal y, ref TimeMachine timeMachine, string input)
        {
            var result = x * y;
            timeMachine.LastResult = result;
            timeMachine.History.Add($"{input} = {result}");
            Console.WriteLine($"Result: {result}");
        }

        //Divides the two decimals.
        static void Divide(decimal x, decimal y, ref TimeMachine timeMachine, string input)
        {
            if (y == 0)
            {
                Console.WriteLine("Cannot divide by 0");
                return;
            }
            var result = x / y;
            timeMachine.LastResult = result;
            timeMachine.History.Add($"{input} = {result}");
            Console.WriteLine($"Result: {result}");
        }
    }
}
