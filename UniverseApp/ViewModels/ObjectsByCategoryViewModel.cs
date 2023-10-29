using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using ReactiveUI;
using UniverseApp.Models;

namespace UniverseApp.ViewModels;

public sealed class ObjectsByCategoryViewModel : ViewModelBase
{
    private static ObjectsByCategoryViewModel? _objectsByCategoryViewModel;
    private ObservableCollection<AstronomicalObject> _astronomicalObjects =
        new ObservableCollection<AstronomicalObject>(new AstronomicalObjects().ListOfObjects);
    private AstronomicalObject _firstAstronomicalObject;
    private AstronomicalObject _middleAstronomicalObject;
    private AstronomicalObject _lastAstronomicalObject;
    private ComboBoxItem? _selectedCategory;
    private double _objectsOpacity = 1;
    private string _objectDescription = "None";

    public ObjectsByCategoryViewModel()
    {
        _firstAstronomicalObject = _astronomicalObjects[0];
        _middleAstronomicalObject = _astronomicalObjects[1];
        _lastAstronomicalObject = _astronomicalObjects[2];
    }
    
    public static ObjectsByCategoryViewModel GetViewModel()
    {
        if (_objectsByCategoryViewModel == null)
            _objectsByCategoryViewModel = new ObjectsByCategoryViewModel();
        
        return _objectsByCategoryViewModel;
    }

    public ObservableCollection<AstronomicalObject> AstronomicalObjects => _astronomicalObjects;
    
    public ComboBoxItem? SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedCategory, value);

            if (value.Content == "None")
            {
                _astronomicalObjects =
                    new ObservableCollection<AstronomicalObject>(new AstronomicalObjects().ListOfObjects);
            }

            else
            {
                _astronomicalObjects =
                    new ObservableCollection<AstronomicalObject>(
                        new AstronomicalObjects().ListOfObjects.Where(o => o.Category == value.Content));
            }

            LastAstronomicalObject = _astronomicalObjects[2];
            FirstAstronomicalObject = _astronomicalObjects[0];
            MiddleAstronomicalObject = _astronomicalObjects[1];
        }
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