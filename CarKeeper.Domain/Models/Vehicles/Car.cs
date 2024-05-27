
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Domain.Models.Vehicles;

public class Car(string manifacture, string model, string licensePLate)
{
    public string Manifacture { get; set; } = manifacture;
    public string Model { get; set; } = model;
    public string LicensePlate { get; set; } = licensePLate;
    public VehicleOwner Owner { get; set; }
}