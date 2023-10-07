namespace UniverseApp.Models;

public class AstronomicalObject
{
    public int Id { get; set; }
    public string Name { get; set; } = ""; 
    public double Diameter { get; set; }
    public string Type { get; set; } = ObjectType.Other;
    public string Description { get; set; } = "";
}