using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Models.Garage;
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Test.Domain;

public class CustomerTests
{
    [Fact]
    public void CanCreateOwner()
    {
        //Arrange and Act
        var owner = new Customer("John Doe", "John.doe@example.com");

        //Assert
        Assert.Equal("John Doe", owner.Name);
        Assert.Equal("John.doe@example.com", owner.Email);
    }

    [Fact]
    public void OwnerCanOwnMultipleCars()
    {
        //Arrange
        var owner = new Customer("John", "doe@mail.com");
        var car1 = new Car("Tesla", "Model 3", "AA12345");
        var car2 = new Car("Ford", "Mustang", "AA12345");

        //Act
        owner.AddCar(car1);
        owner.AddCar(car2);

        //Assert
        Assert.Contains(car1, owner.Cars);
        Assert.Contains(car2, owner.Cars);
        Assert.Equal(2, owner.Cars.Count);
    }
}
