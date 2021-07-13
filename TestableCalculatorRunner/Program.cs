using System;
using CalculatorCore;

namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console stuff goes here
            var calculator = new Calculator();
            string input;

            Console.WriteLine("A Console Calculator");

            do
            {
                Console.WriteLine("Give me the expression you would like me to evaluate.");
                input = Console.ReadLine();

                if (input == "exit") { return; }

                EvaluationResult evaluationResult = calculator.Evaluate(input);

                if (String.IsNullOrWhiteSpace(evaluationResult.ErrorMessage))
                {
                    Console.WriteLine($"Result: {evaluationResult.Result}");
                }
                else
                {
                    Console.WriteLine($"\u001b[31m{evaluationResult.ErrorMessage}\u001b[0m");
                }
            } while (input != "exit");
            
        }
    }
}
