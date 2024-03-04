namespace UniverseApp.Models;

public class AstronomicalObject
{
    public string Name { get; init; } = "";
    public decimal Diameter { get; init; } = 1; // 1 meter
    public string Category { get; init; } = ObjectCategory.Other;
    public string Classification { get; init; } = ObjectClassification.Other;
    public string Description { get; init; } = "";
}