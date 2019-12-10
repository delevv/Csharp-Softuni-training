namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ParkingShouldReturn12EmptySpots()
        {
            var parking = new SoftPark();

            Assert.AreEqual(12, parking.Parking.Count);
        }

        [Test]
        public void ParkCarShouldThrowArgumentExceptionWhenSpotIsInvalid()
        {
            var parking = new SoftPark();

            Assert.Throws<ArgumentException>(() => parking.ParkCar("InvalidSpot", new Car("BMW", "A4040BG")));
        } 
        
        [Test]
        public void ParkCarShouldThrowArgumentExceptionWhenSpotIsAlreadyTaken()
        {
            var parking = new SoftPark();

            parking.ParkCar("A1", new Car("VW", "BG1242AD"));
            Assert.Throws<ArgumentException>(() => parking.ParkCar("A1", new Car("BMW", "A4040BG")));
        } 
        
        [Test]
        public void ParkCarShouldThrowArgumentExceptionWhenCarIsAlreadyParked()
        {
            var parking = new SoftPark();

            parking.ParkCar("A1", new Car("BMW", "A4040BG"));
            Assert.Throws<InvalidOperationException>(() => parking.ParkCar("A2", new Car("BMW", "A4040BG")));
        }
        
        [Test]
        public void ParkCarShouldReturnMessageWhenCarIsParked()
        {
            var parking = new SoftPark();

            var resultMessage=parking.ParkCar("A1", new Car("BMW", "A4040BG"));
            var expectedMessage = "Car:A4040BG parked successfully!";

            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [Test]
        public void RemoveCarShouldThrowArgumentExceptionWhenSpotIsInvalid()
        {
            var parking = new SoftPark();

            Assert.Throws<ArgumentException>(() => parking.RemoveCar("InvalidSpot", new Car("BMW", "A1241Ss")));
        }

        [Test]
        public void RemoveCarShouldThrowArgumentExceptionWhenCarOnTheSpotIsDifferent()
        {
            var parking = new SoftPark();

            parking.ParkCar("A1", new Car("BMW", "A4040AA"));

            Assert.Throws<ArgumentException>(() => parking.RemoveCar("A1", new Car("Opel", "A1241Ss")));
        }


        [Test]
        public void WhenRemoveCarParkingSpotShouldBeNull()
        {
            var parking = new SoftPark();

            var car = new Car("BMW", "A4040AA");

            parking.ParkCar("A1", car);

            parking.RemoveCar("A1", car);

            Assert.AreEqual(null, parking.Parking["A1"]);
        }

        [Test]
        public void RemoveCarShouldReturnMessageWhenCarIsRemoved()
        {
            var parking = new SoftPark();
            
            var car = new Car("BMW", "A4040AA");
            
            parking.ParkCar("A1", car);
            var resultMessage = parking.RemoveCar("A1", car);
            var expectedMessage = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(expectedMessage, resultMessage);
        }
    }
}