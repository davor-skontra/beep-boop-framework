using System;

namespace DependencyInjection.Exceptions
{
    public class DependencyCannotBeAssignedException<TType, TAssignedType> : Exception
    {
        public DependencyCannotBeAssignedException()
            : base($"{typeof(TType).FullName} does not implement {typeof(TAssignedType).FullName}")
        {
        }
    }
}