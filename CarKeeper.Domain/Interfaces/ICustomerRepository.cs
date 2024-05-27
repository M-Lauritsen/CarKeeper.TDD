using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Domain.Interfaces;

public interface ICustomerRepository
{
    void Add(Customer customer);
    void DeleteCustomer(Customer customer);
    Customer GetByEmail(string v);
    void Remove(Customer customer);
}
