using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Monstromatic.Views;

public class AboutWindow : Window
{
    public AboutWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        var infoTextBlock = this.FindControl<TextBlock>("InfoTextBlock");
        infoTextBlock.Text = $"Monstromatic 👾 2022\r\nversion {GetVersion()}-alpha";
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
            var myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true; 
            myProcess.StartInfo.FileName = "https://github.com/rumkit/Monstromatic";
            myProcess.Start();
        }
        catch
        {
            Console.Error.WriteLine("Cannot open the link. Process start failure.");
        }
    }
}