using System;
using TaxiPark.Models;
using TaxiPark.Services;

namespace TaxiPark
{
    public class TestRunner
    {
        public static void Run()
        {
            Console.WriteLine("=== ЗАПУСК ТЕСТА: Подсчет общей стоимости ===");

            TaxiPark.Services.TaxiPark park = new TaxiPark.Services.TaxiPark();

            Sedan car1 = new Sedan("TestBrand1", "Model1", 2020, 200, 5.0m, 1000m);
            Suv car2 = new Suv("TestBrand2", "Model2", 2021, 180, 8.0m, 2000m);

            park.AddCar(car1);
            park.AddCar(car2);

            decimal actual = park.GetTotalCost();
            decimal expected = 3000m;

            Console.WriteLine($"Ожидаемая сумма: {expected}");
            Console.WriteLine($"Фактическая сумма: {actual}");

            Console.WriteLine("\n--- ВЕРДИКТ ---");
            if (actual == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("СОВПАЛО! Тест пройден.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("НЕ СОВПАЛО! Есть ошибки в коде.");
            }
            Console.ResetColor();
            Console.WriteLine("===========================================\n");
        }
    }
}