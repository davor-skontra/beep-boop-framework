using System;
using System.Collections.Generic;
using System.Linq;
using Core.CoreUtilities;
using UnityEngine;

namespace Core.Disposables
{
    public abstract class AutoDisposableBehaviour : MonoBehaviour
    {
        protected List<IDisposable> Disposables;

        protected void Awake()
        { 
            Disposables = Init().ToList();
        }

        protected void OnDestroy()
        {
            Disposables.Dispose();
        }

        protected abstract IDisposable[] Init();
        
        // Dispose when done must only ever be called after the Init method has been called.
        // If overriding the Awake method, make sure to call base.Awake() first
        public void DisposeWhenDone(params IDisposable[] disposables)
        {
            foreach (var disposable in disposables)
            {
                Disposables.Add(disposable);
            }
        }
    }
}
