using System.Globalization;
using TaxiPark.Models;

namespace TaxiPark.Services;

public static class CarFileReader
{
    public static List<Car> LoadCars(string filePath)
    {
        List<Car> cars = new();

        foreach (string line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(';');

            if (parts.Length != 7)
                continue;

            string type = parts[0];
            string brand = parts[1];
            string model = parts[2];
            int year = int.Parse(parts[3]);
            int maxSpeed = int.Parse(parts[4]);
            decimal fuel = decimal.Parse(parts[5], CultureInfo.InvariantCulture);
            decimal price = decimal.Parse(parts[6], CultureInfo.InvariantCulture);

            Car? car = type switch
            {
                "Sedan" => new Sedan(brand, model, year, maxSpeed, fuel, price),
                "Hatchback" => new Hatchback(brand, model, year, maxSpeed, fuel, price),
                "Suv" => new Suv(brand, model, year, maxSpeed, fuel, price),
                _ => null
            };

            if (car != null)
                cars.Add(car);
        }

        return cars;
    }
}
