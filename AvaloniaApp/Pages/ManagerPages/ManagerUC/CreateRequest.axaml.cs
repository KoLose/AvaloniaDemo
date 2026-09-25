using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApp.Data;

namespace AvaloniaApp.Pages.ManagerPages.ManagerUC;

public partial class CreateRequest : UserControl
{
    public CreateRequest()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        if (App.DbContext == null) return;

        var types = App.DbContext.TypeRequests.ToList();
        TypeComboBox.ItemsSource = types;
        if (types.Any()) TypeComboBox.SelectedIndex = 0;
        
        var clients = App.DbContext.Users.ToList(); 
        ClientComboBox.ItemsSource = clients;
        if (clients.Any()) ClientComboBox.SelectedIndex = 0;
    }

    private void CreateBtn(object? sender, RoutedEventArgs e)
    {
        if (ClientComboBox.SelectedItem is not User selectedClient) return;
        if (TypeComboBox.SelectedItem is not TypeRequest selectedType) return;
        
        int? serialNum = null;
        if (!string.IsNullOrEmpty(SerNumber.Text))
        {
            if (int.TryParse(SerNumber.Text, out int sn))
            {
                serialNum = sn;
            }
        }
        
        var newRequest = new Request
        {
            SerialNumber = serialNum,
            Description = Description.Text,
            Type = selectedType.Id,
            Clientid = selectedClient.Id,
            Mechaid = null
        };

        App.DbContext.Requests.Add(newRequest);
        App.DbContext.SaveChanges();
        
        SerNumber.Text = "";
        Description.Text = "";
        
        Console.WriteLine("Заявка создана!");
    }
}