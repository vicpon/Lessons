using System.IO;
using System;

class Program
{
    static void Main()
    {
        Car car = new Car
        {
            Make = "Scion",
            Model = "xD",
            Year = 2010
        };

        Mechanic mechanic = new Mechanic();
        AutoShop shop = new AutoShop(mechanic);
        shop.FixCar(car);

        Welder welder = new Welder();
        shop = new AutoShop(welder);
        shop.FixCar(car);
    }

    class AutoShop
    {
        IWorker m_worker = null;

        // Example of construction injection
        public AutoShop(IWorker worker)
        {
            m_worker = worker;
        }

        public void FixCar(Car theCar)
        {
            m_worker.DoWork(theCar);
        }
    }

    class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    interface IWorker
    {
        void DoWork(Car theCar);
    }

    class Mechanic : IWorker
    {
        public void DoWork(Car theCar)
        {
            Console.WriteLine("Replaced the oil with soy sauce in a {0} {1} {2}", theCar.Year, theCar.Make, theCar.Model);
        }
    }

    class Welder : IWorker
    {
        public void DoWork(Car theCar)
        {
            Console.WriteLine("Welded the trunk shut on a {0} {1} {2}", theCar.Year, theCar.Make, theCar.Model);
        }
    }
}
