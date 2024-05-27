using CarKeeper.Domain.Models.Garage;
using CarKeeper.Domain.Models.Owner;
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

    [Fact]
    public void CanAddCustomersToGarage()
    {
        //Arrange
        var garage = new Garage();
        var customer1 = new VehicleOwner("John", "doe@mail.com");
        var customer2 = new VehicleOwner("Doe", "John@mail.com");

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
        var garage = new Garage();
        var customer1 = new VehicleOwner("John", "doe@mail.com");
        var customer2 = new VehicleOwner("Doe", "John@mail.com");
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
        var garage = new Garage();
        var customer = new VehicleOwner("John", "doe@mail.com");
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
        var garage = new Garage();

        //Act
        garage.AddCustomer(null);

        //Assert
        Assert.Empty(garage.Customers);
    }
}
