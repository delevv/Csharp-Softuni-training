namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        [Test]
        public void CountShouldReturnCorrectResult()
        {
            var spaceship = new Spaceship("Moon", 10);

            Assert.AreEqual(0, spaceship.Count);
        }
        
        [Test]
        public void NameShouldReturnCorrectResult()
        {
            var spaceship = new Spaceship("Moon", 10);

            Assert.AreEqual("Moon", spaceship.Name);
        }
           
        [Test]
        public void NameShouldThrowArgumentNullExceptionWhenValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 10));
        }
        
        [Test]
        public void NameShouldThrowArgumentNullExceptionWhenValueIsEmptyString()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(string.Empty, 10));
        }

        [Test]
        public void CapacityShouldReturnCorrectResult()
        {
            var spaceship = new Spaceship("Moon", 10);

            Assert.AreEqual(10, spaceship.Capacity);
        }

        [Test]
        public void CapacityShouldThrowArgumenExceptionWhenValueIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("SpaceShip", -1));
        } 
        
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenCapacityIsReached()
        {
            var spaceship = new Spaceship("SpaceShip", 1);

            spaceship.Add(new Astronaut("Ivan", 10));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Asen",10)));
        }
        
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenAstronautAlreadyExist()
        {
            var spaceship = new Spaceship("SpaceShip", 10);

            spaceship.Add(new Astronaut("Ivan", 10));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Ivan", 10)));
        }  
        
        [Test]
        public void AddMethodShouldAddAstronautCorrectly()
        {
            var spaceship = new Spaceship("SpaceShip", 10);

            spaceship.Add(new Astronaut("Ivan", 10));

            Assert.AreEqual(1, spaceship.Count);
        } 
        
        [Test]
        public void RemoveMethodShouldReturnFalseWithInvalidName()
        {
            var spaceship = new Spaceship("SpaceShip", 10);

            spaceship.Add(new Astronaut("Ivan", 10));

            Assert.False(spaceship.Remove("InvalidName"));
        } 
        
        [Test]
        public void RemoveMethodShouldReturnTrueWithValidName()
        {
            var spaceship = new Spaceship("SpaceShip", 10);

            spaceship.Add(new Astronaut("Ivan", 10));

            Assert.True(spaceship.Remove("Ivan"));
        } 
        
        [Test]
        public void RemoveMethodWithValidNameShouldDecreaseCount()
        {
            var spaceship = new Spaceship("SpaceShip", 10);

            spaceship.Add(new Astronaut("Ivan", 10));

            spaceship.Remove("Ivan");

            Assert.AreEqual(0, spaceship.Count);
        }


    }
}