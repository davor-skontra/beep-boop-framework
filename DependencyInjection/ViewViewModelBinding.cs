using System;
using System.Reflection;
using ViewModels;
using Views;

namespace DependencyInjection
{
    public class ViewViewModelBinding
    {
        private static IocContainer _injector;

        public static void SetInjector(IocContainer injector)
        {
            _injector = injector;
        }

        public static IocContainer GetContainer<TViewModel>(View<TViewModel> view) where TViewModel : IViewModel
        {
            var errorMessage = $"Set Injector in {nameof(ViewViewModelBinding)} from composition root before retrieval";

            if (_injector == null)
            {
                throw new NullReferenceException(errorMessage);
            }

            return _injector;
        }
    }
}