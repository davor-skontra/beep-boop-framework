namespace DependencyInjection.Bindings
{
    public class SingletonBinding : IBinding
    {
        private readonly object _singleton;
        private readonly IocContainer.Injector _injector;

        private object _resolved;

        public SingletonBinding(object singleton, IocContainer.Injector injector)
        {
            _singleton = singleton;
            _injector = injector;
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