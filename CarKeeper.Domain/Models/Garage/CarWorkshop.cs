using CarKeeper.Domain.Models.Owner;
using CarKeeper.Domain.Models.Vehicles;

namespace CarKeeper.Domain.Models.Garage;

public class CarWorkshop
{
    public List<Car> Cars { get; set; }
    public List<VehicleOwner> Customers { get; set; }

    public CarWorkshop()
    {
        Cars = new List<Car>();
        Customers = new List<VehicleOwner>();
    }

    public void AddCar(Car car)
    {
        if (car is not null && car.Owner != null) 
        {
            Cars.Add(car);
            AddCustomer(car.Owner);
        }
    }

    public void RemoveCar(Car car)
    {
        if (car is not null)
        {
            Cars.Remove(car);
        }
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
        if(customer != null && Customers.Contains(customer))
        {
            foreach (var car in customer.Cars) 
            {
                Cars.Remove(car);
            }
            Customers.Remove(customer);
        }
    }
}