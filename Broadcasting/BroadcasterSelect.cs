using System;
using UnityEngine.UI;

namespace Broadcasting
{
    public static class BroadcasterSelect
    {
        public static IBroadcaster<TOut> Select<TIn, TOut>(this IBroadcaster<TIn> self, Func<TIn, TOut> predicate)
        {
            var output = new Broadcaster<TOut>();

            var receiver = new Receiver<TIn>()
            {
                WhenCompleted = () => output.OnCompleted(),
                WhenError = x => output.OnError(x),
                WhenNext = x => output.OnNext(predicate(x))
            };

            self.Subscribe(receiver);

            return output;
        }
    }
}