using EventsExample_ObserverPattern.Models;
using EventsExample_ObserverPattern.Observers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample_ObserverPattern.Observers
{
    /// <summary>
    /// An Internal Temperature monitor that produces output for the temperature and the change from the previous.
    /// </summary>
    public class InternalTermometer : ObserverBase<Temperature>
    {
        private bool _isFirst = true;
        private Temperature _last;
        public override void OnCompleted()
        {
            Console.WriteLine("Turning off internal termometer...");
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(Temperature value)
        {
            Console.WriteLine(value.ToString());
            if (_isFirst)
            {
                _last = value;
                _isFirst = false;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("   Change: {0}° in {1:g}", value.Degrees - _last.Degrees,
                                                              value.Date.ToUniversalTime() - _last.Date.ToUniversalTime());
                Console.ResetColor();
            }
        }
    }
}
