using EventsExample_ObserverPattern.Observers;
using EventsExample_ObserverPattern.Observers.Base;
using EventsExample_ObserverPattern.Providers;

namespace EventsExample_ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureMonitor temperatureMonitor = new TemperatureMonitor();
            InternalTermometer internalTermometer = new InternalTermometer();
            ExternalTermometer externalTermometer = new ExternalTermometer();

            temperatureMonitor.TestFunctionality(new List<TemperatureObserverBase> { internalTermometer, externalTermometer});
        }
    }
}
