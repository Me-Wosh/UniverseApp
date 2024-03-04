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
    private decimal _diameter;

    public CompareObjectsViewModel()
    {
        this.WhenAnyValue(
                x => x.FirstSelectedObject,
                x => x.SecondSelectedObject
            )
            .Subscribe(objects =>
            {
                if (objects.Item1 == null)
                {
                    if (objects.Item2 == null)
                    {
                        return;
                    }

                    Diameter = objects.Item2.Diameter;
                }

                else
                {
                    if (objects.Item2 != null)
                    {
                        Diameter = Math.Max(objects.Item1.Diameter, objects.Item2.Diameter);
                    }

                    else
                    {
                        Diameter = objects.Item1.Diameter;
                    }
                }
            });
    }
    
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

    public decimal Diameter
    {
        get => _diameter;
        private set => this.RaiseAndSetIfChanged(ref _diameter, value);
    }

    public double Pixels => 360;
    
    private void SetObjectsWidths()
    {
        if (_firstSelectedObject is null || _secondSelectedObject is null) 
            return;
        
        var largestObjectDiameter = Math.Max(_firstSelectedObject.Diameter, _secondSelectedObject.Diameter);
        FirstObjectWidth = (double)(_firstSelectedObject.Diameter / largestObjectDiameter * 360);
        SecondObjectWidth = (double)(_secondSelectedObject.Diameter / largestObjectDiameter * 360);
    }
}