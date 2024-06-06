using System.Collections.Generic;

namespace UniverseApp.Models;

public sealed class AstronomicalObjects
{
    public readonly List<AstronomicalObject> ListOfObjects = new ()
    {
        new AstronomicalObject
        {
            Name = "Average Human",
            Diameter = 1.7m,
            Category = ObjectCategory.LifeForm,
            Classification = ObjectClassification.Human,
            Description = "Dumbest living animal"
        },
        
        new AstronomicalObject
        {
            Name = "African Bush Elephant",
            Diameter = 3.96m,
            Category = ObjectCategory.LifeForm,
            Classification = ObjectClassification.Animal,
            Description = "Heaviest living land animal"
        },
        
        new AstronomicalObject
        {
            Name = "Giraffe",
            Diameter = 5.8m,
            Category = ObjectCategory.LifeForm,
            Classification = ObjectClassification.Animal,
            Description = "Tallest living land animal"
        },
        
        new AstronomicalObject
        {
            Name = "Europa",
            Diameter = 3_100_000,
            Category = ObjectCategory.Moon,
            Classification = ObjectClassification.None,
            Description = "Jupiter's moon that potentially has sea life"
        },
        
        new AstronomicalObject
        {
            Name = "The Moon",
            Diameter = 3_474_800,
            Category = ObjectCategory.Moon,
            Classification = ObjectClassification.None,
            Description = "Earth's only natural satellite"
        },
        
        new AstronomicalObject
        {
            Name = "Mercury",
            Diameter = 4_880_000,
            Category = ObjectCategory.Planet,
            Classification = ObjectClassification.TerrestrialPlanet,
            Description = "The smallest planet of the Solar System"
        },
        
        new AstronomicalObject
        {
            Name = "Ganymede",
            Diameter = 5_268_200,
            Category = ObjectCategory.Moon,
            Classification = ObjectClassification.None,
            Description = "Largest moon in the Solar System"
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
            Name = "Saturn", 
            Diameter = 270_000_000, 
            Category = ObjectCategory.Planet,
            Classification = ObjectClassification.GasGiant,
            Description = "Planet with more moons than all the other Solar System planets combined"
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
            Classification = ObjectClassification.GTypeMainSequence,
            Description = "Center of our Solar System"
        },
        
        new AstronomicalObject
        {
            Name = "Sirius A",
            Diameter = 2_380_685_400,
            Category = ObjectCategory.Star,
            Classification = ObjectClassification.ATypeMainSequence,
            Description = "The brightest known star"
        },
        
        new AstronomicalObject
        {
            Name = "NGC 1600",
            Diameter = 9.888e+13m,
            Category = ObjectCategory.BlackHole,
            Classification = ObjectClassification.SupermassiveBlackHole
        },
        
        new AstronomicalObject
        {
            Name = "TON 618",
            Diameter = 3.92e+14m,
            Category = ObjectCategory.BlackHole,
            Classification = ObjectClassification.SupermassiveBlackHole
        },
        
        new AstronomicalObject
        {
            Name = "Phoenix A",
            Diameter = 5.905e+14m,
            Category = ObjectCategory.BlackHole,
            Classification = ObjectClassification.SupermassiveBlackHole,
            Description = "The largest known black hole"
        },
        
        new AstronomicalObject
        {
            Name = "Milky Way",
            Diameter = 8.2687e+20m,
            Category = ObjectCategory.Galaxy,
            Classification = ObjectClassification.None,
            Description = "Our home galaxy"
        },
        
        new AstronomicalObject
        {
            Name = "Hoag's Object",
            Diameter = 1.400188109941959e+21m,
            Category = ObjectCategory.Galaxy,
            Classification = ObjectClassification.None,
            Description = "Galaxy with an unusual shape"
        },
        
        new AstronomicalObject
        {
            Name = "Andromeda",
            Diameter = 1.4380e+21m,
            Category = ObjectCategory.Galaxy,
            Classification = ObjectClassification.None,
            Description = "Galaxy that we are going to collide with"
        }
    };
}