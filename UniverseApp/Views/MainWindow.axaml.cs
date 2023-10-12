using Avalonia.Controls;
using Avalonia.Input;
using UniverseApp.Models.Enums;
using UniverseApp.Services;
using UniverseApp.ViewModels;

namespace UniverseApp.Views;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _mainWindowViewModel = MainWindowViewModel.GetViewModel();
    public MainWindow()
    {
        InitializeComponent();

        var service = new ZoomInOutService();
        
        KeyUp += delegate(object? sender, KeyEventArgs e)
        {
            service.OnKeyUp(sender, e, FirstAstronomicalObject, MiddleAstronomicalObject, LastAstronomicalObject);
        };
        
        FirstAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, WhichAstronomicalObject.First);
        };
        
        MiddleAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, WhichAstronomicalObject.Middle);
        };
        
        LastAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(sender, e, WhichAstronomicalObject.Last);
        };
    }
    
    private void HideDescription(object? sender, PointerEventArgs e)
    {
        ObjectDescription.Opacity = 0;
    }
    
    private void DisplayAstronomicalObjectDescription(
        object? sender, 
        PointerEventArgs e, 
        WhichAstronomicalObject astronomicalObject)
    {
        var description = "";
        
        switch (astronomicalObject)
        {
            case WhichAstronomicalObject.First:
            {
                description = _mainWindowViewModel.FirstAstronomicalObject.Name;

                description = string.IsNullOrEmpty(_mainWindowViewModel.FirstAstronomicalObject.Description)
                    ? description
                    : description + " - " + _mainWindowViewModel.FirstAstronomicalObject.Description;
                
                break;
            }
            
            case WhichAstronomicalObject.Middle:
            {
                description = _mainWindowViewModel.MiddleAstronomicalObject.Name;

                description = string.IsNullOrEmpty(_mainWindowViewModel.MiddleAstronomicalObject.Description)
                    ? description
                    : description + " - " + _mainWindowViewModel.MiddleAstronomicalObject.Description;
                
                break;
            }
            
            case WhichAstronomicalObject.Last:
            {
                description = _mainWindowViewModel.LastAstronomicalObject.Name;

                description = string.IsNullOrEmpty(_mainWindowViewModel.LastAstronomicalObject.Description)
                    ? description
                    : description + " - " + _mainWindowViewModel.LastAstronomicalObject.Description;
                
                break;
            }
        }
        
        _mainWindowViewModel.ObjectDescription = description;
        
        ObjectDescription.Opacity = 1;
    }
}