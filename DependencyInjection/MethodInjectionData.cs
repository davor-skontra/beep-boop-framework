using System;
using System.Linq;
using System.Reflection;
using DependencyInjection.Exceptions;

namespace DependencyInjection
{
    public class MethodInjectionData
    {
        private readonly MethodBase _methodBase;

        private Type[] _paramTypes;

        public MethodInjectionData(Type type)
        {
            var methods = type
                .GetMethods(BindingFlags.Instance)
                .Where(method => Attribute.IsDefined(method, typeof(InjectAttribute)))
                .ToArray();

            if (methods.Count() > 1)
            {
                throw new TooManyInjectMethodsException(type);
            }

            _methodBase = methods.First();
        }

        public Type[] ParamTypes
        {
            get
            {
                if (_paramTypes == null)
                {
                    _paramTypes = _methodBase
                        .GetParameters()
                        .Select(x => x.ParameterType)
                        .ToArray();
                }

                return _paramTypes;
            }
        }

        public MethodBase MethodBase => _methodBase;
    }
}