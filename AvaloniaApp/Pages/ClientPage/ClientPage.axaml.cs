using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApp.Pages.ClientPage.ClientUC;

namespace AvaloniaApp.Pages.ClientPage;

public partial class ClientPage : Window
{
    public ClientPage()
    {
        InitializeComponent();
    }

    private void Create(object? sender, RoutedEventArgs e)
    {
        MainContent.Content = new CreateRequestUC();
    }

    private void Get(object? sender, RoutedEventArgs e)
    {
        MainContent.Content = new RequestUC();
    }
}