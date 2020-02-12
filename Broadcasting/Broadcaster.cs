using System;
using System.Collections.Generic;

namespace Core.Broadcasting
{
    public interface IBroadcaster<TObserved> : IObservable<TObserved>, IObserver<TObserved>
    {
        IDisposable Subscribe(Action<TObserved> onNext);
    }

    public class Broadcaster<TObserved>: IBroadcaster<TObserved>
    {
        private readonly List<IObserver<TObserved>> _observers = new List<IObserver<TObserved>>();

        public IDisposable Subscribe(IObserver<TObserved> observer) =>
            new Unsubscriber(_observers, observer);

        public IDisposable Subscribe(Action<TObserved> onNext)
        {
            var observer = new Receiver<TObserved>()
            {
                WhenNext = onNext
            };

            return new Unsubscriber(_observers, observer);
        }

        public void OnCompleted()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
                //TODO: See if what exactly is needed here
            }
        }

        public void OnError(Exception error)
        {
            foreach (var observer in _observers)
            {
                observer.OnError(error);
            }
        }

        public void OnNext(TObserved next)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(next);
            }
        }

        private class Unsubscriber: IDisposable
        {
            private readonly List<IObserver<TObserved>> _observers;
            private readonly IObserver<TObserved> _observer;

            public Unsubscriber(List<IObserver<TObserved>> observers, IObserver<TObserved> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }
    }

    
}