using System;

namespace Core.Broadcasting
{
    public class Receiver<TObserved> : IObserver<TObserved>
    {
        public Action WhenCompleted { get; set; }
        public Action<Exception> WhenError { get; set; }
        public Action<TObserved> WhenNext { get; set; }

        public void OnCompleted()
        {
            WhenCompleted?.Invoke();
        }

        public void OnError(Exception error)
        {
            WhenError?.Invoke(error);
        }

        public void OnNext(TObserved value)
        {
            WhenNext?.Invoke(value);
        }
    }
}