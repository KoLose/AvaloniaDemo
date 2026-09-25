using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApp.Pages.ManagerPages.ManagerUC;


namespace AvaloniaApp.Pages.ManagerPages;

public partial class ManagerPage : Window
{
    public ManagerPage()
    {
        InitializeComponent();
    }

    private void Get(object? sender, RoutedEventArgs e)
    {
        MainContent.Content = new CreateRequest();
    }

    private void Create(object? sender, RoutedEventArgs e)
    {
        MainContent.Content = new RequestUC();
    }
}