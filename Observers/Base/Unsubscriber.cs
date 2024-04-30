using EventsExample_ObserverPattern.Abstractions;
using EventsExample_ObserverPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample_ObserverPattern.Observers.Base
{
    /// <summary>
    /// Generic Unsubscriber for any observable data type
    /// </summary>
    /// <typeparam name="T">Must be a predefined type inheriting from the ICustomObservable interface</typeparam>
    public class Unsubscriber<T> : IDisposable where T : ICustomObservableType
    {
        private List<IObserver<T>> _observers;
        private IObserver<T> _temperatureObserver;
        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            _observers = observers;
            _temperatureObserver = observer;
        }
        public void Dispose()
        {
            if( _observers is not null && _observers.Contains(_temperatureObserver)) 
                _observers.Remove(_temperatureObserver);
        }
    }
}
