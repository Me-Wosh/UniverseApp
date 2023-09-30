namespace UniverseApp.Models;

public class AstronomicalObject
{
    public string Name { get; set; } = ""; 
    public double Diameter { get; set; }
    public string Type { get; set; } = ObjectType.Other;
    public string Description { get; set; } = "";
}