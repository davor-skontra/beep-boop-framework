using System;
using System.Linq;
using System.Reflection;

namespace DependencyInjection.Bindings
{
    public class FactoryBinding<TFactory>: IBinding where TFactory: Delegate
    {
        private readonly TFactory _factoryMethod;
        private readonly IocContainer.BlindResolver _resolver;
        private Type[] _paramTypes;
        
        public FactoryBinding(TFactory factoryMethod , IocContainer.BlindResolver resolver)
        {
            _factoryMethod = factoryMethod;
            _resolver = resolver;
        }
        
        public object Resolve()
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

            return _factoryMethod.DynamicInvoke(resolvedParams);
        }
    }
}