using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Windows.Input;

namespace Monstromatic.Views
{
    public partial class HitCounter : UserControl
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

        public static readonly StyledProperty<ICommand> ResetCommandProperty =
            AvaloniaProperty.Register<HitCounter, ICommand>(nameof(ResetCommand));

        public ICommand ResetCommand
        {
            get => GetValue(ResetCommandProperty);
            set => SetValue(ResetCommandProperty, value);
        }

        public static readonly StyledProperty<bool> IsResetVisibleProperty =
            AvaloniaProperty.Register<HitCounter, bool>(nameof(IsResetVisible), true);

        public bool IsResetVisible
        {
            get => GetValue(IsResetVisibleProperty);
            set => SetValue(IsResetVisibleProperty, value);
        }

        public static readonly StyledProperty<string> TextProperty =
            AvaloniaProperty.Register<HitCounter, string>(nameof(Text));

        public string Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private void IncreaseButtonClick(object sender, RoutedEventArgs e) => CounterSource++;

        private void DecreaseButtonClick(object sender, RoutedEventArgs e) => CounterSource--;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
