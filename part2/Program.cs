using System;
using System.ComponentModel;
using System.Xml.Linq;

public class Car
{
    public string Name;
    public int ProductionYear;
    public double MaxSpeed;
    public Car (string Name, int ProductionYear, double MaxSpeed)
    {
        this.Name = Name;
        this.ProductionYear = ProductionYear;
        this.MaxSpeed = MaxSpeed;
    }

    public void print()
    {
        Console.WriteLine($"{Name}, {ProductionYear}, {MaxSpeed}");
    }

}

public class CarComparer : IComparer<Car>
{
    private string tip;

    public CarComparer(string tip)
    {
        this.tip = tip;
    }

    public int Compare(Car car1, Car car2)
    {
        if (tip == "имя")
        {
            return string.Compare(car1.Name, car2.Name);
        }
        else if (tip == "год")
        {
            return car1.ProductionYear.CompareTo(car2.ProductionYear);
        }
        else if (tip == "скорость")
        {
            return car1.MaxSpeed.CompareTo(car2.MaxSpeed);
        }

        return 0;
    }
}

namespace part2
{
    class program
    {
        static void Main(string[] args)
        {
            Car[] cars = new[] { new Car("caaar", 2008, 280),new Car("mercedes", 2020, 340), new Car("ziguli", 2023, 250)};
            Console.WriteLine("Отсортировано поо имени:");
            Array.Sort(cars, new CarComparer("имя"));
            foreach (Car car in cars)
            {
                car.print();
            }

            Console.WriteLine("\nОтсортировано по году:");
            Array.Sort(cars, new CarComparer("год"));
            foreach (Car car in cars)
            {
                car.print();
            }

            Console.WriteLine("\nОтсортировано по скорости:");
            Array.Sort(cars, new CarComparer("скорость"));
            foreach (Car car in cars)
            {
                car.print();
            }
        }

    
    }

}