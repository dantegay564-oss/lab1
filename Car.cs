using TaxiPark.Interfaces;

namespace TaxiPark.Models;

public abstract class Car : IDisplayable
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int MaxSpeed { get; set; }
    public decimal FuelConsumption { get; set; }
    public decimal Price { get; set; }

    protected Car(string brand, string model, int year, int maxSpeed,
                  decimal fuelConsumption, decimal price)
    {
        Brand = brand;
        Model = model;
        Year = year;
        MaxSpeed = maxSpeed;
        FuelConsumption = fuelConsumption;
        Price = price;
    }

    public abstract string GetInfo();
}
