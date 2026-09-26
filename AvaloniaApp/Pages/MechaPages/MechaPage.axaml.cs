using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApp.Pages.MechaPages.MechaUC;

namespace AvaloniaApp.Pages.MechaPages;

public partial class MechaPage : Window
{
    public MechaPage()
    {
        InitializeComponent();
    }
    private void Get(object? sender, RoutedEventArgs e)
    {
        MainContent.Content = new RequestUC();
    }
}