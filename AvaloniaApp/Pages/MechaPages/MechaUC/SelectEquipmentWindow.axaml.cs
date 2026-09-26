using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApp.Data;

namespace AvaloniaApp.Pages.MechaPages.MechaUC;

public class EquipItem : Equipment
{
    public int Amount { get; set; } = 0;
}

public partial class SelectEquipmentWindow : Window
{
    private readonly Request _request;
    private List<EquipItem> _allEquip = new();

    public SelectEquipmentWindow(Request request)
    {
        InitializeComponent();
        _request = request;
        LoadEquipment();
    }

    private void LoadEquipment()
    {
        if (App.DbContext == null) return;
        
        var dbList = App.DbContext.Equipment.ToList();
        
        _allEquip = dbList.Select(e => new EquipItem 
        { 
            Id = e.Id, 
            Name = e.Name, 
            Amount = 0 
        }).ToList();

        EquipGrid.ItemsSource = _allEquip;
    }

    private void SaveBtn(object? sender, RoutedEventArgs e)
    {
        if (App.DbContext == null) return;
        
        var selected = _allEquip.Where(x => x.Amount > 0).ToList();

        foreach (var item in selected)
        {
            var link = new RequestEquipment
            {
                Id = Guid.NewGuid().ToString(),
                Reqid = _request.Id,
                Eqid = item.Id
            };
            
            App.DbContext.RequestEquipments.Add(link);
        }

        try 
        {
            App.DbContext.SaveChanges();
            Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка сохранения: {ex.Message}");
        }
    }

    private void CancelBtn(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}