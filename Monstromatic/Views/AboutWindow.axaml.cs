using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Monstromatic.Utils;

namespace Monstromatic.Views;

public class AboutWindow : Window
{
    private readonly IProcessHelper _processHelper;

    public AboutWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    public AboutWindow(IProcessHelper processHelper) : this()
    {
        _processHelper = processHelper;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        var infoTextBlock = this.FindControl<TextBlock>("InfoTextBlock");
        infoTextBlock.Text = $"Monstromatic 👾 2022\r\nversion {GetVersion()}";
    }
    
    private string GetVersion()
    {
        return GetType().Assembly.GetName().Version?.ToString();
    }

    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Linkbutton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _processHelper.StartNew("https://github.com/rumkit/Monstromatic");
        }
        catch
        {
            Console.Error.WriteLine("Cannot open the link. Process start failure.");
        }
    }
}