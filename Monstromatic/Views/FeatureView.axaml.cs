using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Monstromatic.Views
{
    public partial class FeatureView : UserControl
    {
        public FeatureView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
