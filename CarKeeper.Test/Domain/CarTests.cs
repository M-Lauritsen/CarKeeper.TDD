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
}
