using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void TestCarConstructor()
            {
                Car car = new Car("Audi", 3);
                Car car2 = new Car("Mercedes", 0);
                Assert.That(car.CarModel, Is.EqualTo("Audi"));
                Assert.That(car.NumberOfIssues, Is.EqualTo(3));
                Assert.That(car.IsFixed, Is.EqualTo(false));
                Assert.That(car2.IsFixed, Is.EqualTo(true));
            }
            [Test]
            public void TestGarageConstructor()
            {
                Garage garage = new Garage("Zaza", 3);
                Assert.That(garage.Name, Is.EqualTo("Zaza"));
                Assert.That(garage.MechanicsAvailable, Is.EqualTo(3));
                Assert.That(garage.CarsInGarage, Is.EqualTo(0));
                Car car = new Car("Audi", 3);
                garage.AddCar(car);
                Assert.That(garage.CarsInGarage, Is.EqualTo(1));
            }
            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void TestGarageName(string name)
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(name, 3), "Invalid garage name.");
            }
            [Test]
            [TestCase(0)]
            [TestCase(-1)]
            public void TestGarageMechanics(int mechanics)
            {
                Assert.Throws<ArgumentException>(() => new Garage("Zaza", mechanics), "At least one mechanic must work in the garage.");
            }
            [Test]
            public void TestAddCarMethod()
            {
                Garage garage = new Garage("Zaza", 1);
                Car car = new Car("Audi", 3);
                garage.AddCar(car);
                Assert.That(garage.CarsInGarage, Is.EqualTo(1));
                Car car2 = new Car("Mercedes", 1);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car2), "No mechanic available.");
            }
            [Test]
            public void TestFixCarMethod()
            {
                Garage garage = new Garage("Zaza", 5);
                Car car = new Car("Audi", 1);
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Audi"), $"The car {car.CarModel} doesn't exist.");
            }
            [Test]
            public void TestFixCarMethodCorrect()
            {
                Garage garage = new Garage("Zaza", 5);
                Car car = new Car("Audi", 1);
                garage.AddCar(car);
                garage.FixCar("Audi");
                Assert.That(car.NumberOfIssues, Is.EqualTo(0));

                var expectedCar = car;
                Assert.That(expectedCar, Is.EqualTo(car));
            }
            [Test]
            public void TestRemoveCar()
            {
                Garage garage = new Garage("Zaza", 5);
                Car car = new Car("Audi", 1);
                Car car2 = new Car("Mercedes", 1);
                garage.AddCar(car);
                garage.AddCar(car2);
                garage.FixCar("Audi");
                garage.FixCar("Mercedes");
                garage.RemoveFixedCar();
                Assert.That(0, Is.EqualTo(garage.CarsInGarage));
            }
        }
    }
}