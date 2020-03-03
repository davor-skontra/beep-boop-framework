using System;
using DependencyInjection.Exceptions;

namespace DependencyInjection.Bindings
{
    public class BindingBuilder<TBoundType>
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

        public void ToSingleton<TType>(TType singleton)
            where TType : class, TBoundType
        {
            _adder(typeof(TType), new SingletonBinding(singleton, _injector));
        }

        public void ToFactory<TResult>(Func<TResult> factory)
            where TResult : TBoundType
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TResult>>(factory, _resolver));
        }

        public void ToFactory<TOne, TResult>(Func<TOne, TResult> factory)
            where TResult : TBoundType
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TOne, TResult>>(factory, _resolver));
        }

        public void ToFactory<TOne, TTwo, TResult>(Func<TOne, TTwo, TResult> factory)
            where TResult : TBoundType
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TOne, TTwo, TResult>>(factory, _resolver));
        }

        public void ToFactory<TOne, TTwo, TThree, TResult>(Func<TOne, TTwo, TThree, TResult> factory)
            where TResult : TBoundType
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TOne, TTwo, TThree, TResult>>(factory, _resolver));
        }

        public void ToFactory<TOne, TTwo, TThree, TFour, TResult>(Func<TOne, TTwo, TThree, TFour, TResult> factory)
            where TResult : TBoundType
        {
            _adder(typeof(TResult), new FactoryBinding<Func<TOne, TTwo, TThree, TFour, TResult>>(factory, _resolver));
        }
    }
}