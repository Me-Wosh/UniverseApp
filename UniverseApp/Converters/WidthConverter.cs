using System;
using System.Globalization;
using System.Linq;
using Avalonia.Data;
using Avalonia.Data.Converters;
using UniverseApp.ViewModels;

namespace UniverseApp.Converters;

public class WidthConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
            return new BindingNotification(new ArgumentNullException(nameof(value)), BindingErrorType.Error);
        
        try
        {
            var mainWindowViewModel = AllObjectsViewModel.GetViewModel();
            
            var firstObject = mainWindowViewModel.FirstAstronomicalObject;
            var middleObject = mainWindowViewModel.MiddleAstronomicalObject;
            var lastObject = mainWindowViewModel.LastAstronomicalObject;
            
            var objectsDiameter = System.Convert.ToDouble(value);
            var largestDiameter =
                new [] { firstObject.Diameter, middleObject.Diameter, lastObject.Diameter }.Max();
            
            const short largestObjectPixelsWidth = 360;
            
            return objectsDiameter / largestDiameter * largestObjectPixelsWidth;
        }

        catch (Exception e)
        {
            return new BindingNotification(e, BindingErrorType.Error);
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}