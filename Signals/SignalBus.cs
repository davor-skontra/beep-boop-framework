using System;
using System.Collections.Generic;
using Broadcasting;

namespace Signals
{
    public static class SignalBus
    {
        private static readonly Dictionary<Type, Broadcaster<ISignal>> KnownSignals = new Dictionary<Type, Broadcaster<ISignal>>();
        
        public static void Send(ISignal signal)
        {
            var type = signal.GetType();
            AddSignalTypeIfNeeded(type);
            KnownSignals[type].OnNext(signal);
        }

        public static IDisposable Subscribe<TSignal>(Action<TSignal> action) where TSignal: ISignal
        {
            var type = typeof(TSignal);
            AddSignalTypeIfNeeded(type);

            return KnownSignals[type].Subscribe(x => action((TSignal) x));
        }

        private static void AddSignalTypeIfNeeded(Type type)
        {
            if (!KnownSignals.ContainsKey(type))
            {
                KnownSignals[type] = new Broadcaster<ISignal>();
            }
        }
    }
}