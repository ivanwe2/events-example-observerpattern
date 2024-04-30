using EventsExample_ObserverPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample_ObserverPattern.Observers.Base
{
    /// <summary>
    /// Abstract Observer type used to encapsulate any other observer.
    /// </summary>
    public abstract class TemperatureObserverBase : IObserver<Temperature>
    {
        private IDisposable _unsubscriber;
        private List<IObserver<Temperature>> _observers = [];

        public abstract void OnCompleted();
        public abstract void OnError(Exception error);
        public abstract void OnNext(Temperature value);

        public virtual void Subscribe(IObservable<Temperature> provider)
        {
            _unsubscriber = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
