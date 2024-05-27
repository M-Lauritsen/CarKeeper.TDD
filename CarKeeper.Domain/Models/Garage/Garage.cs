using CarKeeper.Domain.Models.Owner;
using CarKeeper.Domain.Models.Vehicles;

namespace CarKeeper.Domain.Models.Garage;

public class Garage
{
    public List<Car> Cars { get; set; }
    public List<VehicleOwner> Customers { get; set; }

    public Garage()
    {
        Cars = new List<Car>();
        Customers = new List<VehicleOwner>();
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        Cars.Remove(car);
    }

    public void AddCustomer(VehicleOwner customer)
    {
        if(customer is not null && !Customers.Contains(customer))
        {
            Customers.Add(customer);
        }
    }

    public void RemoveCustomer(VehicleOwner customer)
    {
        Customers.Remove(customer);
    }
}