using CarKeeper.Domain.Models.Vehicles;

namespace CarKeeper.Domain.Models.Garage;

public class Garage
{
    public List<Car> Cars { get; set; }

    public Garage()
    {
        Cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        Cars.Remove(car);
    }
}