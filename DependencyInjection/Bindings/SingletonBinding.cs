namespace DependencyInjection.Bindings
{
    public class SingletonBinding : IBinding
    {
        public readonly bool ResolveLazy;
        
        private readonly object _singleton;
        private readonly IocContainer.Injector _injector;

        private object _resolved;

        public SingletonBinding(object singleton, IocContainer.Injector injector, bool resolveLazy = false)
        {
            _singleton = singleton;
            _injector = injector;
            ResolveLazy = resolveLazy;
        }

        public object Resolve()
        {
            if (_resolved != null)
            {
                return _resolved;
            }

            _injector(_singleton);
            _resolved = _singleton;

            return _resolved;
        }
    }
}