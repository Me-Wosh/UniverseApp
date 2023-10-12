using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace UniverseApp.Converters;

public class ImagePathMultiConverter : IMultiValueConverter
{
    public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count != 3)
            return new BindingNotification(
                new ArgumentException("Please provide Category, Name and Classification"),
                BindingErrorType.Error);
        
        var category = values[0] as string ?? "";
        var name = values[1] as string ?? "";
        var classification = values[2] as string ?? "";
        
        if (category == "Galaxy")
            return new Bitmap($"Assets/Galaxies/{name}.png");

        return File.Exists($"Assets/{category}s/{name}.png") 
            ? new Bitmap($"Assets/{category}s/{name}.png") 
            : new Bitmap($"Assets/{category}s/{classification}.png");
    }
}