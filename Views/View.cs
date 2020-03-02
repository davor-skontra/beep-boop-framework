using System;
using System.Reflection;
using DependencyInjection;
using UnityEngine;
using ViewModels;

namespace Views
{
    public abstract class View<TViewModel>: MonoBehaviour where TViewModel: IViewModel
    {
        
        protected void Inject()
        {
            ViewViewModelBinding.GetContainer(this).Inject(this);
        }
    }
}