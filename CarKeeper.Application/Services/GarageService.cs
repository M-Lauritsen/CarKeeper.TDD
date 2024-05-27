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

    public IEnumerable<Car> GetAllCars()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public void RemoveCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public void UpdateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }
}
