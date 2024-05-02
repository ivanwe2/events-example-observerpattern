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
    /// Abstract Observer type used to encapsulate any other observer.
    /// </summary>
    public abstract class ObserverBase<T> : IObserver<T>, ICustomObserver<T> where T : ICustomObservableType
    {
        private IDisposable _unsubscriber;
        private List<IObserver<T>> _observers = [];

        public abstract void OnCompleted();
        public abstract void OnError(Exception error);
        public abstract void OnNext(T value);

        public virtual void Subscribe(IObservable<T> provider)
        {
            _unsubscriber = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
