using CarKeeper.Domain.Models.Owner;
using CarKeeper.Domain.Models.Vehicles;

namespace CarKeeper.Test.Domain;

public class CarTests
{
    [Fact]
    public void CanCreateCar()
    {
        //Arrange and Act
        var car = new Car("Tesla", "Model 3, Highland");

        //Assert
        Assert.Equal("Tesla",  car.Manifacture);
        Assert.Equal("Model 3, Highland", car.Model);
    }

    [Fact]
    public void CanAddOwnerToCar()
    {
        //Arrange 
        var car = new Car("Tesla", "Model 3");
        var owner = new VehicleOwner("John", "john@mail.com");

        //Act
        car.Owner = owner;

        //Assert
        Assert.Equal(owner, car.Owner);
    }
}
