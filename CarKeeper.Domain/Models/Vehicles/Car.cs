
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Domain.Models.Vehicles;

public class Car(string manifacture, string model)
{
    public string Manifacture { get; set; } = manifacture;
    public string Model { get; set; } = model;
    public VehicleOwner Owner { get; set; }
}