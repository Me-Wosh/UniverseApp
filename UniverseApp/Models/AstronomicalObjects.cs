using System.Collections.Generic;

namespace UniverseApp.Models;

public sealed class AstronomicalObjects
{
    public readonly List<AstronomicalObject> ListOfObjects = new ()
    {
        new AstronomicalObject
        {
            Id = 0,
            Name = "Mercury",
            Diameter = 4_880_000,
            Type = ObjectType.Planet
        },
        
        new AstronomicalObject
        {
            Id = 1,
            Name = "Earth", 
            Diameter = 12_742_000, 
            Type = ObjectType.Planet
        },
        
        new AstronomicalObject
        {
            Id = 2,
            Name = "Proxima Centauri b",
            Diameter = 16_564_600,
            Type = ObjectType.Planet,
            Description = "Closest potentially habitable planet"
        },
        
        new AstronomicalObject
        {
            Id = 3,
            Name = "Neptune", 
            Diameter = 49_244_000,
            Type = ObjectType.Planet
        },
        
        new AstronomicalObject
        {
            Id = 4,
            Name = "Jupiter", 
            Diameter = 139_822_000, 
            Type = ObjectType.Planet
        },
        
        new AstronomicalObject
        {
            Id = 5,
            Name = "The Sun",
            Diameter = 1_392_700_000,
            Type = ObjectType.Star
        }
    };
}