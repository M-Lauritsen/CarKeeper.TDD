using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Domain.Interfaces;

public interface ICustomerRepository
{
    void Add(Customer customer);
    void DeleteCustomer(Customer customer);
    List<Customer> GetAllCustomers();
    Customer GetByEmail(string v);
    Customer GetUserWithCarsByEmail(string email);
    void UpdateCustomer(Customer customer);
}
