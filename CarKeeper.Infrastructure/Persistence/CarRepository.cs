﻿using CarKeeper.Domain.Entities;
using CarKeeper.Domain.Interfaces;
using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Infrastructure.Persistence;

public class CarRepository : IVehicleRepository
{
    private readonly List<Car> _cars = new List<Car>();
    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void AddRange(List<Car> cars)
    {
        _cars.AddRange(cars);
    }

    public void CheckoutCar(Car car)
    {
        _cars.Remove(car);
    }

    public List<Car> GetAllCars()
    {
        return _cars.ToList();
    }

    public Car GetByLicensePlate(string v)
    {
        var car = _cars.Find(c => c.LicensePlate == v);
        return car;
    }

    public bool LicensePlateExists(Car car)
    {
        return _cars.Exists(c => c.LicensePlate.Equals(car.LicensePlate));
    }

    public void RemoveCars(List<Car> cars)
    {
        foreach (var car in cars)
        {
            _cars.Remove(car);
        }
    }
}
