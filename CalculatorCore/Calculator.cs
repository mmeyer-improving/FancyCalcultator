using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        private TimeMachine timeMachine;

        public Calculator()
        {
            timeMachine = new TimeMachine();
        }


        public EvaluationResult Evaluate(string input)
        {
            decimal x;
            string op;
            decimal y;
            var inputPieces = input.Split(' ');

            if (inputPieces.Length == 2 && IsValidOperand(inputPieces[0]))
            {
                x = timeMachine.LastResult;
                op = inputPieces[0];
            }
            else if (inputPieces.Length != 3)
            {
                return new EvaluationResult
                {
                    ErrorMessage = "An operation must be in the form '5 + 8'  or '+ 8' if continuing from a previous value. Please try again."
                };
            }
            else
            {
                if (Decimal.TryParse(inputPieces[0], out x) == false)
                {
                    return new EvaluationResult { ErrorMessage = $"The first value you entered, {inputPieces[0]}, was not a valid number." };
                }

                op = inputPieces[1];
            }



            if (Decimal.TryParse(inputPieces[inputPieces.Length - 1], out y) == false)
            {
                return new EvaluationResult { ErrorMessage = $"The second value you entered, {inputPieces[2]}, was not a valid number." };
            }

            decimal result;

            switch (op)
            {
                
                case "+":
                    result = x + y;
                    timeMachine.LastResult = result;
                    return new EvaluationResult { Result = result };
                case "-":
                    result = x - y;
                    timeMachine.LastResult = result;
                    return new EvaluationResult { Result = result };
                case "*":
                    result = x * y;
                    timeMachine.LastResult = result;
                    return new EvaluationResult { Result = result };
                case "/":
                    result = x / y;
                    timeMachine.LastResult = result;
                    return new EvaluationResult { Result = result };
                default:
                    return new EvaluationResult { ErrorMessage = $"The operation '{op}' is invalid. You must use one of the following: + - * /" };
            }
        }

        public bool IsValidOperand(string input)
        {
            string[] validOperands = new string[] { "+", "-", "*", "/"};
            return validOperands.Contains(input);
        }
    }
}
