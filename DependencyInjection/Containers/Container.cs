using System;
using System.Collections.Generic;
using DependencyInjection.Bindings;

namespace DependencyInjection.Containers
{
    public class Container
    {
        private Dictionary<Type, IBinding> _bindingMaps = new Dictionary<Type, IBinding>();
        
        public Container(params Container[] dependencies)
        {
        }

        public delegate object BlindResolver(Type type);

        public delegate void BindingAdder(Type type, IBinding binding);
        
        public BindingBuilder Register<TType>()
        {
            return new BindingBuilder(this);
        }

        public void Inject(object target)
        {
            // TODO: Reflection magic 
        }

        public TType Resolve<TType>()
        {
            return _bindingMaps[typeof(TType)].Resolve<TType>(this);
        }

        private object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        private void AddBinding(Type type, IBinding binding)
        {
            _bindingMaps.Add(type, binding);
        }
    }
}