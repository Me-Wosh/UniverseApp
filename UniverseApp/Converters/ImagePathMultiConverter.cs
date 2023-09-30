using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace UniverseApp.Converters;

public class ImagePathMultiConverter : IMultiValueConverter
{
    public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count != 2)
            return BindingOperations.DoNothing;
        
        var type = values[0] as string ?? "";
        var name = values[1] as string ?? "";
        
        return type == "Galaxy"
            ? new Bitmap($"Assets/Galaxies/{name}.png")
            : new Bitmap($"Assets/{type}s/{name}.png");
    }
}