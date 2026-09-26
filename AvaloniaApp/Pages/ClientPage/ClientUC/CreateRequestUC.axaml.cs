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
        
        int? serialNum = null;
        if (!string.IsNullOrEmpty(SerNumber.Text))
        {
            serialNum = int.Parse(SerNumber.Text);
        }
        
        var newRequest = new Request
        {
            SerialNumber = serialNum,
            Description = Description.Text,
            Type = selectedType.Id,
            Clientid = VariableData.CurrentUser?.Id,
            Mechaid = null,
            Stageid = 1
        };
        
        App.DbContext.Requests.Add(newRequest);
        App.DbContext.SaveChanges();

        SerNumber.Text = "";
        Description.Text = "";

    }
}