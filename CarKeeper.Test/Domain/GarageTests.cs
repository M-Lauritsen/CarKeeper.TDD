using CarKeeper.Domain.Models.Garage;
using CarKeeper.Domain.Models.Vehicles;

namespace CarKeeper.Test.Domain;

public class GarageTests
{
    [Fact]
    public void CanCreateGarage()
    {
        var garage = new Garage();

        Assert.NotNull(garage);
    }

    [Fact]
    public void CanAddCarToGarage()
    {
        var garage = new Garage();
        var car = new Car("Tesla", "Model 3", "AA12345");

        garage.AddCar(car);

        Assert.Contains(car, garage.Cars);
    }

    [Fact]
    public void CanRemoveCarFromGarage()
    {
        var garage = new Garage();
        var car = new Car("Tesla", "Model 3", "AA12345");
        garage.AddCar(car);

        garage.RemoveCar(car);

        Assert.DoesNotContain(car, garage.Cars);
    }
}
