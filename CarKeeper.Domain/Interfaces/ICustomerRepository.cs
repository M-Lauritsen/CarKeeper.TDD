using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Domain.Interfaces;

public interface ICustomerRepository
{
    void Add(Customer customer);
}
