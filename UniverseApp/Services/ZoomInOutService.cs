using Avalonia.Input;
using UniverseApp.Models;
using UniverseApp.ViewModels;

namespace UniverseApp.Services;

public sealed class ZoomInOutService
{
    private readonly AllObjectsViewModel _allObjectsViewModel = AllObjectsViewModel.GetViewModel();

    public void OnKeyUp(
        object? sender, 
        KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
            {
                var astronomicalObjectsList = new AstronomicalObjects().ListOfObjects;
                var firstObjectId = astronomicalObjectsList.FindIndex(
                        o => o.Name == _allObjectsViewModel.FirstAstronomicalObject.Name); 

                if (firstObjectId <= 0)
                    break;
                
                _allObjectsViewModel.ObjectsOpacity = 0;
                
                _allObjectsViewModel.LastAstronomicalObject = _allObjectsViewModel.MiddleAstronomicalObject;
                
                _allObjectsViewModel.MiddleAstronomicalObject = _allObjectsViewModel.FirstAstronomicalObject;
                
                _allObjectsViewModel.FirstAstronomicalObject = new AstronomicalObjects().ListOfObjects[firstObjectId - 1];
                
                _allObjectsViewModel.ObjectsOpacity = 1;
                
                break;
            }

            case Key.Down:
            {
                var astronomicalObjectsList = new AstronomicalObjects().ListOfObjects;
                var lastObjectId = astronomicalObjectsList.FindIndex(
                    o => o.Name == _allObjectsViewModel.LastAstronomicalObject.Name);

                if (lastObjectId >= astronomicalObjectsList.Count - 1)
                    break;

                var temp = _allObjectsViewModel.LastAstronomicalObject;
                
                _allObjectsViewModel.ObjectsOpacity = 0;
                
                _allObjectsViewModel.LastAstronomicalObject = astronomicalObjectsList[lastObjectId + 1];
                
                _allObjectsViewModel.FirstAstronomicalObject = _allObjectsViewModel.MiddleAstronomicalObject;
                
                _allObjectsViewModel.MiddleAstronomicalObject = temp;

                _allObjectsViewModel.ObjectsOpacity = 1;
                
                break;
            }
        }

        _allObjectsViewModel.ObjectDescription = "";
    }
}