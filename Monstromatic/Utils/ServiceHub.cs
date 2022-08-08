using Microsoft.Extensions.DependencyInjection;
using Monstromatic.Data;
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
            services.AddTransient<MainWindowViewModel>();
            services.AddSingleton<IDataStorage<MonstromaticSettings>, SettingsStorage>();
            services.AddSingleton<IDataStorage<MonsterFeature[]>, FeaturesStorage>();
            services.AddSingleton<IAppSettingsProvider, AppSettingsProvider>();
        }
    }
}
