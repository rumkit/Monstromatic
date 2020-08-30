using Microsoft.Extensions.DependencyInjection;
using Monstromatic.Models;
using Monstromatic.ViewModels;

namespace Monstromatic.Utils
{
    public class ServiceHub
    {
        public static readonly ServiceHub Default = new ServiceHub();

        public readonly ServiceProvider ServiceProvider;

        private ServiceHub()
        {
            var services = new ServiceCollection();
            BuildServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void BuildServices(ServiceCollection services)
        {
            services.AddSingleton<IFeatureRepository, ReflectiveFeatureRepository>();
            services.AddTransient<MainWindowViewModel>();
        }
    }
}
