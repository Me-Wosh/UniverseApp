using System.Collections.Generic;

namespace UniverseApp.Models;

public sealed class AstronomicalObjects
{
    public readonly List<AstronomicalObject> ListOfObjects = new ()
    {
        new AstronomicalObject
        {
            Name = "Mercury",
            Diameter = 4_880_000,
            Category = ObjectCategory.Planet,
            Classification = ObjectClassification.TerrestrialPlanet,
            Description = "The Smallest planet of the Solar System"
        },
        
        new AstronomicalObject
        {
            Name = "Earth", 
            Diameter = 12_742_000, 
            Category = ObjectCategory.Planet,
            Classification = ObjectClassification.TerrestrialPlanet,
            Description = "The only planet known to harbor life"
        },
        
        new AstronomicalObject
        {
            Name = "Proxima Centauri b",
            Diameter = 16_564_600,
            Category = ObjectCategory.Planet,
            Classification = ObjectClassification.TerrestrialPlanet,
            Description = "The closest potentially habitable planet"
        },
        
        new AstronomicalObject
        {
            Name = "Neptune", 
            Diameter = 49_244_000,
            Category = ObjectCategory.Planet,
            Classification = ObjectClassification.IceGiant
        },
        
        new AstronomicalObject
        {
            Name = "Jupiter", 
            Diameter = 139_822_000, 
            Category = ObjectCategory.Planet,
            Classification = ObjectClassification.GasGiant,
            Description = "The largest planet of the Solar System"
        },
        
        new AstronomicalObject
        {
            Name = "Proxima Centauri",
            Diameter = 214_554_000,
            Category = ObjectCategory.Star,
            Classification = ObjectClassification.RedDwarf,
            Description = "The nearest star to The Sun (4.2465 light years away)"
        },
        
        new AstronomicalObject
        {
            Name = "The Sun",
            Diameter = 1_392_700_000,
            Category = ObjectCategory.Star,
            Classification = ObjectClassification.YellowDwarf
        }
    };
}