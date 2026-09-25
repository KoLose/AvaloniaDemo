using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApp.Data;
using AvaloniaApp.Pages.ManagerPages;

namespace AvaloniaApp.Pages.Auth;

public partial class LoginUC : UserControl
{
    public LoginUC()
    {
        InitializeComponent();
    }

    private void LoginBtn(object? sender, RoutedEventArgs e)
    {
         if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
        {
            return;
        }
        var user = App.DbContext.Users
            .FirstOrDefault(u => u.Login == LoginBox.Text && u.Passowrd == PasswordBox.Text);

        if (user == null)
        {
            return;
        }
        
        if (user.Roleid == 1)
        {
            VariableData.CurrentUser = user;
            new ClientPage.ClientPage().Show();
        }
        else if (user.Roleid == 2)
        {
            VariableData.CurrentUser = user;
            new ManagerPages.ManagerPage().Show();
        }
        else if (user.Roleid == 3)
        {
            VariableData.CurrentUser = user;
            new MechaPages.MechaPage().Show();
        }
    }
}