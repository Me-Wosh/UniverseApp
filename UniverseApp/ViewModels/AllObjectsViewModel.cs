using ReactiveUI;
using UniverseApp.Models;

namespace UniverseApp.ViewModels;

public class AllObjectsViewModel : ViewModelBase
{
    private static AllObjectsViewModel? _allObjectsViewModel;
    private AstronomicalObject _firstAstronomicalObject;
    private AstronomicalObject _middleAstronomicalObject;
    private AstronomicalObject _lastAstronomicalObject;
    private double _objectsOpacity = 1;
    private string _objectDescription = "";

    public AllObjectsViewModel()
    {
        var astronomicalObjects = new AstronomicalObjects();
        
        _firstAstronomicalObject = astronomicalObjects.ListOfObjects[0];
        _middleAstronomicalObject = astronomicalObjects.ListOfObjects[1];
        _lastAstronomicalObject = astronomicalObjects.ListOfObjects[2];
    }

    public static AllObjectsViewModel GetViewModel()
    {
        if (_allObjectsViewModel == null)
            _allObjectsViewModel = new AllObjectsViewModel();
        
        return _allObjectsViewModel;
    }
    
    public AstronomicalObject FirstAstronomicalObject
    {
        get => _firstAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _firstAstronomicalObject, value);
    }
    
    public AstronomicalObject MiddleAstronomicalObject
    {
        get => _middleAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _middleAstronomicalObject, value);
    }
    
    public AstronomicalObject LastAstronomicalObject
    {
        get => _lastAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _lastAstronomicalObject, value);
    }

    public double ObjectsOpacity
    {
        get => _objectsOpacity; 
        set => this.RaiseAndSetIfChanged(ref _objectsOpacity, value);
    }
    
    public string ObjectDescription
    {
        get => _objectDescription; 
        set => this.RaiseAndSetIfChanged(ref _objectDescription, value);
    }
}