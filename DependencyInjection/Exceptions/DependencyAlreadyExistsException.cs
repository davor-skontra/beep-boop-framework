using System;

namespace DependencyInjection.Exceptions
{
    public class DependencyAlreadyExistsException: Exception
    {
        public DependencyAlreadyExistsException(Type type) : base($"Dependency of type {type.FullName} already exists.")
        {
            
        }
    }
}