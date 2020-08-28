using System.Reflection;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Monstromatic.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.Title += $" version {GetVersion()}-alpha";
        }

        private string GetVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }
    }
}
