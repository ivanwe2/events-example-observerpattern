using EventsExample_ObserverPattern.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample_ObserverPattern.Models
{
    public class Temperature : ICustomObservableType
    {
        public decimal Degrees { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"({Date}): The temperature is {Degrees}°C";
        }
    }
}
