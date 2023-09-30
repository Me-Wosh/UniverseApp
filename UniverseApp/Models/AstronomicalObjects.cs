using System.Collections.Generic;

namespace UniverseApp.Models;

public sealed class AstronomicalObjects
{
    public readonly List<AstronomicalObject> ListOfObjects = new ()
    {
        new AstronomicalObject
        {
            Name = "Earth", 
            Diameter = 12742000, 
            Type = ObjectType.Planet
        },
        
        new AstronomicalObject
        {
            Name = "Neptune", 
            Diameter = 49244000,
            Type = ObjectType.Planet
        },
        
        new AstronomicalObject
        {
            Name = "Jupiter", 
            Diameter = 139822000, 
            Type = ObjectType.Planet
        },
    };
}