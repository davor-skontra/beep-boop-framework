using System;
 
 namespace DependencyInjection.Exceptions
 {
     public class DependencyCannotBeResolvedException : Exception
     {
         public DependencyCannotBeResolvedException(Type type)
             : base($"Cannot resolve dependency of type {type.FullName}")
         {
         }
     }
 }