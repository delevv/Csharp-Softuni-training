namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            var phone = new Phone("Nokia", "3310");

            Assert.AreEqual("Nokia", phone.Make);
            Assert.AreEqual("3310", phone.Model);
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void MakeShouldThrowArgumentExceptionWhenValueIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "3310"));
        }

        [Test]
        public void MakeShouldThrowArgumentExceptionWhenValueIsEmptyString()
        {
            Assert.Throws<ArgumentException>(() => new Phone(string.Empty, "3310"));
        }

        [Test]
        public void MakeShouldSetValueSuccesfull()
        {
            var phone = new Phone("Nokia", "3310");

            Assert.AreEqual("Nokia", phone.Make);
        }

        [Test]
        public void ModelShouldThrowArgumentExceptionWhenValueIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Nokia", null));
        }

        [Test]
        public void ModelShouldThrowArgumentExceptionWhenValueIsEmptyString()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Nokia", string.Empty));
        }

        [Test]
        public void ModelShouldSetValueSuccesfull()
        {
            var phone = new Phone("Nokia", "3310");

            Assert.AreEqual("3310", phone.Model);
        }

        [Test]
        public void CountShouldReturnCorrectResult()
        {
            var phone = new Phone("Nokia", "3310");

            Assert.AreEqual(0, phone.Count);

            phone.AddContact("Gosho", "124141");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void AddContactShouldThrowInvalidOperationExceptionWhenPersonAlreadyExist()
        {
            var phone = new Phone("Nokia", "3310");

            phone.AddContact("Gosho", "124141");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Gosho", "151515"));
        }

        [Test]
        public void AddContactShouldAddPersonSuccesfull()
        {
            var phone = new Phone("Nokia", "3310");

            phone.AddContact("Gosho", "124141");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void CallShouldThrowInvalidOperationExceptionWhenPersonIsNotFound()
        {
            var phone = new Phone("Nokia", "3310");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }

        [Test]
        public void CallShouldReturnMessageWhenIsSuccesfull()
        {
            var phone = new Phone("Nokia", "3310");

            phone.AddContact("Gosho", "124141");

            var resultMessage = phone.Call("Gosho");
            var expectedMessage = $"Calling {"Gosho"} - {"124141"}...";

            Assert.AreEqual(expectedMessage, resultMessage);
        }
    }
}