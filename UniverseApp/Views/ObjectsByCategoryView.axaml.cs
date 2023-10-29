using Avalonia.Controls;
using Avalonia.Input;
using UniverseApp.ViewModels;

namespace UniverseApp.Views;

public partial class ObjectsByCategoryView : UserControl
{
    private readonly ObjectsByCategoryViewModel _objectsByCategoryViewModel = ObjectsByCategoryViewModel.GetViewModel();
    
    public ObjectsByCategoryView()
    {
        InitializeComponent();
        
        FirstAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, _objectsByCategoryViewModel.FirstAstronomicalObject.Name,
                _objectsByCategoryViewModel.FirstAstronomicalObject.Description);
        };
        
        MiddleAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, _objectsByCategoryViewModel.MiddleAstronomicalObject.Name,
                _objectsByCategoryViewModel.MiddleAstronomicalObject.Description);
        };
        
        LastAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, _objectsByCategoryViewModel.LastAstronomicalObject.Name,
                _objectsByCategoryViewModel.LastAstronomicalObject.Description);
        };
    }
    
    private void HideDescription(object? sender, PointerEventArgs e)
    {
        ObjectDescription.Opacity = 0;
    }
    
    private void DisplayAstronomicalObjectDescription(object? sender, PointerEventArgs e, string name, string? description)
    {
        _objectsByCategoryViewModel.ObjectDescription = string.IsNullOrEmpty(description) ? name : name + " - " + description;
        
        ObjectDescription.Opacity = 1;
    }
}