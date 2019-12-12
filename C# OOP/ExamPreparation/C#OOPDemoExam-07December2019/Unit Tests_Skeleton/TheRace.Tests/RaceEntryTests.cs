using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CounterShouldReturnCorrectResult()
        {
            var raceEntry = new RaceEntry();

            Assert.AreEqual(0, raceEntry.Counter);
        }
        
        [Test]
        public void AddRiderShouldThrowInvalidOperationExceptionWhenRiderIsNull()
        {
            var raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null));
        }

        [Test]
        public void AddRiderShouldThrowInvalidOperationExceptionWhenRiderExists()
        {
            var raceEntry = new RaceEntry();

            var rider = new UnitRider("Gosho", new UnitMotorcycle("BMW", 150, 1500));

            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        } 
        
        [Test]
        public void AddRiderShouldWorkCorrectly()
        {
            var raceEntry = new RaceEntry();

            var rider = new UnitRider("Gosho", new UnitMotorcycle("BMW", 150, 1500));

            raceEntry.AddRider(rider);

            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void AddRiderShouldReturnMessageWhenAddIsSuccsesfull()
        {
            var raceEntry = new RaceEntry();

            var rider = new UnitRider("Gosho", new UnitMotorcycle("BMW", 150, 1500));

            var resultMessage=raceEntry.AddRider(rider);
            
            var expectedMessage= $"Rider {rider.Name} added in race.";

            Assert.AreEqual(expectedMessage,resultMessage);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWhenRidersAreBellowMinParticipants()
        {
            var raceEntry = new RaceEntry();

            var rider = new UnitRider("Gosho", new UnitMotorcycle("BMW", 150, 1500));

            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnCorrectResult()
        {
            var raceEntry = new RaceEntry();

            var rider = new UnitRider("Gosho", new UnitMotorcycle("BMW", 150, 1500));
            var secondRider= new UnitRider("Ivan", new UnitMotorcycle("Honda", 150, 1500));
           
            raceEntry.AddRider(rider);
            raceEntry.AddRider(secondRider);

            var result = raceEntry.CalculateAverageHorsePower();
            var expectedResult = 150.00;

            Assert.AreEqual(expectedResult, result);
        }
    }
}