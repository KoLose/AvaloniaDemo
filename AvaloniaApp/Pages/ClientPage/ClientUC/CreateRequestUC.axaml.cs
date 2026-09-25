using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApp.Data;

namespace AvaloniaApp.Pages.ClientPage.ClientUC;

public partial class CreateRequestUC : UserControl
{
    public CreateRequestUC()
    {
        InitializeComponent();
        LoadyType();
    }

    private void LoadyType()
    {
        var types = App.DbContext.TypeRequests.ToList();
        
        TypeComboBox.ItemsSource = types;
        
        if (types.Any())
        {
            TypeComboBox.SelectedIndex = 0;
        }
    }

    private void CreateBtn(object? sender, RoutedEventArgs e)
    {
        if (TypeComboBox.SelectedItem == null)
        {
            return;
        }
        
        var selectedType = (TypeRequest)TypeComboBox.SelectedItem;
        
        var newRequest = new Request
        {
            SerialNumber = int.TryParse(SerNumber.Text, out var sn) ? sn : null,
            Description = Description.Text,
            Type = selectedType.Id,
            Clientid = VariableData.CurrentUser?.Id,
            Mechaid = null
        };
        
        App.DbContext.Requests.Add(newRequest);
        App.DbContext.SaveChanges();

        SerNumber.Text = "";
        Description.Text = "";

    }
}