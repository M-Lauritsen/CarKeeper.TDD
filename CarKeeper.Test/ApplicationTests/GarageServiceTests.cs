using CarKeeper.Application.Services;
using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Interfaces;
using CarKeeper.Domain.Models.Owner;
using Castle.Core.Resource;
using Moq;

namespace CarKeeper.Test.ApplicationTests;

public class GarageServiceTests
{
    private readonly GarageService _garageService;
    private readonly Mock<ICustomerRepository> _customerRepository;
    private readonly Mock<IVehicleRepository> _vehicleRepository;

    public GarageServiceTests()
    {
        _customerRepository = new Mock<ICustomerRepository>();
        _vehicleRepository = new Mock<IVehicleRepository>();
        _garageService = new GarageService(_vehicleRepository.Object, _customerRepository.Object);
    }

    [Fact]
    public void CanAddCustomer()
    {
        //Arrange
        var customer = new Customer("John", "doe@mail.com");

        //Act
        _garageService.AddCustomer(customer);

        //Assert
        _customerRepository.Verify(repo => repo.Add(customer), Times.Once);
    }

    [Fact]
    public void CanAddCustomerWithVehicle() 
    { 
        //Arrange 
        var customer = new Customer("John", "doe@mail.com");
        var car = new Car("Tesla", "Model 3", "AA12345");
        customer.AddCar(car);

        //Act
        _garageService.AddCustomer(customer);

        //Assert
        _customerRepository.Verify(repo => repo.Add(customer), Times.Once);
        _vehicleRepository.Verify(repo => repo.AddRange(customer.Cars), Times.Once);
    }

    [Fact]
    public void CanAddCustomerWithTwoOrMoreVehicles()
    {
        //Arrange 
        var customer = new Customer("John", "doe@mail.com");
        var car1 = new Car("Tesla", "Model 3", "AA12345");
        var car2 = new Car("Tesla", "Model 2", "AA12345");
        customer.AddCar(car1);
        customer.AddCar(car2);

        //Act
        _garageService.AddCustomer(customer);

        //Assert
        _customerRepository.Verify(repo => repo.Add(customer), Times.Once);
        _vehicleRepository.Verify(repo => repo.AddRange(customer.Cars), Times.Once);
    }

    [Fact]
    public void CanDeleteUser()
    {
        //Arrange 
        var customer = new Customer("John", "doe@mail.com");
        _garageService.AddCustomer(customer);

        //Act
        _garageService.DeleteCustomer(customer);

        //Assert
        _customerRepository.Verify(repo => repo.DeleteCustomer(customer), Times.Once);
    }

    [Fact]
    public void CanDeleteUserWithCars()
    {
        //Arrange 
        var customer = new Customer("John", "doe@mail.com");
        var car1 = new Car("Tesla", "Model 3", "AA12345");
        var car2 = new Car("Tesla", "Model 2", "AA12345");
        customer.AddCar(car1);
        customer.AddCar(car2);
        _garageService.AddCustomer(customer);

        //Act
        _garageService.DeleteCustomer(customer);

        //Assert
        _customerRepository.Verify(repo => repo.DeleteCustomer(customer), Times.Once);
        _vehicleRepository.Verify(repo => repo.RemoveCars(customer.Cars), Times.Once);
    }

    [Fact]
    public void CanRemoveCarFromGarageWithoutRemovingUser()
    {
        //Arrange 
        var customer = new Customer("John", "doe@mail.com");
        var car1 = new Car("Tesla", "Model 3", "AA12345");
        var car2 = new Car("Tesla", "Model 2", "AA12345");
        customer.AddCar(car1);
        customer.AddCar(car2);
        _garageService.AddCustomer(customer);

        //Act
        _garageService.CheckoutCar(customer.Cars[1]);

        //Assert
        _vehicleRepository.Verify(repo => repo.CheckoutCar(customer.Cars[1]), Times.Once);
    }

    [Fact]
    public void CanFindCarByLicensePlate()
    {
        // Arrange
        var car = new Car("Tesla", "Model S", "AB12345");
        _vehicleRepository.Setup(repo => repo.GetByLicensePlate("AB12345")).Returns(car);

        // Act
        var result = _garageService.FindCarByLicensePlate("AB12345");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Tesla", result.Manifacture);
        Assert.Equal("Model S", result.Model);
    }

    [Fact]
    public void CanFindCarsByOwnerEmail()
    {
        // Arrange
        var owner = new Customer("John Doe", "john.doe@example.com");
        var car1 = new Car("Tesla", "Model S", "AB12345");
        var car2 = new Car("Tesla", "Model 3", "AB54321");
        owner.AddCar(car1);
        owner.AddCar(car2);
        _customerRepository.Setup(repo => repo.GetByEmail("john.doe@example.com")).Returns(owner);

        // Act
        var result = _garageService.FindCarByOwnerEmail("john.doe@example.com");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(owner.Cars, result);
    }

    [Fact]
    public void CanFindOwnerAndRelatedCarsByOwnerEmail()
    {
        // Arrange
        var owner = new Customer("John Doe", "john.doe@example.com");
        var car1 = new Car("Tesla", "Model S", "AB12345");
        var car2 = new Car("Tesla", "Model 3", "AB54321");
        owner.AddCar(car1);
        owner.AddCar(car2);
        _customerRepository.Setup(repo => repo.GetUserWithCarsByEmail("john.doe@example.com")).Returns(owner);

        // Act
        var result = _garageService.FindOwnerAndCarsByEmail("john.doe@example.com");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(owner, result);
        Assert.Equal(owner.Cars, result.Cars);
    }

    [Fact]
    public void RegisterLicensePlateShouldThrowExceptionWhenPlateAlreadyExists()
    {
        //Arrage
        var owner1 = new Customer("John Doe", "john.doe@example.com");
        var car1 = new Car("Tesla", "Model S", "AB12345");

        var owner2 = new Customer("Jane Doe", "jane.doe@example.com");
        var car2 = new Car("Skoda", "Model S", "AB12345");
        
        owner1.AddCar(car1);
        owner2.AddCar(car2);

        //Act
        _vehicleRepository.Setup(repo => repo.LicensePlateExists(car2)).Returns(true);


        //Assert
        var exception = Assert.Throws<InvalidOperationException>(() => _garageService.RegisterLicensePlate(car2));
        Assert.Equal("License plate already exists", exception.Message);
    }

    [Fact]
    public void GetAllCarsInGarage()
    {
        // Arrange
        var owner = new Customer("John", "john@example.com");
        var car1 = new Car("Tesla", "Model S", "EE12345");
        var car2 = new Car("Tesla", "Model 3", "BB54321");
        owner.AddCar(car1);
        owner.AddCar(car2);
        

        var owner2 = new Customer("Doe", "doe@example.com");
        var car3 = new Car("Tesla", "Model S", "AA12345");
        var car4 = new Car("Tesla", "Model 3", "AB54321");
        owner2.AddCar(car3);
        owner2.AddCar(car4);
        
        _vehicleRepository.Setup(repo => repo.GetAllCars()).Returns(new List<Car> { car1, car2, car3, car4 });

        // Act
        var result = _garageService.GetAllCars();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
        Assert.Contains(car1, result);
        Assert.Contains(car2, result);
        Assert.Contains(car3, result);
        Assert.Contains(car4, result);
    }

    [Fact]
    public void GetAllCustomersInGarage()
    {
        // Arrange
        var owner = new Customer("John", "john@example.com");
        var owner2 = new Customer("Doe", "doe@example.com");
        _garageService.AddCustomer(owner);
        _garageService.AddCustomer(owner2);

        _customerRepository.Setup(repo => repo.GetAllCustomers()).Returns(new List<Customer> {owner, owner2 });

        // Act
        var result = _garageService.GetAllCustomers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(owner, result);
        Assert.Contains(owner2, result);
    }
}
