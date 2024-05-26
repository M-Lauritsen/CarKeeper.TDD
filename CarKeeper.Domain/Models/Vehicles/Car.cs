namespace CarKeeper.Domain.Models.Vehicles;

public class Car(string manifacture, string model)
{
    
    public string Manifacture { get; set; } = manifacture;
    public string Model { get; set; } = model;

    
}