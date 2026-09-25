using Avalonia.Controls;

namespace AvaloniaApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainContent.Content = new Pages.Auth.LoginUC();
    }
}