using System;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData;
using ReactiveUI;
using UniverseApp.Models;
using UniverseApp.Services;

namespace UniverseApp.ViewModels;

public sealed class ObjectsByCategoryViewModel : ViewModelBase
{
    private AstronomicalObject _leftAstronomicalObject;
    private AstronomicalObject _middleAstronomicalObject;
    private AstronomicalObject _rightAstronomicalObject;
    // max pixel width
    private double _leftAstronomicalObjectWidth = 283;
    private double _middleAstronomicalObjectWidth = 283;
    private double _rightAstronomicalObjectWidth = 283;
    private string? _selectedCategory;
    private double _objectsOpacity = 1;
    private string _objectDescription = "None";

    public ObjectsByCategoryViewModel()
    {
        AstronomicalObjects = new ObservableCollection<AstronomicalObject>(new AstronomicalObjects().ListOfObjects);
        
        LeftAstronomicalObject = AstronomicalObjects[0];
        MiddleAstronomicalObject = AstronomicalObjects[1];
        RightAstronomicalObject = AstronomicalObjects[2];
        
        this.WhenAnyValue(
            x => x.LeftAstronomicalObject,
            x => x.MiddleAstronomicalObject,
            x => x.RightAstronomicalObject
        ).Subscribe(_ =>
        {
            var diameters = new[]
                { _leftAstronomicalObject.Diameter, _middleAstronomicalObject.Diameter, _rightAstronomicalObject.Diameter };

            var resizedObjects = new ResizeObjectsService().ResizeObjects(diameters);
            
            LeftAstronomicalObjectWidth = resizedObjects[0];
            MiddleAstronomicalObjectWidth = resizedObjects[1];
            RightAstronomicalObjectWidth = resizedObjects[2];
        });
    }
    
    public ObservableCollection<AstronomicalObject> AstronomicalObjects { get; }
    
    public string? SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedCategory, value);

            var listOfObjects = new AstronomicalObjects().ListOfObjects;
            
            if (value == "None")
            {
                AstronomicalObjects.Clear();
                AstronomicalObjects.AddRange(listOfObjects);
            }

            else
            {
                AstronomicalObjects.Clear();
                AstronomicalObjects.AddRange(listOfObjects.Where(o => o.Category == value));
            }

            LeftAstronomicalObject = AstronomicalObjects[0];
            MiddleAstronomicalObject = AstronomicalObjects[1];
            RightAstronomicalObject = AstronomicalObjects[2];
        }
    }
    
    public AstronomicalObject LeftAstronomicalObject
    {
        get => _leftAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _leftAstronomicalObject, value);
    }
    
    public AstronomicalObject MiddleAstronomicalObject
    {
        get => _middleAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _middleAstronomicalObject, value);
    }
    
    public AstronomicalObject RightAstronomicalObject
    {
        get => _rightAstronomicalObject;
        set => this.RaiseAndSetIfChanged(ref _rightAstronomicalObject, value);
    }

    public double LeftAstronomicalObjectWidth
    {
        get => _leftAstronomicalObjectWidth;
        set => this.RaiseAndSetIfChanged(ref _leftAstronomicalObjectWidth, value);
    }
    
    public double MiddleAstronomicalObjectWidth
    {
        get => _middleAstronomicalObjectWidth;
        set => this.RaiseAndSetIfChanged(ref _middleAstronomicalObjectWidth, value);
    }
    
    public double RightAstronomicalObjectWidth
    {
        get => _rightAstronomicalObjectWidth;
        set => this.RaiseAndSetIfChanged(ref _rightAstronomicalObjectWidth, value);
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