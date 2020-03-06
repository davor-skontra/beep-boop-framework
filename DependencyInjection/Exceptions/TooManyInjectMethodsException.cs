using System;

namespace DependencyInjection.Exceptions
{
    public class TooManyInjectMethodsException: Exception
    {
        public TooManyInjectMethodsException(Type type) : base($"Type {type.FullName} has too many injection methods")
        {
            
        }
    }
}