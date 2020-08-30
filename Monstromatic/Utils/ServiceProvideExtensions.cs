using System;

namespace Monstromatic.Utils
{
    static class ServiceProvideExtensions
    {
        public static T Get<T>(this IServiceProvider provider)
        {
            var service = provider.GetService(typeof(T));
            return (T) service;
        }
    }
}
