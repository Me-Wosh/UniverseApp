using Avalonia.Input;
using UniverseApp.Models;
using UniverseApp.ViewModels;

namespace UniverseApp.Services;

public sealed class ZoomInOutService
{
    private readonly MainWindowViewModel _mainWindowViewModel = MainWindowViewModel.GetViewModel();

    public void OnKeyUp(object? sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
            {
                var firstObjectId = _mainWindowViewModel.FirstAstronomicalObject.Id;

                if (firstObjectId <= 0)
                    break;
                
                _mainWindowViewModel.LastAstronomicalObject = _mainWindowViewModel.MiddleAstronomicalObject;
                _mainWindowViewModel.MiddleAstronomicalObject = _mainWindowViewModel.FirstAstronomicalObject;
                _mainWindowViewModel.FirstAstronomicalObject = new AstronomicalObjects().ListOfObjects[firstObjectId - 1];
                
                break;
            }

            case Key.Down:
            {
                var lastObjectId = _mainWindowViewModel.LastAstronomicalObject.Id;
                var astronomicalObjectsList = new AstronomicalObjects().ListOfObjects;

                if (lastObjectId >= astronomicalObjectsList.Count - 1)
                    break;

                var temp = _mainWindowViewModel.LastAstronomicalObject;
                _mainWindowViewModel.LastAstronomicalObject = astronomicalObjectsList[lastObjectId + 1];
                _mainWindowViewModel.FirstAstronomicalObject = _mainWindowViewModel.MiddleAstronomicalObject;
                _mainWindowViewModel.MiddleAstronomicalObject = temp;

                break;
            }
        }
    }
}