using System.Linq;
using Avalonia.Input;
using UniverseApp.ViewModels;

namespace UniverseApp.Services;

public sealed class ZoomInOutService
{
    private readonly ObjectsByCategoryViewModel _objectsByCategoryViewModel = ObjectsByCategoryViewModel.GetViewModel();

    public void OnKeyUp(object? sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
            {
                var astronomicalObjectsList = _objectsByCategoryViewModel.AstronomicalObjects.ToList();
                var firstObjectId = astronomicalObjectsList.FindIndex(
                    o => o.Name == _objectsByCategoryViewModel.FirstAstronomicalObject.Name);

                if (firstObjectId <= 0)
                    break;

                _objectsByCategoryViewModel.ObjectsOpacity = 0;

                _objectsByCategoryViewModel.LastAstronomicalObject = _objectsByCategoryViewModel.MiddleAstronomicalObject;

                _objectsByCategoryViewModel.MiddleAstronomicalObject = _objectsByCategoryViewModel.FirstAstronomicalObject;

                _objectsByCategoryViewModel.FirstAstronomicalObject = astronomicalObjectsList[firstObjectId - 1];

                _objectsByCategoryViewModel.ObjectsOpacity = 1;

                break;
            }

            case Key.Down:
            {
                var astronomicalObjectsList = _objectsByCategoryViewModel.AstronomicalObjects.ToList();
                var lastObjectId = astronomicalObjectsList.FindIndex(
                    o => o.Name == _objectsByCategoryViewModel.LastAstronomicalObject.Name);

                if (lastObjectId >= astronomicalObjectsList.Count - 1)
                    break;

                var temp = _objectsByCategoryViewModel.LastAstronomicalObject;
                
                _objectsByCategoryViewModel.ObjectsOpacity = 0;

                _objectsByCategoryViewModel.LastAstronomicalObject = astronomicalObjectsList[lastObjectId + 1];

                _objectsByCategoryViewModel.FirstAstronomicalObject = _objectsByCategoryViewModel.MiddleAstronomicalObject;

                _objectsByCategoryViewModel.MiddleAstronomicalObject = temp;

                _objectsByCategoryViewModel.ObjectsOpacity = 1;

                break;
            }
        }
    }
}