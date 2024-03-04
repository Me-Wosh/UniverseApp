using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using UniverseApp.Models;
using UniverseApp.ViewModels;

namespace UniverseApp.Views;

public partial class ObjectsByCategoryView : UserControl
{
    private static bool _animationPlaying;
    public ObjectsByCategoryView()
    {
        InitializeComponent();
        
        var items = typeof(ObjectCategory).GetFields().Select(f => f.Name).ToList();
        
        CategorySelector.ItemsSource = items.Prepend("None");
        
        LeftAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            if (_animationPlaying)
            {
                return;
            }
            
            DisplayAstronomicalObjectDescription(
                sender, 
                e, 
                (DataContext as ObjectsByCategoryViewModel)!.LeftAstronomicalObject.Name,
                (DataContext as ObjectsByCategoryViewModel)!.LeftAstronomicalObject.Description);
        };
        
        MiddleAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            if (_animationPlaying)
            {
                return;
            }
            
            DisplayAstronomicalObjectDescription(
                sender,
                e, 
                (DataContext as ObjectsByCategoryViewModel)!.MiddleAstronomicalObject.Name,
                (DataContext as ObjectsByCategoryViewModel)!.MiddleAstronomicalObject.Description);
        };
        
        RightAstronomicalObject.PointerEntered += delegate(object? sender, PointerEventArgs e)
        {
            if (_animationPlaying)
            {
                return;
            }
            
            DisplayAstronomicalObjectDescription(
                sender, 
                e, 
                (DataContext as ObjectsByCategoryViewModel)!.RightAstronomicalObject.Name,
                (DataContext as ObjectsByCategoryViewModel)!.RightAstronomicalObject.Description);
        };
        
        // Center objects before rendering to avoid 700 milliseconds transition
        
        Canvas.SetLeft(LeftAstronomicalObject, (350 - 83.37297610567113) / 2);
        Canvas.SetTop(LeftAstronomicalObject, (283 - 83.37297610567113) / 2);
                
        Canvas.SetLeft(MiddleAstronomicalObject, (350 - 217.6923076923077) / 2);
        Canvas.SetTop(MiddleAstronomicalObject, (282.5 - 217.6923076923077) / 2);
        
        Canvas.SetLeft(RightAstronomicalObject, 0);
        Canvas.SetTop(RightAstronomicalObject, 0);
        
        Loaded += (_, _) =>
        {
            var parentWindow = Window.GetTopLevel(this);
            parentWindow!.KeyUp += OnKeyUp;
        };
    }
    
    private void HideDescription(object? sender, PointerEventArgs e)
    {
        ObjectDescription.Opacity = 0;
    }
    
    private void DisplayAstronomicalObjectDescription(object? sender, PointerEventArgs e, string name, string? description)
    {
        ObjectDescription.Text = string.IsNullOrEmpty(description) ? name : name + " - " + description;
        
        ObjectDescription.Opacity = 1;
    }
    
    private async void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (_animationPlaying)
            return;
        
        var objectsByCategoryViewModel = (DataContext as ObjectsByCategoryViewModel)!;
        
        switch (e.Key)
        { 
            case Key.Up:
            {
                var firstObjectId = objectsByCategoryViewModel.AstronomicalObjects.ToList()
                    .FindIndex(o => o.Name == objectsByCategoryViewModel.LeftAstronomicalObject.Name);
                
                if (firstObjectId <= 0)
                    break;

                _animationPlaying = true;
                
                objectsByCategoryViewModel.LeftAstronomicalObjectWidth = 600;
                objectsByCategoryViewModel.MiddleAstronomicalObjectWidth = 600;
                objectsByCategoryViewModel.RightAstronomicalObjectWidth = 600;
                
                CenterObjects(false);
                
                objectsByCategoryViewModel.ObjectsOpacity = 0;
                
                await Task.Delay(TimeSpan.FromMilliseconds(700));
                
                objectsByCategoryViewModel.LeftAstronomicalObjectWidth = 0;
                objectsByCategoryViewModel.MiddleAstronomicalObjectWidth = 0;
                objectsByCategoryViewModel.RightAstronomicalObjectWidth = 0;
                
                CenterObjects(true);

                await Task.Delay(TimeSpan.FromMilliseconds(700));
                
                objectsByCategoryViewModel.LeftAstronomicalObject =
                    objectsByCategoryViewModel.AstronomicalObjects[firstObjectId - 3];
                
                objectsByCategoryViewModel.MiddleAstronomicalObject =
                    objectsByCategoryViewModel.AstronomicalObjects[firstObjectId - 2];
                
                objectsByCategoryViewModel.RightAstronomicalObject = 
                    objectsByCategoryViewModel.AstronomicalObjects[firstObjectId - 1];
                
                CenterObjects(false);
                
                objectsByCategoryViewModel.ObjectsOpacity = 1;

                _animationPlaying = false;
                
                break;
            }

            case Key.Down:
            {
                var lastObjectId = objectsByCategoryViewModel.AstronomicalObjects.ToList()
                    .FindIndex(o => o.Name == objectsByCategoryViewModel.RightAstronomicalObject.Name);

                if (lastObjectId >= objectsByCategoryViewModel.AstronomicalObjects.Count - 4)
                    break;

                _animationPlaying = true;
                
                objectsByCategoryViewModel.LeftAstronomicalObjectWidth = 0;
                objectsByCategoryViewModel.MiddleAstronomicalObjectWidth = 0;
                objectsByCategoryViewModel.RightAstronomicalObjectWidth = 0;
                
                CenterObjects(true);
                
                objectsByCategoryViewModel.ObjectsOpacity = 0;
                
                await Task.Delay(TimeSpan.FromMilliseconds(700));
                
                objectsByCategoryViewModel.LeftAstronomicalObjectWidth = 1000;
                objectsByCategoryViewModel.MiddleAstronomicalObjectWidth = 1000;
                objectsByCategoryViewModel.RightAstronomicalObjectWidth = 1000;
                
                CenterObjects(false);
                
                await Task.Delay(TimeSpan.FromMilliseconds(700));
                
                objectsByCategoryViewModel.LeftAstronomicalObject =
                    objectsByCategoryViewModel.AstronomicalObjects[lastObjectId + 1];
                
                objectsByCategoryViewModel.MiddleAstronomicalObject =
                    objectsByCategoryViewModel.AstronomicalObjects[lastObjectId + 2];
                
                objectsByCategoryViewModel.RightAstronomicalObject = 
                    objectsByCategoryViewModel.AstronomicalObjects[lastObjectId + 3];
                
                CenterObjects(false);
                
                objectsByCategoryViewModel.ObjectsOpacity = 1;

                _animationPlaying = false;
                
                break;
            }
        }
        
        
        void CenterObjects(bool sizeZeroed)
        {
            switch (sizeZeroed)
            {
                case true:
                {
                    Canvas.SetLeft(LeftAstronomicalObject, CanvasTopLeft.Bounds.Width / 2);
                    Canvas.SetTop(LeftAstronomicalObject, CanvasTopLeft.Bounds.Height / 2);
                    Canvas.SetLeft(MiddleAstronomicalObject, CanvasBottomMiddle.Bounds.Width / 2);
                    Canvas.SetTop(MiddleAstronomicalObject, CanvasBottomMiddle.Bounds.Height / 2);
                    Canvas.SetLeft(RightAstronomicalObject, CanvasTopRight.Bounds.Width / 2);
                    Canvas.SetTop(RightAstronomicalObject, CanvasTopRight.Bounds.Height / 2);

                    break;
                }
                
                case false:
                {
                    Canvas.SetLeft(LeftAstronomicalObject,
                        (CanvasTopLeft.Bounds.Width - objectsByCategoryViewModel.LeftAstronomicalObjectWidth) / 2);

                    Canvas.SetTop(LeftAstronomicalObject,
                        (CanvasTopLeft.Bounds.Height - objectsByCategoryViewModel.LeftAstronomicalObjectWidth) / 2);

                    Canvas.SetLeft(MiddleAstronomicalObject,
                        (CanvasBottomMiddle.Bounds.Width - objectsByCategoryViewModel.MiddleAstronomicalObjectWidth) /
                        2);

                    Canvas.SetTop(MiddleAstronomicalObject,
                        (CanvasBottomMiddle.Bounds.Height - objectsByCategoryViewModel.MiddleAstronomicalObjectWidth) /
                        2);

                    Canvas.SetLeft(RightAstronomicalObject,
                        (CanvasTopRight.Bounds.Width - objectsByCategoryViewModel.RightAstronomicalObjectWidth) / 2);

                    Canvas.SetTop(RightAstronomicalObject,
                        (CanvasTopRight.Bounds.Height - objectsByCategoryViewModel.RightAstronomicalObjectWidth) / 2);

                    break;
                }
            }
        }
    }
}