using System;

namespace Monstromatic.Utils
{
    internal static class ServiceProviderExtensions
    {
        public static T Get<T>(this IServiceProvider provider)
        {
            var service = provider.GetService(typeof(T));
            return (T) service;
        }
    }
}
