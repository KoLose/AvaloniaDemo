using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApp.Data;

namespace AvaloniaApp.Pages.ManagerPages.ManagerUC;

public partial class EditRequestWindow : Window
{
    private readonly Request _req;

    public EditRequestWindow(Request req)
    {
        InitializeComponent();
        _req = req;
        
        SerialBox.Text = _req.SerialNumber?.ToString();
        
        TypeBox.ItemsSource = App.DbContext.TypeRequests.ToList();
        TypeBox.SelectedItem = App.DbContext.TypeRequests.FirstOrDefault(t => t.Id == _req.Type);
        
        MechBox.ItemsSource = App.DbContext.Users.Where(u => u.Roleid == 2).ToList();
        MechBox.SelectedItem = App.DbContext.Users.FirstOrDefault(u => u.Id == _req.Mechaid);
    }

    private void Save(object? sender, RoutedEventArgs e)
    {
        if (int.TryParse(SerialBox.Text, out int sn)) _req.SerialNumber = sn;
        if (TypeBox.SelectedItem is TypeRequest t) _req.Type = t.Id;
        if (MechBox.SelectedItem is User m) _req.Mechaid = m.Id;
        
        App.DbContext.SaveChanges();
        Close();
    }
}