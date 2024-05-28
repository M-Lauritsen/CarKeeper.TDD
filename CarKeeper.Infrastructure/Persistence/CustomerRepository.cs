using CarKeeper.Domain.Interfaces;
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Infrastructure.Persistence;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers;
    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public void DeleteCustomer(Customer customer)
    {
        _customers.Remove(customer);
    }

    public List<Customer> GetAllCustomers()
    {
        return _customers;
    }

    public Customer GetByEmail(string v)
    {
        var customer = _customers.FirstOrDefault(x => x.Email == v);
        return customer;
    }

    public Customer GetUserWithCarsByEmail(string email)
    {
        var customer = _customers.FirstOrDefault(x => x.Email == email);
        return customer;
    }
}
