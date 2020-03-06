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

        public static void Inject(this MonoBehaviour self) {
            _injector.Inject(self);
        }
    }
}