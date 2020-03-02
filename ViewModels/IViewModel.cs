using System.ComponentModel;
using DependencyInjection;
using Views;

namespace ViewModels
{
    public interface IViewModel
    {
        Container GetContainer();
    }
}