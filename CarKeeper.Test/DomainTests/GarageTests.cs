﻿using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Models.Garage;
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Test.Domain;

public class GarageTests
{
    [Fact]
    public void CanCreateGarage()
    {
        var garage = new CarWorkshop();

        Assert.NotNull(garage);
    }

    [Fact]
    public void CantAddCarToGarageWithoutOwner()
    {
        var garage = new CarWorkshop();
        var car = new Car("Tesla", "Model 3", "AA12345");

        garage.AddCar(car);

        Assert.DoesNotContain(car, garage.Cars);
    }

    [Fact]
    public void CanRemoveCarFromGarage()
    {
        var garage = new CarWorkshop();
        var car = new Car("Tesla", "Model 3", "AA12345");
        garage.AddCar(car);

        garage.RemoveCar(car);

        Assert.DoesNotContain(car, garage.Cars);
    }

    [Fact]
    public void CanAddCustomersToGarage()
    {
        //Arrange
        var garage = new CarWorkshop();
        var customer1 = new Customer("John", "doe@mail.com");
        var customer2 = new Customer("Doe", "John@mail.com");

        //Act
        garage.AddCustomer(customer1);
        garage.AddCustomer(customer2);

        //Assert
        Assert.Equal(2, garage.Customers.Count);
        Assert.Contains(customer1, garage.Customers);
        Assert.Contains(customer2, garage.Customers);
    }

    [Fact]
    public void CanRemoveCustomerFromGarage()
    {
        //Arrange
        var garage = new CarWorkshop();
        var customer1 = new Customer("John", "doe@mail.com");
        var customer2 = new Customer("Doe", "John@mail.com");
        garage.AddCustomer(customer1);
        garage.AddCustomer(customer2);

        //Act
        garage.RemoveCustomer(customer1);

        //Assert
        Assert.Single(garage.Customers);
        Assert.DoesNotContain(customer1 , garage.Customers);
        Assert.Contains(customer2, garage.Customers);
    }

    [Fact]
    public void CantAddSameCustomerTwice()
    {
        //Arrange 
        var garage = new CarWorkshop();
        var customer = new Customer("John", "doe@mail.com");
        garage.AddCustomer(customer);

        //Act
        garage.AddCustomer(customer);

        //Assert
        Assert.Single(garage.Customers);
        Assert.Contains(customer, garage.Customers);
    }

    [Fact]
    public void CannotAddNullCustomer()
    {
        //Arrange
        var garage = new CarWorkshop();

        //Act
        garage.AddCustomer(null);

        //Assert
        Assert.Empty(garage.Customers);
    }

    [Fact]
    public void RemovingCustomerRemovesTheirCarsFromGarage()
    {
        //Arrange
        var garage = new CarWorkshop();
        var customer = new Customer("John", "doe@mail.com");
        var car = new Car("Tesla", "Model 3", "AA12345");
        customer.AddCar(car);

        //Act
        garage.RemoveCustomer(customer);

        //Assert
        Assert.DoesNotContain(car, garage.Cars);
    }
}
