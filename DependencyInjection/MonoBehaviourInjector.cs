using System;
using System.Reflection;
using UnityEngine;
using ViewModels;
using Views;

namespace DependencyInjection
{
    public static class MonoBehaviourInjector
    {
        private static IocContainer _injector;

        public static void SetContainer(IocContainer injector)
        {
            _injector = injector;
        }

        public static void Inject<TType>(this TType self) where TType: MonoBehaviour {
            _injector.Inject(self);
        }
    }
}