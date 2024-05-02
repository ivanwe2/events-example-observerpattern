using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample_ObserverPattern.Abstractions
{
    /// <summary>
    /// Complicating things for exercise
    /// </summary>
    /// <typeparam name="TObservable"></typeparam>
    public interface ICustomObserver<in TObservable> where TObservable : ICustomObservableType
    {
        void Subscribe(IObservable<TObservable> provider);
        void Unsubscribe();
    }
}
