using TaxiPark.Models;

namespace TaxiPark.Services;

public class TaxiPark
{
    private readonly List<Car> cars = new();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public decimal GetTotalCost()
    {
        decimal total = 0;

        foreach (Car car in cars)
            total += car.Price;

        return total;
    }

    public void SortByFuelConsumption()
    {
        cars.Sort((first, second) =>
            first.FuelConsumption.CompareTo(second.FuelConsumption));
    }

    public List<Car> FindBySpeed(int minSpeed, int maxSpeed)
    {
        List<Car> result = new();

        foreach (Car car in cars)
        {
            if (car.MaxSpeed >= minSpeed && car.MaxSpeed <= maxSpeed)
                result.Add(car);
        }

        return result;
    }

    public void ShowCars()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("В таксопарке пока нет автомобилей.");
            return;
        }

        foreach (Car car in cars)
            Console.WriteLine(car.GetInfo());
    }
}
