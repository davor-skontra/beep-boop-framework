using DependencyInjection.Containers;

namespace DependencyInjection.Bindings
{
    public class SingletonBinding<TBound>: IBinding where TBound: class
    {
        private readonly TBound _bound;
        
        private TBound _resolved;
        
        public SingletonBinding(TBound bound)
        {
            _bound = bound;
        }

        public BindingKind Kind => BindingKind.Singleton;

        public TResolving Resolve<TResolving>(Container container) where TResolving: TBound
        {
            if (_resolved != null)
            {
                return (TResolving) _resolved;
            }
            container.Inject(_bound);
            _resolved = _bound;

            return (TResolving) _resolved;
        }
    }
}
