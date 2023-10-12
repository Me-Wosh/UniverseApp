namespace UniverseApp.Models;

public class AstronomicalObject
{
    public string Name { get; init; } = ""; 
    public double Diameter { get; init; }
    public string Category { get; init; } = ObjectCategory.Other;
    public string Classification { get; init; } = ObjectClassification.Other;
    public string Description { get; init; } = "";
}