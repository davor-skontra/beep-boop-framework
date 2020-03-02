using System;
using System.Collections.Generic;
using DependencyInjection.Exceptions;

namespace DependencyInjection
{
    public class InjectorBinder<TType>
    {
        private readonly Dictionary<Type, Dependency> _knownDependencies;
        private Type _bindingType = typeof(TType);
        private readonly Dependency _dependency;

        public InjectorBinder(Dictionary<Type, Dependency> knownDependencies, object singleton)
        {
            _knownDependencies = knownDependencies;

        }

        public InjectorBinder<TNewType> ToType<TNewType>()
        {
            var cannotBeAssigned = !typeof(TType).IsAssignableFrom(typeof(TNewType));
            if (cannotBeAssigned)
            {
                throw new DependencyCannotBeAssignedException<TType, TNewType>();
            }
            _bindingType = typeof(TNewType);

            return new InjectorBinder<TNewType>(_knownDependencies, _dependency);;
        }

        public void Bind()
        {
            if (_knownDependencies.ContainsKey(_bindingType))
            {
                throw new DependencyAlreadyExistsException(_bindingType);
            }

            _knownDependencies[_bindingType] = _dependency;
        }
            
            
    }
}