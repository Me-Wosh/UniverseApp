using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;
using UniverseApp.Models;
using UniverseApp.ViewModels;

namespace UniverseApp.Views;

public partial class ObjectsByCategoryView : UserControl
{
    private static bool _animationPlaying;
    private static int _currentZoomLevel;

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

        const double leftObjectHeightAndWidth = 82.948275862068968;
        const double middleObjectHeightAndWidth = 193.22068965517241;
        const double rightObjectHeightAndWidth = 283;
        
        Canvas.SetLeft(LeftAstronomicalObject, (350 - leftObjectHeightAndWidth) / 2);
        Canvas.SetTop(LeftAstronomicalObject, (283 - leftObjectHeightAndWidth) / 2);
                
        Canvas.SetLeft(MiddleAstronomicalObject, (350 - middleObjectHeightAndWidth) / 2);
        Canvas.SetTop(MiddleAstronomicalObject, (282.5 - middleObjectHeightAndWidth) / 2);
        
        Canvas.SetLeft(RightAstronomicalObject, (350 - rightObjectHeightAndWidth) / 2);
        Canvas.SetTop(RightAstronomicalObject, (283 - rightObjectHeightAndWidth) / 2);

        var astronomicalObjectsCount = new AstronomicalObjects().ListOfObjects.Count;
        GenerateZoomLevels(astronomicalObjectsCount);
        
        KeyUp += OnKeyUp;
        
        Loaded += (_, _) =>
        {
            Focus();
            
            (DataContext as ObjectsByCategoryViewModel)!.AstronomicalObjectsChanged += (_, _) =>
            {
                astronomicalObjectsCount = (DataContext as ObjectsByCategoryViewModel)!.AstronomicalObjects.Count;
                
                if (ZoomLevels.Children.Count > 0)
                {
                    ZoomLevels.Children.Clear();
                }
                
                GenerateZoomLevels(astronomicalObjectsCount);
                
                CenterObjects(false, (DataContext as ObjectsByCategoryViewModel)!);
            };
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
    
    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (_animationPlaying)
            return;
        
        var objectsByCategoryViewModel = (DataContext as ObjectsByCategoryViewModel)!;
        
        switch (e.Key)
        { 
            case Key.Up:
            {
                var leftObjectIndex = objectsByCategoryViewModel.AstronomicalObjects.ToList()
                    .FindIndex(o => o.Name == objectsByCategoryViewModel.LeftAstronomicalObject.Name);
                
                if (leftObjectIndex <= 0)
                    break;

                ZoomIn(objectsByCategoryViewModel, leftObjectIndex);
                
                break;
            }

            case Key.Down:
            {
                var rightObjectIndex = objectsByCategoryViewModel.AstronomicalObjects.ToList()
                    .FindIndex(o => o.Name == objectsByCategoryViewModel.RightAstronomicalObject.Name);

                if (rightObjectIndex >= objectsByCategoryViewModel.AstronomicalObjects.Count - 3)
                    break;
                
                ZoomOut(objectsByCategoryViewModel, rightObjectIndex);
                
                break;
            }
        }
    }

    private async void ZoomIn(ObjectsByCategoryViewModel objectsByCategoryViewModel, int leftObjectIndex)
    {
        _animationPlaying = true;
                
        objectsByCategoryViewModel.LeftAstronomicalObjectWidth = 600;
        objectsByCategoryViewModel.MiddleAstronomicalObjectWidth = 600;
        objectsByCategoryViewModel.RightAstronomicalObjectWidth = 600;
                
        CenterObjects(false, objectsByCategoryViewModel);
                
        objectsByCategoryViewModel.ObjectsOpacity = 0;
                
        await Task.Delay(TimeSpan.FromMilliseconds(700));
                
        objectsByCategoryViewModel.LeftAstronomicalObjectWidth = 0;
        objectsByCategoryViewModel.MiddleAstronomicalObjectWidth = 0;
        objectsByCategoryViewModel.RightAstronomicalObjectWidth = 0;
                
        CenterObjects(true, objectsByCategoryViewModel);

        await Task.Delay(TimeSpan.FromMilliseconds(700));
                
        objectsByCategoryViewModel.LeftAstronomicalObject =
            objectsByCategoryViewModel.AstronomicalObjects[leftObjectIndex - 3];
                
        objectsByCategoryViewModel.MiddleAstronomicalObject =
            objectsByCategoryViewModel.AstronomicalObjects[leftObjectIndex - 2];
                
        objectsByCategoryViewModel.RightAstronomicalObject = 
            objectsByCategoryViewModel.AstronomicalObjects[leftObjectIndex - 1];
                
        CenterObjects(false, objectsByCategoryViewModel);
                
        objectsByCategoryViewModel.ObjectsOpacity = 1;
        
        var previousCircle = (Ellipse)ZoomLevels
            .Children
            .Single(c => c.Name == _currentZoomLevel.ToString());

        previousCircle.Fill = Brushes.Black;

        _currentZoomLevel = (leftObjectIndex - 3) / 3;

        var currentCircle = (Ellipse)ZoomLevels
            .Children
            .Single(c => c.Name == _currentZoomLevel.ToString());
        
        currentCircle.Fill = Brushes.White;

        _animationPlaying = false;
    }

    private async void ZoomOut(ObjectsByCategoryViewModel objectsByCategoryViewModel, int rightObjectIndex)
    {
        _animationPlaying = true;
                
        objectsByCategoryViewModel.LeftAstronomicalObjectWidth = 0;
        objectsByCategoryViewModel.MiddleAstronomicalObjectWidth = 0;
        objectsByCategoryViewModel.RightAstronomicalObjectWidth = 0;
                
        CenterObjects(true, objectsByCategoryViewModel);
                
        objectsByCategoryViewModel.ObjectsOpacity = 0;
                
        await Task.Delay(TimeSpan.FromMilliseconds(700));
                
        objectsByCategoryViewModel.LeftAstronomicalObjectWidth = 1000;
        objectsByCategoryViewModel.MiddleAstronomicalObjectWidth = 1000;
        objectsByCategoryViewModel.RightAstronomicalObjectWidth = 1000;
                
        CenterObjects(false, objectsByCategoryViewModel);
                
        await Task.Delay(TimeSpan.FromMilliseconds(700));
                
        objectsByCategoryViewModel.LeftAstronomicalObject =
            objectsByCategoryViewModel.AstronomicalObjects[rightObjectIndex + 1];
                
        objectsByCategoryViewModel.MiddleAstronomicalObject =
            objectsByCategoryViewModel.AstronomicalObjects[rightObjectIndex + 2];
                
        objectsByCategoryViewModel.RightAstronomicalObject = 
            objectsByCategoryViewModel.AstronomicalObjects[rightObjectIndex + 3];
                
        CenterObjects(false, objectsByCategoryViewModel);
                
        objectsByCategoryViewModel.ObjectsOpacity = 1;
        
        var previousCircle = (Ellipse)ZoomLevels
            .Children
            .Single(c => c.Name == _currentZoomLevel.ToString());

        previousCircle.Fill = Brushes.Black;

        _currentZoomLevel = (rightObjectIndex + 1) / 3;
        
        var currentCircle = (Ellipse)ZoomLevels
            .Children
            .Single(c => c.Name == _currentZoomLevel.ToString());
        
        currentCircle.Fill = Brushes.White;
        
        _animationPlaying = false;
    }
    
    private void CenterObjects(bool sizeZeroed, ObjectsByCategoryViewModel objectsByCategoryViewModel)
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
    
    private void GenerateZoomLevels(int astronomicalObjectsCount)
    {
        _currentZoomLevel = 0;
        
        for (int i = 0; i < astronomicalObjectsCount / 3; i++)
        {
            var circle = new Ellipse
            {
                Name = i.ToString(),
                Width = 15,
                Height = 15,
                Stroke = Brushes.White,
                StrokeThickness = 1,
                Fill = i == 0 ? Brushes.White : Brushes.Black
            };

            circle.PointerEntered += (_, _) => { Cursor = new Cursor(StandardCursorType.Hand); }; 
            
            circle.PointerPressed += (_, _) =>
            {
                if (_animationPlaying)
                    return;

                var pressedCircleIndex = Convert.ToInt32(circle.Name);
                var zoomDirection = pressedCircleIndex - _currentZoomLevel;
                
                if (zoomDirection == 0)
                    return;
                
                var objectsByCategoryViewModel = (ObjectsByCategoryViewModel)DataContext!;

                if (zoomDirection < 0)
                {
                    ZoomIn(objectsByCategoryViewModel, pressedCircleIndex * 3 + 3);
                }

                else
                {
                    ZoomOut(objectsByCategoryViewModel, pressedCircleIndex * 3 - 1);
                }
            };
            
            ZoomLevels.Children.Insert(i, circle);    
        }
    }
}