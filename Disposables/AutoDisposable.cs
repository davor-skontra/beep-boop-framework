using System;
using System.Collections.Generic;
using Core.CoreUtilities;

namespace Core.Disposables
{
    public class AutoDisposable: IDisposable
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
            
        protected void DisposeWhenDone(params IDisposable[] disposables)
        {
            foreach (var disposable in disposables)
            {
                _disposables.Add(disposable);
            }
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}