using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Models.Garage;

namespace CarKeeper.Domain.Models.Owner;

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Car> Cars { get; set; }

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
        Cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        if (car.Customer != this)
        {
            car.Customer = this;
        }

        Cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        Cars.Remove(car);
    }
}
