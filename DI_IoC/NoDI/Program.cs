using System.IO;
using System;

class Program
{
    static void Main()
    {
        AutoShop shop = new AutoShop();
        Car car = new Car
        {
            Make = "Scion",
            Model = "xD",
            Year = 2010
        };

        shop.FixCar(car);
    }

    class AutoShop
    {
        public void FixCar(Car theCar)
        {
            // AutoShop is strongly coupled to Mechanic
            Mechanic mechanic = new Mechanic();
            mechanic.DoWork(theCar);
        }
    }

    class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    class Mechanic
    {
        public void DoWork(Car theCar)
        {
            Console.WriteLine("Replaced the oil with soy sauce in a {0} {1} {2}", theCar.Year, theCar.Make, theCar.Model);
        }
    }

}
