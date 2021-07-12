using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    class TimeMachine
    { 
        public decimal LastResult { get; set; }
        public int LongestFirstPartLength { get; set; }
        public List<string> History { get; set; }

        public TimeMachine()
        {
            History = new List<string>();
            LongestFirstPartLength = -1;
        }

        //When adding to History, check if length is greater than established.
        public void AddHistory(string equation)
        {
            var equationPieces = equation.Split(' ').ToList();
            var beforeEquals = $"{equationPieces.ElementAt(0)} _ {equationPieces.ElementAt(2)}";

            if (beforeEquals.Length > LongestFirstPartLength)
            {
                LongestFirstPartLength = beforeEquals.Length;
            }

            History.Add(equation);
        }
    }
}
