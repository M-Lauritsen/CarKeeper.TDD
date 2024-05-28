using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Interfaces;
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Application.Services;

public class GarageService(IVehicleRepository vehicleRepository, ICustomerRepository customerRepository) : IGarageService
{
    private readonly ICustomerRepository customerRepository = customerRepository;
    private readonly IVehicleRepository vehicleRepository = vehicleRepository;

    public void AddCustomer(Customer customer)
    {
        customerRepository.Add(customer);
        if (customer.Cars.Any())
        {
            vehicleRepository.AddRange(customer.Cars);
        }
    }

    public void AddVehicleToCustomer(Car car, Customer customer)
    {
        customer.AddCar(car);
        vehicleRepository.Add(car);
    }

    public void CheckoutCar(Car car)
    {
        vehicleRepository.CheckoutCar(car);
    }

    public void DeleteCustomer(Customer customer)
    {
        if (customer.Cars.Any()) 
        { 
            vehicleRepository.RemoveCars(customer.Cars);
        }
        customerRepository.DeleteCustomer(customer);
    }

    public Car? FindCarByLicensePlate(string licensePlate)
    {
        var car = vehicleRepository.GetByLicensePlate(licensePlate);
        return car;
    }

    public List<Car> FindCarByOwnerEmail(string email)
    {
        var customer = customerRepository.GetByEmail(email);
        return customer.Cars;
    }

    public Customer FindOwnerAndCarsByEmail(string email)
    {
        var customer = customerRepository.GetUserWithCarsByEmail(email);
        return customer;
    }

    public List<Car> GetAllCars()
    {
        var cars = vehicleRepository.GetAllCars();
        return cars;
    }

    public List<Customer> GetAllCustomers()
    {
        return customerRepository.GetAllCustomers();
    }

    public void RegisterLicensePlate(Car car)
    {
        if (vehicleRepository.LicensePlateExists(car)) 
        {
            throw new InvalidOperationException("License plate already exists");
        }
    }

    public void UpdateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }
}
