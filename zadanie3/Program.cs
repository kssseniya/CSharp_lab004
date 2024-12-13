using System.Collections;
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

    public override string ToString()
    {
        return $"{Name}, Year: {ProductionYear}, Max Speed: {MaxSpeed} km/h";
    }
}
class CarCatalog : IEnumerable<Car>
{
    private Car[] cars;
    public CarCatalog(Car[] cars)
    {
        this.cars = cars;
    }
    public IEnumerator<Car> GetEnumerator()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            yield return cars[i];
        }
    }
    public IEnumerable<Car> GetReverseEnumerator()
    {
        for (int i = cars.Length - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }
    public IEnumerable<Car> GetByProductionYearEnumerator(int productionYear)
    {
        foreach (Car car in cars)
        {
            if (car.ProductionYear == productionYear) yield return car;
        }
    }
    public IEnumerable<Car> GetByMaxSpeedEnumerator(double maxSpeed)
    {
        foreach (Car car in cars)
        {
            if (car.MaxSpeed == maxSpeed) yield return car;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
internal class Program
{
    static void Main(string[] args)
    {
        Car[] cars = new Car[]
        {
            new Car ("Nissan", 2021, 200),
            new Car ("BMW", 2016, 250),
            new Car ("Audi", 2018, 190)
        };

        CarCatalog catalog = new CarCatalog(cars);
        Console.WriteLine("Прямой проход с первого элемента до последнего:");
        foreach (Car car in catalog)
        {
            Console.WriteLine(car.ToString());
        }
        Console.WriteLine("\nОбратный проход с последнего элемента до первого:");
        foreach (Car car in catalog.GetReverseEnumerator())
        {
            Console.WriteLine(car.ToString());
        }
        Console.WriteLine("\nФильтр по году производства:");
        foreach (Car car in catalog.GetByProductionYearEnumerator(2018))
        {
            Console.WriteLine(car.ToString());
        }
        Console.WriteLine("\nФильтр по максимальной скорости:");
        foreach (Car car in catalog.GetByMaxSpeedEnumerator(200))
        {
            Console.WriteLine(car.ToString());
        }
    }
}