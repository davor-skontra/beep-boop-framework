using System;
using System.Linq;
using System.Reflection;
using DependencyInjection.Containers;

namespace DependencyInjection.Bindings
{
    public class FactoryBinding<TFactory>: IBinding where TFactory: Delegate
    {
        private readonly TFactory _factoryMethod;
        private readonly Container.BlindResolver _resolver;
        private Type[] _paramTypes;
        
        public BindingKind Kind => BindingKind.Factory;
        
        public FactoryBinding(TFactory factoryMethod , Container.BlindResolver resolver)
        {
            _factoryMethod = factoryMethod;
            _resolver = resolver;
        }

        public TResolving Resolve<TResolving>(Container container)
        {
            if (_paramTypes == null)
            {
                _paramTypes = _factoryMethod
                    .GetMethodInfo()
                    .GetParameters()
                    .Select(x => x.ParameterType)
                    .ToArray();
            }

            var resolvedParams = _paramTypes.Select(x => _resolver(x));

            return (TResolving) _factoryMethod.DynamicInvoke(resolvedParams);
        }
    }
}