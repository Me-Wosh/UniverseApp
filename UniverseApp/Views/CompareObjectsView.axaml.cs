using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using UniverseApp.Models;
using UniverseApp.ViewModels;

namespace UniverseApp.Views;

public partial class CompareObjectsView : UserControl
{
    private static readonly List<AstronomicalObject> ListOfObjects = new AstronomicalObjects().ListOfObjects;
    public CompareObjectsView()
    {
        InitializeComponent();

        FirstSearchList.ItemsSource = ListOfObjects;
        SecondSearchList.ItemsSource = ListOfObjects; 
        
        var longestItemLength = ListOfObjects.Max(o => o.Name.Length);

        FirstSearchContainer.Width = longestItemLength * 10;
        SecondSearchContainer.Width = longestItemLength * 10;
        
        PointerPressed += HideSearchList;
        
        FirstSelectedObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(
                sender, 
                e, 
                (DataContext as CompareObjectsViewModel).FirstSelectedObject.Name,
                (DataContext as CompareObjectsViewModel).FirstSelectedObject.Description);
        };
        
        SecondSelectedObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            DisplayAstronomicalObjectDescription(
                sender, 
                e, 
                (DataContext as CompareObjectsViewModel).SecondSelectedObject.Name,
                (DataContext as CompareObjectsViewModel).SecondSelectedObject.Description);
        };

        FirstSelectedObject.PointerExited += (object? sender, PointerEventArgs e) => { ObjectDescription.Opacity = 0; };
        SecondSelectedObject.PointerExited += (object? sender, PointerEventArgs e) => { ObjectDescription.Opacity = 0; };
    }

    private void UpdateFirstSearchList(object sender, TextChangingEventArgs textChangingEventArgs)
    {
        var input = ((TextBox)sender).Text;

        if (string.IsNullOrEmpty(input))
        {
            FirstSearchList.ItemsSource = ListOfObjects;
            return;
        }
        
        FirstSearchList.ItemsSource = ListOfObjects.Where(o => o.Name.ToLower().Contains(input.ToLower()));
    }
    
    private void UpdateSecondSearchList(object sender, TextChangingEventArgs textChangingEventArgs)
    {
        var input = ((TextBox)sender).Text;
        
        if (string.IsNullOrEmpty(input))
        {
            SecondSearchList.ItemsSource = ListOfObjects;
            return;
        }
            
        SecondSearchList.ItemsSource = ListOfObjects.Where(o => o.Name.ToLower().Contains(input.ToLower()));
    }

    private void HideSearchList(object? sender, RoutedEventArgs e)
    {
        FirstSearchList.IsVisible = false;
        SecondSearchList.IsVisible = false;
    }

    private void ShowFirstSearchList(object? sender, PointerReleasedEventArgs e)
    {
        FirstSearchList.IsVisible = true;
    }

    private void ShowSecondSearchList(object? sender, PointerReleasedEventArgs e)
    {
        SecondSearchList.IsVisible = true;
    }
    
    private void DisplayAstronomicalObjectDescription(object? sender, PointerEventArgs e, string name, string? description)
    {
        (DataContext as CompareObjectsViewModel).ObjectDescription = 
            string.IsNullOrEmpty(description) ? name : name + " - " + description;
        
        ObjectDescription.Opacity = 1;
    }
}