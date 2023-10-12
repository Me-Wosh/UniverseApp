using ReactiveUI;
using UniverseApp.Models;

namespace UniverseApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static MainWindowViewModel? _mainWindowViewModel;
    private AstronomicalObject _firstAstronomicalObject = new ();
    private AstronomicalObject _middleAstronomicalObject = new ();
    private AstronomicalObject _lastAstronomicalObject = new ();
    private string _objectDescription = "";

    public MainWindowViewModel()
    {
        var astronomicalObjects = new AstronomicalObjects();
        
        FirstAstronomicalObject = astronomicalObjects.ListOfObjects[0];
        MiddleAstronomicalObject = astronomicalObjects.ListOfObjects[1];
        LastAstronomicalObject = astronomicalObjects.ListOfObjects[2];
    }

    public static MainWindowViewModel GetViewModel()
    {
        if (_mainWindowViewModel == null)
            _mainWindowViewModel = new MainWindowViewModel();
        
        return _mainWindowViewModel;
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

    public string ObjectDescription
    {
        get => _objectDescription; 
        set => this.RaiseAndSetIfChanged(ref _objectDescription, value);
    }
}