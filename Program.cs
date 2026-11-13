using TaxiPark;
using TaxiPark.Models; 
using TaxiPark.Services;

TestRunner.Run();
string filePath = Path.Combine(AppContext.BaseDirectory, "cars.txt");
TaxiPark.Services.TaxiPark park = new TaxiPark.Services.TaxiPark();

try
{
  
    List<Car> loadedCars = CarFileReader.LoadCars(filePath);

    foreach (Car car in loadedCars)
        park.AddCar(car);
}
catch (Exception)
{
    Console.WriteLine("Не удалось загрузить автомобили из файла cars.txt.");
    return;
}

while (true)
{
    Console.WriteLine();
    Console.WriteLine("===== ТАКСОПАРК =====");
    Console.WriteLine("1. Показать все автомобили");
    Console.WriteLine("2. Показать общую стоимость таксопарка");
    Console.WriteLine("3. Сортировать автомобили по расходу топлива");
    Console.WriteLine("4. Найти автомобили по диапазону максимальной скорости");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите пункт: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            park.ShowCars();
            break;

        case "2":
            Console.WriteLine($"Общая стоимость таксопарка: {park.GetTotalCost():N0}");
            break;

        case "3":
            park.SortByFuelConsumption();
            Console.WriteLine("Автомобили отсортированы по расходу топлива:");
            park.ShowCars();
            break;

        case "4":
            Console.Write("Введите минимальную скорость: ");
            if (!int.TryParse(Console.ReadLine(), out int minSpeed))
            {
                Console.WriteLine("Нужно ввести целое число.");
                break;
            }

            Console.Write("Введите максимальную скорость: ");
            if (!int.TryParse(Console.ReadLine(), out int maxSpeed))
            {
                Console.WriteLine("Нужно ввести целое число.");
                break;
            }

            if (minSpeed > maxSpeed)
            {
                Console.WriteLine("Минимальная скорость не может быть больше максимальной.");
                break;
            }
            List<Car> foundCars = park.FindBySpeed(minSpeed, maxSpeed);

            if (foundCars.Count == 0)
                Console.WriteLine("Подходящие автомобили не найдены.");
            else
            {
                Console.WriteLine("Найденные автомобили:");
                foreach (Car car in foundCars)
                    Console.WriteLine(car.GetInfo());
            }
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Такого пункта нет.");
            break;
    }
}