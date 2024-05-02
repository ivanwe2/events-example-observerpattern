using EventsExample_ObserverPattern.Extensions;
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
    /// An external service that writes to an externalReport  text file in the bin folder.
    /// </summary>
    public class ExternalTermometer : ObserverBase<Temperature>
    {
        public override void OnCompleted()
        {
            Console.WriteLine("Disconnecting external termometer...");
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Report information to file.
        /// </summary>
        /// <param name="value"></param>
        public override void OnNext(Temperature value)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "externalReport.txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(value.ToString());
            }
        }
    }
}
