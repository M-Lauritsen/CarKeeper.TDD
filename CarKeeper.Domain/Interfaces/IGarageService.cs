using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Domain.Interfaces;
public interface IGarageService
{
    void AddCustomer(Customer customer);
    void RemoveCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(Customer customer);
    void AddVehicleToCustomer(Car car, Customer customer);
    IEnumerable<Car> GetAllCars();
    IEnumerable<Customer> GetAllCustomers();
}
