using CarKeeper.Domain.Models.Vehicles;

namespace CarKeeper.Domain.Models.Owner;

public class VehicleOwner
{
    public VehicleOwner(string name, string email)
    {
        Name = name;
        Email = email;
        Cars = new List<Car>();
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public List<Car> Cars { get; set; }

    public void AddCar(Car car)
    {
        car.Owner = this;
        Cars.Add(car);
    }
}
