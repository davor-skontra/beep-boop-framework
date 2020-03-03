using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DependencyInjection.Bindings;
using DependencyInjection.Exceptions;

namespace DependencyInjection
{
    public class IocContainer
    {
        private readonly BindingMap _bindingMaps = new BindingMap();

        public IocContainer(params BindingMap[] dependencies)
        {
            var allPairs = dependencies.SelectMany(x => x);

            foreach (var dependency in allPairs)
            {
                var type = dependency.Key;
                var binding = dependency.Value;

                AddBindingChecked(type, binding);
            }
        }

        public delegate object BlindResolver(Type type);

        public delegate void BindingAdder(Type type, IBinding binding);

        public delegate void Injector(object target);

        public BindingBuilder<TType> Bind<TType>()
        {
            return new BindingBuilder<TType>(Inject, Resolve, AddBindingChecked);
        }

        public void Inject<TType>(TType target)
        {
            var fields = typeof(TType)
                .GetFields(BindingFlags.Instance)
                .Where(field => Attribute.IsDefined(field, typeof(InjectAttribute)));

            foreach (var field in fields)
            {
                field.SetValue(target, Resolve(field.GetType()));
            }
        }
        
        /// <summary>
        /// Resolve a dependency of a given type.
        ///
        /// Throws an exception if the type does not exist in the binding map.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="DependencyCannotBeResolvedException"></exception>
        private object Resolve(Type type)
        {
            if (!_bindingMaps.ContainsKey(type))
            {
                throw new DependencyCannotBeResolvedException(type);
            }
            return _bindingMaps[type].Resolve();
        }

        /// <summary>
        /// Adds the binding to the BindingMap.
        ///
        /// Throws an exception if the binding already exists.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="binding"></param>
        /// <exception cref="DependencyAlreadyExistsException"></exception>
        private void AddBindingChecked(Type type, IBinding binding)
        {
            if (_bindingMaps.ContainsKey(type))
            {
                throw new DependencyAlreadyExistsException(type);
            }
            
            _bindingMaps.Add(type, binding);
        }
    }
}