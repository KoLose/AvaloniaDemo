using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApp.Pages.ClientPage.ClientUC;

public partial class CurrentRequestWindow : Window
{
    private readonly Request _request;

    public CurrentRequestWindow(Request request)
    {
        InitializeComponent();
        _request = request;
        LoadComments();
    }

    private void LoadComments()
    {
        if (App.DbContext == null) return;
        
        var comments = App.DbContext.Comments
            .Where(c => c.Requestid == _request.Id)
            .ToList();

        CommentsList.ItemsSource = comments;
    }

    private void CloseBtn(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}