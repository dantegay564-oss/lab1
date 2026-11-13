namespace TaxiPark.Models;

public class Hatchback : Car
{
    public Hatchback(string brand, string model, int year, int maxSpeed,
                     decimal fuelConsumption, decimal price)
        : base(brand, model, year, maxSpeed, fuelConsumption, price) { }

    public override string GetInfo()
    {
        return $"Хэтчбек: {Brand} {Model}, {Year} г., скорость: {MaxSpeed} км/ч, " +
               $"расход: {FuelConsumption:F1} л/100 км, цена: {Price:N0}";
    }
}
