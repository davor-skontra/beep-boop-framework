using System;
using System.Reflection;
using DependencyInjection.Containers;
using ViewModels;
using Views;

namespace DependencyInjection
{
    public class ViewViewModelBinding
    {
        private static Container _injector;

        public static void SetInjector(Container injector)
        {
            _injector = injector;
        }

        public static Container GetContainer<TViewModel>(View<TViewModel> view) where TViewModel : IViewModel
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