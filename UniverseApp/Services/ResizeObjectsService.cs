using System.Collections.Generic;
using System.Linq;

namespace UniverseApp.Services;

public class ResizeObjectsService
{
    public List<double> ResizeObjects(IEnumerable<decimal> diameters)
    {
        var resizedWidths = new List<double>();
        var largestDiameter = diameters.Max();

        foreach (var diameter in diameters)
        {
            var resizedWidth = (double)(diameter / largestDiameter * 283);
            resizedWidths.Add(resizedWidth);
        }

        return resizedWidths;
    }
}