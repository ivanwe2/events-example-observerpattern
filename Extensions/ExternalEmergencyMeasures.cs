using EventsExample_ObserverPattern.Observers;
using EventsExample_ObserverPattern.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample_ObserverPattern.Extensions
{
    public delegate void EmergencyMeasureDel();
    public static class EmergencyMeasuresExtensions
    {
        public static void CallFireDepartment(this ExternalTermometer externalTermometer)
        {
            Console.WriteLine("Fire department is on the way!");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static void ExtinquishFire(this InternalTermometer internalTermometer)
        {
            Console.WriteLine("Extinguishing fire!");
        }
        public static EmergencyMeasureDel DeployEmergencyMeasures(this TemperatureMonitor temperatureMonitor)
        {
            var internalTermometer = new InternalTermometer();
            var externalTermometer = new ExternalTermometer();
            EmergencyMeasureDel del = internalTermometer.ExtinquishFire;
            del += externalTermometer.CallFireDepartment;

            return del;
        }
    }
}
