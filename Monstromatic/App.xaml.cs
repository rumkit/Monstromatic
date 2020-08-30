using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Monstromatic.Utils;
using Monstromatic.ViewModels;
using Monstromatic.Views;

namespace Monstromatic
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = ServiceHub.Default.ServiceProvider.Get<MainWindowViewModel>(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
