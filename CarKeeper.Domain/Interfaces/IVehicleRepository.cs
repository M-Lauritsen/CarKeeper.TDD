using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Domain.Interfaces;

public interface IVehicleRepository
{
    void Add(Car car);
    void AddRange(List<Car> car);
    void Remove(Customer customer);
    void RemoveCars(List<Car> cars);
}
