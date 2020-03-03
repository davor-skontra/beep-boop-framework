using System;

namespace DependencyInjection.Bindings
{
    public class BindingBuilder
    {
        private readonly IocContainer.Injector _injector;
        private readonly IocContainer.BlindResolver _resolver;
        private readonly IocContainer.BindingAdder _adder;

        public BindingBuilder(
            IocContainer.Injector injector,
            IocContainer.BlindResolver resolver,
            IocContainer.BindingAdder adder)
        {
            _injector = injector;
            _resolver = resolver;
            _adder = adder;
        }

        public void FromSingleton<TType>(TType singleton) where TType : class
        {
            _adder(typeof(TType), new SingletonBinding(singleton, _injector));
        }

        public void FromFactory<TResult>(Func<TResult> factory)
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TResult>>(factory, _resolver));
        }

        public void FromFactory<TOne, TResult>(Func<TOne, TResult> factory)
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TOne, TResult>>(factory, _resolver));
        }

        public void FromFactory<TOne, TTwo, TResult>(Func<TOne, TTwo, TResult> factory)
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TOne, TTwo, TResult>>(factory, _resolver));
        }

        public void FromFactory<TOne, TTwo, TThree, TResult>(Func<TOne, TTwo, TThree, TResult> factory)
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TOne, TTwo, TThree, TResult>>(factory, _resolver));
        }

        public void FromFactory<TOne, TTwo, TThree, TFour, TResult>(Func<TOne, TTwo, TThree, TFour, TResult> factory)
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TOne, TTwo, TThree, TFour, TResult>>(factory, _resolver));
        }
    }
}