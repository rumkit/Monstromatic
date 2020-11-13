using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Monstromatic.Views
{
    public class HitCounter : UserControl
    {
        public HitCounter()
        {
            this.InitializeComponent();
        }

        public static readonly StyledProperty<int> CounterSourceProperty =
            AvaloniaProperty.Register<HitCounter, int>(nameof(CounterSource));

        public int CounterSource
        {
            get => GetValue(CounterSourceProperty);
            set => SetValue(CounterSourceProperty, value);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
