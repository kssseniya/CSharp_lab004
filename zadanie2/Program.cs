public class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }
}
public class CarComparer : IComparer<Car>
{
    private string sortBy;

    public CarComparer(string sortBy)
    {
        this.sortBy = sortBy;
    }

    public int Compare(Car? car1, Car? car2)
    {
        if (car1 == null || car2 == null)
        {
            throw new ArgumentNullException("Car object is null");
        }
        switch (sortBy)
        {
            case "Name":
                return string.Compare(car1.Name, car2.Name);
            case "ProductionYear":
                return car1.ProductionYear.CompareTo(car2.ProductionYear);
            case "MaxSpeed":
                return car1.MaxSpeed.CompareTo(car2.MaxSpeed);
            default:
                throw new ArgumentException("Invalid sort option");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car[] cars = new Car[]
        {
        new Car ("Nissan", 2021, 200),
        new Car ("BMW", 2016, 250),
        new Car ("Audi", 2018, 190)
        };

        //Сортировка по названию
        Array.Sort(cars, new CarComparer("Name"));
        Console.WriteLine("Сортировка по названию:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name}, {car.ProductionYear}, {car.MaxSpeed}");
        }

        // Сортировка по году выпуска
        Array.Sort(cars, new CarComparer("ProductionYear"));
        Console.WriteLine("\nСортировка по году выпуска:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name}, {car.ProductionYear}, {car.MaxSpeed}");
        }

        // Сортировка по максимальной скорости
        Array.Sort(cars, new CarComparer("MaxSpeed"));
        Console.WriteLine("\nСортировка по максимальной скорости:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name}, {car.ProductionYear}, {car.MaxSpeed}");
        }
    }
}