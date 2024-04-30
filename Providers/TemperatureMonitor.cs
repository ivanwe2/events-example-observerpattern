using EventsExample_ObserverPattern.Extensions;
using EventsExample_ObserverPattern.Models;
using EventsExample_ObserverPattern.Observers;
using EventsExample_ObserverPattern.Observers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample_ObserverPattern.Providers
{
    
    public class TemperatureMonitor : IObservable<Temperature>
    {
        private List<IObserver<Temperature>> _observers = [];
        
        public IDisposable Subscribe(IObserver<Temperature> observer)
        {
            if(!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber<Temperature>(_observers, observer);
        }
        private void GetTemperature()
        {
            // Create an array of sample data to mimic a temperature device.
            List<decimal> temps = [14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.2m, 15.2m,
                                15.4m, 15.45m, 150m, 200m];

            foreach (var temp in temps)
            {
                System.Threading.Thread.Sleep(2500);

                Temperature tempData = new Temperature() { Degrees = temp, Date = DateTime.Now };
                foreach (var observer in _observers)
                    observer.OnNext(tempData);

                if(temp > 150m)
                {
                    EmergencyMeasureDel emergencyMeasureDel = this.DeployEmergencyMeasures();
                    emergencyMeasureDel.Invoke();
                }
            }

            foreach (var observer in _observers.ToArray())
                if (observer != null) observer.OnCompleted();

            _observers.Clear();
        }
        public void TestFunctionality(List<TemperatureObserverBase> observers)
        {
            foreach (var observer in observers)
            {
                observer.Subscribe(this);
            }
            GetTemperature();
        }
    }
}
