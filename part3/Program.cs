using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

public class Car
{
    public string Name;
    public int ProductionYear;
    public double MaxSpeed;
    public Car(string Name, int ProductionYear, double MaxSpeed)
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

public  class CarCatalog
{  
    public Car [] cars;
 

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

    public IEnumerable<Car> ByYear( int year)
    {
        foreach (var a in cars)
        {
            if (a.ProductionYear >= year)
                yield return a;
        }
    }

    public IEnumerable<Car> BySpeed( double speed)
    {
        foreach (var a in cars)
        {
            if (a.MaxSpeed >= speed)
                yield return a;
        }
    }


}

namespace part3
{
    class program
    {

       
        static void Main(string[] args)
        {
            Car[] cars = new[] { new Car("caaar", 2008, 280), new Car("mercedes", 2020, 340), new Car("ziguli", 2023, 250) };
            CarCatalog carCatalog = new CarCatalog(cars);
            Console.WriteLine("в прямом порядке:");
            foreach (Car car in carCatalog.cars) car.print();


            Console.WriteLine("\nв обратном порядке:");
            carCatalog.cars.Reverse();
            foreach (Car car in carCatalog.cars) car.print();


            Console.WriteLine("\nПо году");
            foreach (var a in carCatalog.ByYear( 2010)) a.print();

            Console.WriteLine("\nПо скорости");
            foreach (var a in carCatalog.BySpeed( 300)) a.print();

        }
        


    }

}