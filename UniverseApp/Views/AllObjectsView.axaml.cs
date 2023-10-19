using Avalonia.Controls;
using Avalonia.Input;
using UniverseApp.ViewModels;

namespace UniverseApp.Views;

public partial class AllObjectsView : UserControl
{
    private readonly AllObjectsViewModel _allObjectsViewModel = AllObjectsViewModel.GetViewModel();
    
    public AllObjectsView()
    {
        InitializeComponent();
        
        FirstAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, _allObjectsViewModel.FirstAstronomicalObject.Name,
                _allObjectsViewModel.FirstAstronomicalObject.Description);
        };
        
        MiddleAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, _allObjectsViewModel.MiddleAstronomicalObject.Name,
                _allObjectsViewModel.MiddleAstronomicalObject.Description);
        };
        
        LastAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, _allObjectsViewModel.LastAstronomicalObject.Name,
                _allObjectsViewModel.LastAstronomicalObject.Description);
        };
    }
    
    private void HideDescription(object? sender, PointerEventArgs e)
    {
        ObjectDescription.Opacity = 0;
    }
    
    private void DisplayAstronomicalObjectDescription(object? sender, PointerEventArgs e, string name, string? description)
    {
        _allObjectsViewModel.ObjectDescription = string.IsNullOrEmpty(description) ? name : name + " - " + description;
        
        ObjectDescription.Opacity = 1;
    }
}