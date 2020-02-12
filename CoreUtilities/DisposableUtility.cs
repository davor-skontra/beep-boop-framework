using System;
using System.Collections.Generic;

//Disposable Utility shares the namespace with AutoDisposableBehaviour because it is needed by it.
namespace Core.CoreUtilities
{
    public static class DisposableUtility
    {
        public static void Dispose(this IEnumerable<IDisposable> self)
        {
            foreach (var disposable in self)
            {
                disposable.Dispose();
            }
        }
    }
}