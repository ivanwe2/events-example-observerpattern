﻿using EventsExample_ObserverPattern.Abstractions;
using EventsExample_ObserverPattern.Models;
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
            var internalTermometer = new InternalTermometer();
            var externalTermometer = new ExternalTermometer();

            temperatureMonitor.TestFunctionality(new List<ICustomObserver<Temperature>>() { internalTermometer, externalTermometer});
        }
    }
}
