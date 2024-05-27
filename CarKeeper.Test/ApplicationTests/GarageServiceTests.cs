using CarKeeper.Application.Services;
using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Interfaces;
using CarKeeper.Domain.Models.Owner;
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
}
