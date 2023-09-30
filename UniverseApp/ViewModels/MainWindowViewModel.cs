using ReactiveUI;
using UniverseApp.Models;

namespace UniverseApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private AstronomicalObject _firstAstronomicalObject;
    private AstronomicalObject _secondAstronomicalObject;
    private AstronomicalObject _thirdAstronomicalObject;

    public MainWindowViewModel()
    {
        var astronomicalObjects = new AstronomicalObjects();
        
        FirstAstronomicalObject = astronomicalObjects.ListOfObjects[0];
        SecondAstronomicalObject = astronomicalObjects.ListOfObjects[1];
        ThirdAstronomicalObject = astronomicalObjects.ListOfObjects[2];
    }
    
    public AstronomicalObject FirstAstronomicalObject
    {
        get => _firstAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _firstAstronomicalObject, value);
    }
    
    public AstronomicalObject SecondAstronomicalObject
    {
        get => _secondAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _secondAstronomicalObject, value);
    }
    
    public AstronomicalObject ThirdAstronomicalObject
    {
        get => _thirdAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _thirdAstronomicalObject, value);
    }
}