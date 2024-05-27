using CarKeeper.Domain.Models.Garage;
using CarKeeper.Domain.Models.Vehicles;

namespace CarKeeper.Domain.Models.Owner;

public class VehicleOwner
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Car> Cars { get; set; }
    private CarWorkshop _garage;

    public VehicleOwner(string name, string email, CarWorkshop garage)
    {
        Name = name;
        Email = email;
        Cars = new List<Car>();
        _garage = garage;
    }

    public void AddCar(Car car)
    {
        if (car.Owner != this)
        {
            car.Owner = this;
        }

        if (!_garage.Customers.Contains(this))
        {
            _garage.AddCustomer(this);
        }

        Cars.Add(car);
        _garage.Cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        Cars.Remove(car);
        _garage.RemoveCar(car);
    }
}
