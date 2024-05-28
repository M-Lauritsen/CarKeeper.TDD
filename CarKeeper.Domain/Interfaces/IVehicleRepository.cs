using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Domain.Interfaces;

public interface IVehicleRepository
{
    void Add(Car car);
    void AddRange(List<Car> car);
    void CheckoutCar(Car car);
    Car GetByLicensePlate(string v);
    bool LicensePlateExists(Car car2);
    void RemoveCars(List<Car> cars);
    List<Car> GetAllCars();
}
