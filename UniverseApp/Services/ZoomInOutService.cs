using Avalonia.Controls;
using Avalonia.Input;
using UniverseApp.Models;
using UniverseApp.ViewModels;

namespace UniverseApp.Services;

public sealed class ZoomInOutService
{
    private readonly MainWindowViewModel _mainWindowViewModel = MainWindowViewModel.GetViewModel();

    public void OnKeyUp(
        object? sender, 
        KeyEventArgs e, 
        Image firstObject, 
        Image middleObject,
        Image lastObject)
    {
        switch (e.Key)
        {
            case Key.Up:
            {
                var firstObjectId = _mainWindowViewModel.FirstAstronomicalObject.Id;

                if (firstObjectId <= 0)
                    break;
                
                lastObject.Opacity = 0;
                _mainWindowViewModel.LastAstronomicalObject = _mainWindowViewModel.MiddleAstronomicalObject;
                lastObject.Opacity = 1;

                middleObject.Opacity = 0;
                _mainWindowViewModel.MiddleAstronomicalObject = _mainWindowViewModel.FirstAstronomicalObject;
                middleObject.Opacity = 1;

                firstObject.Opacity = 0;
                _mainWindowViewModel.FirstAstronomicalObject = new AstronomicalObjects().ListOfObjects[firstObjectId - 1];
                firstObject.Opacity = 1;
                
                break;
            }

            case Key.Down:
            {
                var lastObjectId = _mainWindowViewModel.LastAstronomicalObject.Id;
                var astronomicalObjectsList = new AstronomicalObjects().ListOfObjects;

                if (lastObjectId >= astronomicalObjectsList.Count - 1)
                    break;

                var temp = _mainWindowViewModel.LastAstronomicalObject;
                
                lastObject.Opacity = 0;
                _mainWindowViewModel.LastAstronomicalObject = astronomicalObjectsList[lastObjectId + 1];
                lastObject.Opacity = 1;
                
                firstObject.Opacity = 0;
                _mainWindowViewModel.FirstAstronomicalObject = _mainWindowViewModel.MiddleAstronomicalObject;
                firstObject.Opacity = 1;
                
                middleObject.Opacity = 0;
                _mainWindowViewModel.MiddleAstronomicalObject = temp;
                middleObject.Opacity = 1;

                break;
            }
        }
    }
}