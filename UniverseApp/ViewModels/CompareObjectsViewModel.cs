using System;
using ReactiveUI;
using UniverseApp.Models;

namespace UniverseApp.ViewModels;

public class CompareObjectsViewModel : ViewModelBase
{
    private AstronomicalObject? _firstSelectedObject;
    private AstronomicalObject? _secondSelectedObject;
    private double _firstObjectWidth = 360;
    private double _secondObjectWidth = 360;
    private string? _objectDescription;
    
    public AstronomicalObject? FirstSelectedObject
    {
        get => _firstSelectedObject;
        set
        { 
            this.RaiseAndSetIfChanged(ref _firstSelectedObject, value);
            SetObjectsWidths();
        }
    }
    
    public AstronomicalObject? SecondSelectedObject
    {
        get => _secondSelectedObject;
        set
        {
            this.RaiseAndSetIfChanged(ref _secondSelectedObject, value);
            SetObjectsWidths();
        }
    }

    public double FirstObjectWidth
    {
        get => _firstObjectWidth;
        private set => this.RaiseAndSetIfChanged(ref _firstObjectWidth, value);
    }
    
    public double SecondObjectWidth
    {
        get => _secondObjectWidth;
        private set => this.RaiseAndSetIfChanged(ref _secondObjectWidth, value);
    }

    public string? ObjectDescription
    {
        get => _objectDescription;
        set => this.RaiseAndSetIfChanged(ref _objectDescription, value);
    }

    private void SetObjectsWidths()
    {
        if (_firstSelectedObject is null || _secondSelectedObject is null) 
            return;
        
        var largestObjectDiameter = Math.Max(_firstSelectedObject.Diameter, _secondSelectedObject.Diameter);
        FirstObjectWidth = _firstSelectedObject.Diameter / largestObjectDiameter * 360;
        SecondObjectWidth = _secondSelectedObject.Diameter / largestObjectDiameter * 360;
    }
}