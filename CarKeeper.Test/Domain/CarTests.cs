﻿using CarKeeper.Domain.Models.Garage;
using CarKeeper.Domain.Models.Owner;
using CarKeeper.Domain.Models.Vehicles;

namespace CarKeeper.Test.Domain;

public class CarTests
{
    [Fact]
    public void CanCreateCar()
    {
        //Arrange and Act
        var car = new Car("Tesla", "Model 3, Highland", "AA12345");

        //Assert
        Assert.Equal("Tesla",  car.Manifacture);
        Assert.Equal("Model 3, Highland", car.Model);
        Assert.Equal("AA12345", car.LicensePlate);
    }

    [Fact]
    public void CanAddOwnerToCar()
    {
        //Arrange 
        var garage = new CarWorkshop();
        var owner = new VehicleOwner("John", "john@mail.com", garage);
        var car = new Car("Tesla", "Model 3", "AA12345");

        //Act
        car.Owner = owner;

        //Assert
        Assert.Equal(owner, car.Owner);
    }

    [Fact]
    public void CarOwnerIsSetWhenAddedToOwner()
    {
        // Arrange
        var garage = new CarWorkshop();
        var owner = new VehicleOwner("John", "Doe@mail.com", garage);
        var car = new Car("Tesla", "Model 3", "AA12345");

        // Act
        owner.AddCar(car);

        // Assert
        Assert.Equal(owner, car.Owner);
    }
}
