using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Monstromatic.Views;

public partial class ConfirmationWindow : Window
{
    public ConfirmationWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    public ConfirmationWindow(string text) : this()
    {
        var textBlock = this.FindControl<TextBlock>("ConfirmationTextBlock");
        textBlock.Text = text;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void ButtonYes_OnClick(object sender, RoutedEventArgs e)
    {
        ConfirmResult(true);
    }
    
    private void ButtonNo_OnClick(object sender, RoutedEventArgs e)
    {
        ConfirmResult(false);
    }

    private void ConfirmResult(bool result)
    {
        this.Close(result);
    }
}