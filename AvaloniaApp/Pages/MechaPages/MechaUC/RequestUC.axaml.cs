using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApp.Pages.MechaPages.MechaUC;

public partial class RequestUC : UserControl
{
    public RequestUC()
    {
        InitializeComponent();
        LoadMyRequests();
    }

    private void LoadMyRequests()
    {
        if (App.DbContext == null || VariableData.CurrentUser == null) return;

        Grid.ItemsSource = App.DbContext.Requests
            .Include(r => r.Client)
            .Include(r => r.TypeNavigation)
            .Include(r => r.Stage)
            .Where(r => r.Mechaid == VariableData.CurrentUser.Id && r.Stageid != 3)
            .ToList();
    }

    private async void OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (Grid.SelectedItem is not Request req) return;
        
        var win = new SelectEquipmentWindow(req);
        var parent = TopLevel.GetTopLevel(this) as Window;
        if (parent != null) await win.ShowDialog(parent);
        
    }
}