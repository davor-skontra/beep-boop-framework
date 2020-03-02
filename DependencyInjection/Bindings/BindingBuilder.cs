using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace DependencyInjection.Containers
{
    public class BindingBuilder
    {
        private readonly Container _container;

        public BindingBuilder(Container container)
        {
            _container = container;
        }

        public void FromSingleton<TType>(TType type)
        {
            
        }
    }
}