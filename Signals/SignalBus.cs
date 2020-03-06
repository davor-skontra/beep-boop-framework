using System;
using System.Collections.Generic;
using Broadcasting;

namespace Signals
{
    public class SignalBus
    {
        private readonly Dictionary<Type, Broadcaster<ISignal>> KnownSignals = new Dictionary<Type, Broadcaster<ISignal>>();
        
        public void Send(ISignal signal)
        {
            var type = signal.GetType();
            AddSignalTypeIfNeeded(type);
            KnownSignals[type].OnNext(signal);
        }

        public IDisposable Subscribe<TSignal>(Action<TSignal> action) where TSignal: ISignal
        {
            var type = typeof(TSignal);
            AddSignalTypeIfNeeded(type);

            return KnownSignals[type].Subscribe(x => action((TSignal) x));
        }

        private void AddSignalTypeIfNeeded(Type type)
        {
            if (!KnownSignals.ContainsKey(type))
            {
                KnownSignals[type] = new Broadcaster<ISignal>();
            }
        }
    }
}