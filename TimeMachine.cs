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
        public List<string> History { get; set; }

        public TimeMachine()
        {
            History = new List<string>();
        }
    }
}
