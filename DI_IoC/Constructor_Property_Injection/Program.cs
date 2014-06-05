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
        // Inject the dependency to Mechanic into the constructor
        AutoShop shop = new AutoShop(mechanic);
        shop.FixCar(car);

        Welder welder = new Welder();

        // Inject the dependency to Welder into the constructor
        shop = new AutoShop(welder);
        shop.FixCar(car);

        shop = new AutoShop();
        // Inject the dependency to Welder into the property
        shop.Worker = welder;
        shop.WeldCar(car);
    }

    class AutoShop
    {
        Mechanic m_mechanic = null;

        public AutoShop() { }

        // Example of construction injection
        public AutoShop(Mechanic mechanic)
        {
            m_mechanic = mechanic;
        }

        public void FixCar(Car theCar)
        {
            m_mechanic.DoWork(theCar);
        }

        // Example of property setter injection
        public Mechanic Worker { get; set; }

        public void WeldCar(Car theCar)
        {
            Worker.DoWork(theCar);
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
        public virtual void DoWork(Car theCar)
        {
            Console.WriteLine("Replaced the oil with soy sauce in a {0} {1} {2}", theCar.Year, theCar.Make, theCar.Model);
        }
    }

    class Welder : Mechanic
    {
        public override void DoWork(Car theCar)
        {
            Console.WriteLine("Welded the trunk shut on a {0} {1} {2}", theCar.Year, theCar.Make, theCar.Model);
        }
    }
}
