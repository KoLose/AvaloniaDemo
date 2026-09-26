using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApp.Pages.ClientPage.ClientUC;

public partial class RequestUC : UserControl
{
    private List<Request> _requests = [];
    public RequestUC()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        _requests = App.DbContext.Requests
            .Include(t => t.TypeNavigation)
            .Where(r => r.Clientid == VariableData.CurrentUser.Id)
            .ToList();
        
        ItemsGrid.ItemsSource = _requests;
    }

    private void ArticleSearchBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var term = ArticleSearchBox.Text?.Trim();

        if (string.IsNullOrEmpty(term))
        {
            ItemsGrid.ItemsSource = _requests;
            return;
        }
        
        var filtered = _requests.Where(r => 
            r.SerialNumber.HasValue && 
            r.SerialNumber.Value.ToString().Contains(term, StringComparison.OrdinalIgnoreCase)
        ).ToList();

        ItemsGrid.ItemsSource = filtered;
    }
    private async void ItemsGrid_DoubleTapped(object? sender, TappedEventArgs e)
    {
        if (ItemsGrid.SelectedItem is not Request req) return;

        var win = new CurrentRequestWindow(req);
        var parent = TopLevel.GetTopLevel(this) as Window;
    
        if (parent != null)
        {
            await win.ShowDialog(parent);
        }
    }
    
}