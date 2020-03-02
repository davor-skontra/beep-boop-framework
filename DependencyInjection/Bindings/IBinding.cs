using DependencyInjection.Containers;

namespace DependencyInjection.Bindings
{
    public interface IBinding
    {
        BindingKind Kind { get; }
        TResolving Resolve<TResolving>(Container container);
    }
}