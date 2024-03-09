using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace UniverseApp.Converters;

public class DiameterToMetresMultiConverter : IMultiValueConverter
{
    public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        // to be fair i don't know what's going on, ImagePathMultiConverter works totally fine but
        // for some reason in this converter avalonia thinks that values[0] is of type 'Avalonia.UnsetValueType'
        // so i do this check to avoid exception
        if (values[0].ToString() == "(unset)")
        {
            return "0 metres";
        }
        
        var diameter = (decimal?)values[0] ?? 0;
        var sizeInPixels = values.Count == 2 && values[1] != null ? (decimal)(double)values[1] : 283m;

        if (diameter == 0 || sizeInPixels == 0)
        {
            return "0 metres";
        }
        
        // how many of object's meters are in a screen centimeter, parameter is the object size in pixels, by default 283
        var metresInCentimeter = diameter / sizeInPixels * 37.79527559m;

        switch (metresInCentimeter)
        {
            case < 0.000000001m:
            {
                var numberAndMinus10Power = metresInCentimeter.ToString("e2").Split("e-");

                // replace e+ with * 10^ which i find more readable and delete leading zeros, for example turn e-004
                // into * 10^-4 instead of * 10^-004
                return $"{numberAndMinus10Power[0]} * 10^-{System.Convert.ToInt32(numberAndMinus10Power[1])} meters";
            }

            case < 0.1m:
            {
                var result = diameter.ToString();
                short i = 2, j = 0;

                while (result[i] == '0')
                {
                    i++;
                }

                while (i < result.Length && j < 3)
                {
                    i++;
                    j++;
                }

                // remove significant digits after the 3rd one, for example turn 0.0654654 into 0.0654

                if (i + 1 < result.Length)
                {
                    return result.Remove(i + 1) + " meters";
                }

                return result + " meters";
            }

            case < 1000:
            {
                return metresInCentimeter.ToString("N2") + " meters";
            }
        }

        metresInCentimeter /= 1000;

        if (metresInCentimeter <= 1_000_000_000_000)
        {
            return metresInCentimeter.ToString("N0") + " kilometers";
        }

        var numberAndPlus10Power = metresInCentimeter.ToString("e2").Split("e+");

        // replace e+ with * 10^ which i find more readable and delete leading zeros, for example turn e+004 into * 10^4
        return $"{numberAndPlus10Power[0]} * 10^{System.Convert.ToInt32(numberAndPlus10Power[1])} kilometers";
    }
}